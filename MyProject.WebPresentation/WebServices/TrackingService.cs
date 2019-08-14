using MyProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Models;
using MyProject.Core.Helpers;
using MyProject.Core.Constants;

namespace MyProject.WebServices
{
    public class TrackingService : HttpClientService
    {
        public List<Tracking> GetAllTrackings()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Tracking.GetTracking);
            var Content = Get<List<Tracking>>(URL);
            return Content.Model;
        }

        public Tracking GetTrackingById(int TrackingId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Tracking.GetTrackingByTrackingId, TrackingId);
            var Content = Post<Tracking>(URL);
            return Content.Model;
        }

        public string DeleteTracking(int TrackingId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Tracking.DeleteTrackingByTrackingId, TrackingId);
            var Content = Post<string>(URL);
            return Content.Model;
        }

        public string UpdateTracking(Tracking Tracking)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Tracking.UpdateTracking);
            var Content = Post<string>(URL, Tracking);
            return Content.Model;
        }

        public string AddTracking(Tracking Tracking)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Tracking.InsertTracking);
            var Content = Post<string>(URL, Tracking);
            return Content.Model;
        }
    }
}