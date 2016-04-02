using System;
using Nancy.Routing;

namespace Nancy.Docs
{
    public static class DocsExtensions
    {
        public static DocsRouteData AsNancyDocs(this RouteDescription desc, Action<DocsRouteDataBuilder> action)
        {
            var builder = new DocsRouteDataBuilder(desc.Name, desc.Method, desc.Path);

            action.Invoke(builder);

            return builder.Data;
        }
    }
}