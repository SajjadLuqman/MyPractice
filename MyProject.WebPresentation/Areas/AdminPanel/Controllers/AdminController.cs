using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.WebPresentation.Areas.AdminPanel.Controllers
{
    public class AdminController : Controller
    {
        // GET: AdminPanel/Admin
        public ActionResult Index()
        {
            string accessTokenInSession = Convert.ToString(Session["token"]);
            if (string.IsNullOrEmpty(accessTokenInSession))
            {
                return RedirectToAction("Login", "Account", new { area = "" });
            }
            return View();
        }
    }
}