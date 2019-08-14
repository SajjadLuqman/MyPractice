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
        public OrderController()
        {
            _repo = new BLOrder();
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
            return Ok(_repo.GetById(OrderId));
        }

        [Authorize]
        [Route(URLs.Order.GetOrderByOrderId)]
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
