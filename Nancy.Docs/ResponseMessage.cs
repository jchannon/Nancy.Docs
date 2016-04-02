using System;
using Nancy.Routing;
using Nancy.Responses.Negotiation;
using System.Collections.Generic;

namespace Nancy.Docs
{

    public class ResponseMessage 
    {
        /// <summary>
        /// The HTTP status code returned.
        /// </summary>

        public int Code { get; set; }

        /// <summary>
        /// The explanation for the status code.
        /// </summary>

        public string Message { get; set; }

        /// <summary>
        /// The return type for the given response.
        /// </summary>

        public string ResponseModel { get; set; }
    }

}
