using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.WebPresentation.Areas.AdminPanel.Controllers
{
    public class TrackingController : Controller
    {
        // GET: AdminPanel/Tracking
        public ActionResult AddTrackHistory()
        {
            return View();
        }
    }
}