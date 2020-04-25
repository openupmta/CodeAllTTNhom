using coderush.Areas.TTNhon_QLKS.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace coderush.Areas.TTNhon_QLKS.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var session = Session[CommonConstants.USER_SESSION];
            if (session == null)
            {
                filterContext.Result = new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { Controller = "login", action = "Index", Area = "admin" }));
            }
            base.OnActionExecuted(filterContext);
        }
    }
}