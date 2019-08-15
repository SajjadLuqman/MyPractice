using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.WebPresentation.Areas.AdminPanel.Controllers
{
    public class ShipmentController : Controller
    {
        // GET: AdminPanel/Shipment
        public ActionResult NewShipment()
        {
            return View();
        }
    }
}