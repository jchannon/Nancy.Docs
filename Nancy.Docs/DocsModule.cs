using System.Linq;
using Nancy.Routing;

namespace Nancy.Docs
{
    public class DocsModule : NancyModule
    {
        public DocsModule(IRouteCacheProvider routeCacheProvider)
            : base("/docs")
        {
            //TODO: Group by resource path
            Get["/"] = _ =>
            {
                //TODO: Get page identifiers and merge to collection

                var data = routeCacheProvider
                    .GetCache()
                    .RetrieveMetadata<DocsRouteData>()
                    .OfType<DocsRouteData>() //filter nulls
                    .GroupBy(x => x.ResourcePath)
                    .Select(x => new {Name = x.Key, Link = "/docs" + x.Key})
                    .ToList();

                return Response.AsJson(data);
            };

            //TODO: use pageidentifier or sectionidentifier to allow notes on a resourcepath

            //TODO: return DocsRouteData for resourcepath 
            //Get["/{resourcepath}"]

            //TODO: return IPageIdentifier contents for ipageidentifier 
            //Get["/{pageidentifiername}"]
        }
    }

    public interface IPageIdentifier
    {
        string Name { get; set; }

        string Path { get; set; }
        //or use name as path to markdown
    }
}

