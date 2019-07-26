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
    public class TrackingController : ApiController
    {
        private BLTracking _repo;
        public TrackingController()
        {
            _repo = new BLTracking();
        }

        [Route(URLs.Tracking.GetTracking)]
        [HttpGet]
        public List<Tracking> Get()
        {
            return _repo.Get();
        }

        [Route(URLs.Tracking.GetTrackingByTrackingId)]
        [HttpGet]
        public Tracking GetById(string TrackingId)
        {
            return _repo.GetById(TrackingId);
        }

        [Route(URLs.Tracking.GetTrackingByTrackingId)]
        [HttpPost]
        public int DeleteById(int TrackingId)
        {
            return _repo.DeleteById(TrackingId);
        }

        [Route(URLs.Tracking.UpdateTracking)]
        [HttpPost]
        public int Update(Tracking obj)
        {
            return _repo.Update(obj);
        }

        [Route(URLs.Tracking.InsertTracking)]
        [HttpPost]
        public int Insert(Tracking obj)
        {
            return _repo.Insert(obj);
        }
    }
}
