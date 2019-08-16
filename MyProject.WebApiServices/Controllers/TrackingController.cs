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
    public class TrackingController : BaseApiController
    {
        private BLTracking _repo;
        public TrackingController()
        {
            _repo = new BLTracking();
        }

        [Authorize]
        [Route(URLs.Tracking.GetTracking)]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_repo.Get());
        }

        [Authorize]
        [Route(URLs.Tracking.GetTrackingByOrderId)]
        [HttpGet]
        public IHttpActionResult GetTrackingByOrderId(string OrderId)
        {
            return Ok(_repo.GetByOrderId(OrderId));
        }

        [Authorize]
        [Route(URLs.Tracking.GetTrackingByTrackingId)]
        [HttpGet]
        public IHttpActionResult GetById(string TrackingId)
        {
            return Ok(_repo.GetById(TrackingId));
        }

        [Authorize]
        [Route(URLs.Tracking.DeleteTrackingByTrackingId)]
        [HttpPost]
        public IHttpActionResult DeleteById(int TrackingId)
        {
            return Ok(_repo.DeleteById(TrackingId));
        }

        [Authorize]
        [Route(URLs.Tracking.UpdateTracking)]
        [HttpPost]
        public IHttpActionResult Update(Tracking obj)
        {
            return Ok(_repo.Update(obj));
        }

        [Authorize]
        [Route(URLs.Tracking.InsertTracking)]
        [HttpPost]
        public IHttpActionResult Insert(Tracking obj)
        {
            return Ok(_repo.Insert(obj));
        }
    }
}
