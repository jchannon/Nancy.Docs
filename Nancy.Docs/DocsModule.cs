using System.Collections.Generic;
using System.IO;
using System.Linq;
using CommonMark;
using Nancy.Routing;

namespace Nancy.Docs
{
    public class DocsModule : NancyModule
    {
        public DocsModule(IRouteCacheProvider routeCacheProvider, IEnumerable<IPageIdentifier> pageIdentifiers)
            : base("/docs")
        {

            Get["/"] = _ =>
            {
                var pagedata = pageIdentifiers.Select(x => new { Name = x.Name, Link = "/docs/pages/" + x.Name });

                var data = routeCacheProvider
                    .GetCache()
                    .RetrieveMetadata<DocsRouteData>()
                    .OfType<DocsRouteData>() //filter nulls
                    .GroupBy(x => x.ResourcePath)
                    .Select(x => new { Name = x.Key, Link = "/docs/api" + x.Key });

                var merged = pagedata.Concat(data);

                return Response.AsJson(merged);
            };

            Get["/api/{resourcepath}"] = parameters =>
            {
                var resourcepath = parameters.resourcepath;

                var data = new DocsRouteDataWithNotes();

                var routedata = routeCacheProvider
                    .GetCache()
                    .RetrieveMetadata<DocsRouteData>()
                    .OfType<DocsRouteData>() //filter nulls
                    .Where(x => x.ResourcePath == "/" + resourcepath);

                data.RouteData = routedata;
                data.Notes = new Dictionary<string, string>();


                foreach (var file in Directory.GetFiles("StaticDocs/ResourceDocs/" + resourcepath,"*.md"))
                {
                        data.Notes.Add(Path.GetFileNameWithoutExtension(file), File.ReadAllText(file));
                }

                return Response.AsJson(data);
            };

            Get["/pages/{pagename}"] = parameters =>
            {
                var pageName = parameters.pagename;

                var pageData = pageIdentifiers.FirstOrDefault(x => x.Name == pageName);

                if (pageData == null)
                {
                    return 404;
                }

                var md = File.ReadAllText(pageData.Path);
                var html = CommonMarkConverter.Convert(md);
                return Response.AsText(html).WithContentType("text/html; charset=UTF-8");
            };
        }
    }
}