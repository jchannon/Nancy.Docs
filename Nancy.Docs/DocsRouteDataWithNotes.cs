using System.Collections.Generic;

namespace Nancy.Docs
{
    public class DocsRouteDataWithNotes 
    {
        public IEnumerable<DocsRouteData> RouteData { get; set; } 
        public Dictionary<string,string> Notes { get; set; } 
    }
}