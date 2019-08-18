using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MyProject.WebPresentation.Areas.AdminPanel.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            HttpSessionStateBase session = filterContext.HttpContext.Session;
            Controller controller = filterContext.Controller as Controller;

            if (controller != null)
            {
                if (session != null && Session["token"] == null)
                {
                    filterContext.Result =
                           new RedirectToRouteResult(
                               new RouteValueDictionary{{ "controller", "Account" },{ "action", "Login" } , { "area","" } });
                }
            }

            base.OnActionExecuting(filterContext);
        }
    }
}