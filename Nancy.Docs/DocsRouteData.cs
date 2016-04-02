using System;
using Nancy.Routing;
using Nancy.Responses.Negotiation;
using System.Collections.Generic;

namespace Nancy.Docs
{

    public class DocsRouteData
    {
        public DocsRouteData()
        {
            this.Consumes = new List<string>();
            this.Produces = new List<string>();
            this.ResponseMessages = new List<ResponseMessage>();
            this.Parameters = new List<DocsParameterData>();
        }
        public List<string> Consumes
        {
            get;
            set;
        }

        public Type Model
        {
            get;
            set;
        }

        public List<string> Produces
        {
            get;
            set;
        }

        public List<ResponseMessage> ResponseMessages
        {
            get;
            set;
        }

        public List<DocsParameterData> Parameters
        {
            get;
            set;
        }

        public string Notes
        {
            get;
            set;
        }

        public string Summary
        {
            get;
            set;
        }

        public string ApiPath
        {
            get;
            set;
        }

        public string ResourcePath
        {
            get;
            set;
        }

        public string Name { get; set; }

        public string Method { get; set; }


    }



}
