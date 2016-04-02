using System;
using Nancy.Routing;
using Nancy.Responses.Negotiation;
using System.Collections.Generic;

namespace Nancy.Docs
{

    public class DocsParameterData
    {
        public string Name { get; set; }

        public ParameterType ParamType { get; set; }

        public string Description { get; set; }

        public bool Required { get; set; }

        public object DefaultValue { get; set; }

        public Type ParameterModel { get; set; }
    }

}
