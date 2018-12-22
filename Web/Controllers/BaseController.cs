using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SupplierDocuments.Controllers
{
    public abstract class BaseController : Controller
    {
        #region On Exception - Handler

        protected override void OnException(ExceptionContext filterContext)
        {
            //TODO: Log the exception details
            filterContext.ExceptionHandled = true;

            filterContext.Result = new ViewResult() { ViewName = "Error" };
        }

        #endregion
    }
}