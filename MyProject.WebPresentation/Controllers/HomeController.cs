using MyProject.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.WebPresentation.Controllers
{
    public class HomeController : Controller
    {
        private CommonService _repo;
        private OrderService _order;

        public HomeController()
        {
            _repo = new CommonService();
            _order = new OrderService();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Tracking(string Id)
        {
            var Model = _order.GetTrackHistory(Id);
            if(Model.ValidationMessage.HasError)
            {
                return RedirectToAction("Index");
            }
            return View(Model);
        }

        public ActionResult AirFreight()
        {
            return View();
        }

        public ActionResult Associations()
        {
            return View();
        }

        public ActionResult CustomClearance()
        {
            return View();
        }

        public ActionResult ProjectHandling()
        {
            return View();
        }

        public ActionResult RoadTransportation()
        {
            return View();
        }

        public ActionResult SeaFreight()
        {
            return View();
        }

        public ActionResult WarehousingAndDistribution()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
    }
}