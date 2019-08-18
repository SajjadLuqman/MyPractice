using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using MyProject.WebServices;

namespace MyProject.WebPresentation.Areas.AdminPanel.Controllers
{
    public class ShipmentController : BaseController
    {
        private OrderService _orderService;

        public ShipmentController()
        {
            _orderService = new OrderService();
        }

        // GET: AdminPanel/Shipment
        public ActionResult NewShipment(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var model = _orderService.GetOrderById(Convert.ToInt32(Id));
                if (!model.ValidationMessage.HasError)
                {
                    return View(model);
                }
                else
                {
                    ViewBag.Message = "Error Occured, Please contact admin";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult NewShipment(Order order)
        {
            string[] formats = { "dd/mm/yyyy", "dd/M/yyyy", "d/M/yyyy", "d/MM/yyyy",
                    "dd/MM/yy", "dd/M/yy", "d/M/yy", "d/MM/yy"};

            DateTime validDate;
            var isCODDateValid = DateTime.TryParseExact(order.COD, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out validDate);
            if (!isCODDateValid) ModelState.AddModelError("COD", "COD needs to be a valid date.");

            var isETADateValid = DateTime.TryParseExact(order.ETA, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out validDate);
            if (!isETADateValid) ModelState.AddModelError("ETA", "ETA needs to be a valid date.");

            var isETDDateValid = DateTime.TryParseExact(order.ETD, formats, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out validDate);
            if (!isETDDateValid) ModelState.AddModelError("COD", "ETD needs to be a valid date.");


            if (ModelState.IsValid)
            {
                var Result = new ValidationMessage();

                if (order.OrderId==0 || order.OrderId == null)
                {
                    order.CreateDate = DateTime.Now.ToString();
                    order.CreatedBy = Session["userId"].ToString();
                    order.CurrentStatus = "1";

                    if(_orderService.GetByAirWayBillNumberNumber(order.AirWayBillNumberNumber)==null)
                    {
                        Result = _orderService.AddOrder(order);
                    }
                    else
                    {
                        ViewBag.Message = "Air Way Bill Number Already Exist.";
                        return View();
                    }
                }
                else
                {
                    order.ModifiedDate = DateTime.Now.ToString();
                    order.ModifiedBy= Session["userId"].ToString();
                    Result = _orderService.UpdateOrder(order);
                }

                if (!Result.HasError)
                {
                    ViewBag.Message = "Successfully Shipment Saved.";
                    ModelState.Clear();
                }
                else
                {
                   ModelState.AddModelError("ErrorOccurd!", Result.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult AllShipment()
        {
            var Model = _orderService.GetAllOrders();
            if (Model.ValidationMessage.HasError)
            {
                ViewBag.Message = "Error Occured, Please contact admin";
                return View(new TrackingOrderViewModel() {  Orders = new List<Order>() });
            }
            return View(Model);
        }

        [HttpPost]
        public ActionResult SearchByAirWayBillNumber(string airWayBillNumberNumber)
        {
            var model = new List<Order>();

            if(airWayBillNumberNumber == "0")
            {
                var Result = _orderService.GetAllOrders();
                model = Result.Orders;
            }
            else
            {
                 model.Add(_orderService.GetByAirWayBillNumberNumber(airWayBillNumberNumber));
            }

            var URL = "~/Areas/AdminPanel/Views/Shipment/_SearchShipments.cshtml";
            if (Request.IsAjaxRequest())
            {
                return PartialView(URL, model);
            }
            else
            {
                return View(URL, model);
            }
        }

        public ActionResult DeleteShipment(string Id)
        {
            var model = _orderService.GetOrderById(Convert.ToInt32(Id));
            if (!model.ValidationMessage.HasError)
            {
                return View(model);
            }
            else
            {
                ViewBag.Message = "Error Occured, Please contact admin";
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteShipment(Order order)
        {
            var result = _orderService.DeleteOrder((int)order.OrderId);
            if (!result.HasError)
            {
                ViewBag.Message = "Successfully Delete.";
            }
            else
            {
                ViewBag.Message = "Error Occured, Please contact admin";
            }
            return View();
        }
    }
}