using MyProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Models;
using MyProject.Core.Helpers;
using MyProject.Core.Constants;
using MyProject.WebPresentation.Models;

namespace MyProject.WebServices
{
    public class TrackingService : HttpClientService
    {
        public TrackingOrderViewModel GetAllTrackings()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Tracking.GetTracking);
            var Content = Get<List<Tracking>>(URL);
            if (Content.IsSuccessful)
            {
                return new TrackingOrderViewModel() { TrackingList = Content.Model };
            }
            else
            {
                return new TrackingOrderViewModel() { ValidationMessage = new ValidationMessage() { ErrorMessage = Content.Message } };
            }
        }

        public TrackingOrderViewModel GetTrackingByOrderId(int orderId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Tracking.GetTrackingByOrderId, orderId);
            var Content = Get<List<Tracking>>(URL);
            if (Content.IsSuccessful)
            {
                return new TrackingOrderViewModel() { TrackingList = Content.Model };
            }
            else
            {
                return new TrackingOrderViewModel() { ValidationMessage = new ValidationMessage() { ErrorMessage = Content.Message } };
            }
        }

        public Tracking GetTrackingById(int TrackingId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Tracking.GetTrackingByTrackingId, TrackingId);
            var Content = Get<Tracking>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new Tracking() { ValidationMessage = new ValidationMessage() { ErrorMessage = Content.Message } };
            }
        }

        public ValidationMessage DeleteTracking(int TrackingId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Tracking.DeleteTrackingByTrackingId, TrackingId);
            var Content = Post<string>(URL);
            if (Content.IsSuccessful)
            {
                return new ValidationMessage();
            }
            else
            {
                return new ValidationMessage() { ErrorMessage = Content.Message };
            }
        }

        public ValidationMessage UpdateTracking(Tracking Tracking)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Tracking.UpdateTracking);
            var Content = Post<string>(URL, Tracking);
            if (Content.IsSuccessful)
            {
                return new ValidationMessage();
            }
            else
            {
                return new ValidationMessage() { ErrorMessage = Content.Message };
            }
        }

        public ValidationMessage AddTracking(Tracking Tracking)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Tracking.InsertTracking);
            var Content = Post<string>(URL, Tracking);
            if (Content.IsSuccessful)
            {
                return new ValidationMessage();
            }
            else
            {
                return new ValidationMessage() { ErrorMessage = Content.Message };
            }
        }
    }
}