using System;
using Nancy.Routing;
using Nancy.Responses.Negotiation;
using System.Collections.Generic;

namespace Nancy.Docs
{

    public class DocsRouteDataBuilder
    {
        public DocsRouteDataBuilder(string name, string method, string apiPath)
        {
            Data = new DocsRouteData
            {
                Name = name,
                Method = method,
                ApiPath = apiPath
            };
        }
  
        public DocsRouteData Data { get; private set; }

        public DocsRouteDataBuilder ResourcePath(string resourcePath)
        {
            Data.ResourcePath = resourcePath;

            return this;
        }

        public DocsRouteDataBuilder ApiPath(string apiPath)
        {
            Data.ApiPath = apiPath;

            return this;
        }

        public DocsRouteDataBuilder Summary(string summary)
        {
            Data.Summary = summary;

            return this;
        }

        public DocsRouteDataBuilder Notes(string notes)
        {
            Data.Notes = notes;

            return this;
        }
            
        public DocsRouteDataBuilder QueryParam<T>(
            string name,
            string description = null,
            bool required = false,
            T defaultValue = default(T))
        {
            return Param(ParameterType.Query, name, description, required, defaultValue);
        }
          
        public DocsRouteDataBuilder BodyParam<T>(
            string description = null,
            bool required = false,
            T defaultValue = default(T))
        {
            return Param(ParameterType.Body, "body", description, required, defaultValue);
        }
            
        public DocsRouteDataBuilder PathParam<T>(
            string name,
            string description = null,
            bool required = false,
            T defaultValue = default(T))
        {
            return Param(ParameterType.Path, name, description, required, defaultValue);
        }
         
        public DocsRouteDataBuilder Param<T>(
            ParameterType paramType,
            string name,
            string description = null,
            bool required = false,
            T defaultValue = default(T))
        {
            var param = new DocsParameterData
            {
                Name = name,
                ParamType = paramType,
                Description = description,
                Required = required,
                DefaultValue = defaultValue,
                ParameterModel = typeof(T)
            };

            Data.Parameters.Add(param);

            return this;
        }
          
        public DocsRouteDataBuilder Response(int code, string message = null)
        {
            message = message ?? Enum.GetName(typeof(HttpStatusCode), code);

            var responseMessage = new ResponseMessage { Code = code, Message = message };

            // TODO: Populate responseModel

            Data.ResponseMessages.Add(responseMessage);

            return this;
        }
       
        public DocsRouteDataBuilder Produces(params MediaType[] mediaTypes)
        {
            foreach (var mediaType in mediaTypes)
            {
                Data.Produces.Add(mediaType);
            }

            return this;
        }
          
        public DocsRouteDataBuilder Consumes(params MediaType[] mediaTypes)
        {
            foreach (var mediaType in mediaTypes)
            {
                Data.Consumes.Add(mediaType);
            }

            return this;
        }

        public DocsRouteDataBuilder Model<T>()
        {
            Data.Model = typeof(T);

            return this;
        }
    }

}
