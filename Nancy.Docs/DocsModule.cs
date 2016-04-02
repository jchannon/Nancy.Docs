using System.Collections.Generic;
using System.Linq;
using Nancy.Routing;

namespace Nancy.Docs
{
    public class DocsModule : NancyModule
    {
        public DocsModule(IRouteCacheProvider routeCacheProvider, IEnumerable<IPageIdentifier> pageIdentifiers )
            : base("/docs")
        {
            
            Get["/"] = _ =>
            {
                //TODO: Get page identifiers and merge to collection
                var pagedata = pageIdentifiers.Select(x => new {Name = x.Name, Link = x.Path});

                var data = routeCacheProvider
                    .GetCache()
                    .RetrieveMetadata<DocsRouteData>()
                    .OfType<DocsRouteData>() //filter nulls
                    .GroupBy(x => x.ResourcePath)
                    .Select(x => new {Name = x.Key, Link = "/docs" + x.Key});

                var merged = pagedata.Concat(data);

                return Response.AsJson(merged);
            };

            //TODO: use pageidentifier or sectionidentifier to allow notes on a resourcepath

            
            Get["/{resourcepath}"] = parameters =>
            {
                var ff = parameters.resourcepath;

                var data = routeCacheProvider
                    .GetCache()
                    .RetrieveMetadata<DocsRouteData>()
                    .OfType<DocsRouteData>() //filter nulls
                    .Where(x => x.ResourcePath == "/" + ff)
                    .ToList();

                return Response.AsJson(data);
            };

            //TODO: return IPageIdentifier contents for ipageidentifier 
            //Get["/{pageidentifiername}"]
        }
    }

    public interface IPageIdentifier
    {
        string Name { get;  }

        string Path { get; set; }
        //or use name as path to markdown
    }
}

