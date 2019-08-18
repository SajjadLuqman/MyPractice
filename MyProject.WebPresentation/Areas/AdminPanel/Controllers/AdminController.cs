using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.WebPresentation.Areas.AdminPanel.Controllers
{
    public class AdminController : BaseController
    {
        // GET: AdminPanel/Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}