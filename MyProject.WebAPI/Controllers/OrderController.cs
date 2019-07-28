using MyProject.API.Constants;
using MyProject.BusinessLogic;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyProject.API.Controllers
{
    public class OrderController : ApiController
    {
        private BLOrder _repo;
        public OrderController()
        {
            _repo = new BLOrder();
        }

        [Route(URLs.Order.GetOrder)]
        [HttpGet]
        public List<Order> Get()
        {
            return _repo.Get();
        }

        [Route(URLs.Order.GetOrderByOrderId)]
        [HttpGet]
        public Order GetById(string OrderId)
        {
            return _repo.GetById(OrderId);
        }

        [Route(URLs.Order.GetOrderByOrderId)]
        [HttpPost]
        public int DeleteById(int OrderId)
        {
            return _repo.DeleteById(OrderId);
        }

        [Route(URLs.Order.UpdateOrder)]
        [HttpPost]
        public int Update(Order obj)
        {
            return _repo.Update(obj);
        }

        [Route(URLs.Order.InsertOrder)]
        [HttpPost]
        public int Insert(Order obj)
        {
            return _repo.Insert(obj);
        }
    }
}
