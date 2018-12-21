using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace SupplierDocuments.Controllers
{
    public abstract class BaseController : Controller
    {
        protected override void OnException(ExceptionContext filterContext)
        {
            //TODO: Log the exception details

            filterContext.ExceptionHandled = true;
        }
    }
}