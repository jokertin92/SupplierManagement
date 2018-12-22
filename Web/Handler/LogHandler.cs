using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.IO;

namespace SupplierDocuments.Handler
{
    public class LoggerModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.BeginRequest += Context_BeginRequest;
        }

        #region Begin Request Handler

        private void Context_BeginRequest(object sender, EventArgs e)
        {
            var requestContext = HttpContext.Current.Request;

            /* Log the request details */
            var httpMethod = requestContext.HttpMethod;

            //Check if the http method is supposed to be logged
            var canLog = Enum.GetNames(typeof(HttpMethods)).Contains(httpMethod);

            if (canLog)
            {
                var logContext = requestContext.FilePath;
            }
        }

        #endregion

        #region Dispose Method

        public void Dispose()
        {

        }

        #endregion
    }        
}

#region Enum for HTTP Verbs

public enum HttpMethods
{
    GET = 1,
    PUT,
    POST,
    DELETE
}

#endregion