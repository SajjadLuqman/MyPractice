using MyProject.BusinessLogic;
using MyProject.Models;
using MyProject.WebApiServices.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
            TrackingOrderViewModel Model = new TrackingOrderViewModel();
            Model.Order = _repo.GetByAirWayBillNumberNumber(airWayBillNumberNumber);
            Model.TrackingList = _trackRepo.GetByOrderId(Model.Order.OrderId.ToString());
            return Ok(Model);
        }

        [Authorize]
        [Route(URLs.Order.GetOrder)]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_repo.Get());
        }

        [Authorize]
        [Route(URLs.Order.GetOrderByOrderId)]
        [HttpGet]
        public IHttpActionResult GetById(string OrderId)
        {
            return Ok(_repo.GetById(Convert.ToInt32(OrderId)));
        }

        [Authorize]
        [Route(URLs.Order.GetByAirWayBillNumberNumber)]
        [HttpGet]
        public IHttpActionResult GetByAirWayBillNumberNumber(string airWayBillNumberNumber)
        {
            return Ok(_repo.GetByAirWayBillNumberNumber(airWayBillNumberNumber));
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
