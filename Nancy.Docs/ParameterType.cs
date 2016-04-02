using System;
using Nancy.Routing;
using Nancy.Responses.Negotiation;
using System.Collections.Generic;

namespace Nancy.Docs
{

    public enum ParameterType
    {
        /// <summary>
        /// Denotes a path parameter.
        /// </summary>
        Path,

        /// <summary>
        /// Denotes a query parameter.
        /// </summary>
        Query,

        /// <summary>
        /// Denotes a body parameter.
        /// </summary>
        Body,

        /// <summary>
        /// Denotes a header parameter.
        /// </summary>
        Header,

        /// <summary>
        /// Denotes a form parameter.
        /// </summary>
        Form
    }

}
