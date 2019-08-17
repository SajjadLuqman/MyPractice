using MyProject.Models;
using MyProject.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.WebPresentation.Areas.AdminPanel.Controllers
{
    public class TrackingController : Controller
    {
        private OrderService _orderRepo;
        private TrackingService _trackRepo;

        public TrackingController()
        {
            _orderRepo = new OrderService();
            _trackRepo = new TrackingService();
        }

        // GET: AdminPanel/Tracking
        public ActionResult AddTrackHistory(string Id)
        {
            var Model = _trackRepo.GetTrackingByOrderId(Convert.ToInt32(Id));
            if(Model.ValidationMessage.HasError)
            {
                ViewBag.Message = "Error Occured, Please contact admin";
            }
            Model.Order = _orderRepo.GetOrderById(Convert.ToInt32(Id));

            if (Model.Order == null || Model.Order.ValidationMessage.HasError)
            {
                ViewBag.Message = "Error Occured, Please contact admin";
            }

            return View(Model);
        }

        [HttpPost]
        public ActionResult AddTrack(Tracking track)
        {
            track.CreateDate = DateTime.Now.ToString();
            track.CreatedBy = Session["userId"].ToString();

            var Result = _trackRepo.AddTracking(track);

            var URL = "~/Areas/AdminPanel/Views/Tracking/_Track.cshtml";
            if (Request.IsAjaxRequest())
            {
                return PartialView(URL, track);
            }
            else
            {
                return View(URL, track);
            }
        }


        [HttpPost]
        public JsonResult RemoveTrack(string trackingId)
        {

            var Result = _trackRepo.DeleteTracking(Convert.ToInt32(trackingId));
            if (!Result.HasError)
            {
                return Json(new { success = true }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { success = false }, JsonRequestBehavior.AllowGet);
        }
    }
}