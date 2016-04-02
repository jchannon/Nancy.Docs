using System;
using Nancy.Hosting.Self;
using Nancy.Metadata.Modules;
using System.ComponentModel.DataAnnotations;

namespace Nancy.Docs.Demo
{

    public class Address
    {
        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Town { get; set; }

        public string County { get; set; }

        public string PostCode { get; set; }
    }
    
}
