using MyProject.BusinessLogic;
using MyProject.Models;
using MyProject.WebApiServices.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;

namespace MyProject.WebApiServices.Controllers
{
    public class OrderController : BaseApiController
    {
        private BLOrder _repo;
        private BLTracking _trackRepo;
        public OrderController()
        {
            _repo = new BLOrder();
            _trackRepo = new BLTracking();
        }

        [Route(URLs.Order.GetTrackHistory)]
        [HttpGet]
        public IHttpActionResult GetTrackHistory(string airWayBillNumberNumber)
        {
            airWayBillNumberNumber = Regex.Replace(airWayBillNumberNumber, "[^a-zA-Z0-9.]", "");
            TrackingOrderViewModel Model = new TrackingOrderViewModel();
            Model.Order = _repo.GetByAirWayBillNumberNumber(airWayBillNumberNumber);
            if(Model.Order!=null)
            {
                var number = Model.Order.AirWayBillNumberNumber;
                Model.Order.AirWayBillNumberNumber = number.Substring(0, 3) + "-" + number.Substring(3, 5) + "-" + number.Substring(8, 2);
                Model.TrackingList = _trackRepo.GetByOrderId(Model.Order.OrderId.ToString());
            }
            else
            {
                Model.ValidationMessage =new ValidationMessage() {  ErrorMessage = "Not Found" };
            }
            return Ok(Model);
        }

        [Authorize]
        [Route(URLs.Order.GetOrder)]
        [HttpGet]
        public IHttpActionResult Get()
        {
            var Orders = _repo.Get();
            foreach (var item in Orders)
            {
                var number = item.AirWayBillNumberNumber;
                item.AirWayBillNumberNumber = number.Substring(0, 3) + "-" + number.Substring(3, 5) + "-" + number.Substring(8, 2);
            }
            return Ok(Orders);
        }

        [Authorize]
        [Route(URLs.Order.GetOrderByOrderId)]
        [HttpGet]
        public IHttpActionResult GetById(string OrderId)
        {
            var Order = _repo.GetById(Convert.ToInt32(OrderId));
            if (Order != null)
            {
                var number = Order.AirWayBillNumberNumber;
                Order.AirWayBillNumberNumber = number.Substring(0, 3) + "-" + number.Substring(3, 5) + "-" + number.Substring(8, 2);
            }
            return Ok(Order);
        }

        [Authorize]
        [Route(URLs.Order.GetByAirWayBillNumberNumber)]
        [HttpGet]
        public IHttpActionResult GetByAirWayBillNumberNumber(string airWayBillNumberNumber)
        {
            var Order = _repo.GetByAirWayBillNumberNumber(airWayBillNumberNumber);
            if(Order!=null)
            {
                var number = Order.AirWayBillNumberNumber;
                Order.AirWayBillNumberNumber = number.Substring(0, 3) + "-" + number.Substring(3, 5) + "-" + number.Substring(8, 2);
            }
            return Ok(Order);
        }

        [Authorize]
        [Route(URLs.Order.DeleteOrderByOrderId)]
        [HttpPost]
        public IHttpActionResult DeleteById(int OrderId)
        {
            return Ok(_repo.DeleteById(OrderId));
        }

        [Authorize]
        [Route(URLs.Order.UpdateOrder)]
        [HttpPost]
        public IHttpActionResult Update(Order obj)
        {
            return Ok(_repo.Update(obj));
        }

        [Authorize]
        [Route(URLs.Order.InsertOrder)]
        [HttpPost]
        public IHttpActionResult Insert(Order obj)
        {
            return Ok(_repo.Insert(obj));
        }
    }
}
