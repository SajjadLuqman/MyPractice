using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Models;

namespace MyProject.WebPresentation.Models
{
    public class TrackingOrderViewModel
    {
        public TrackingOrderViewModel()
        {
            ValidationMessage = new ValidationMessage();
        }

        public Order Order { get; set; }
        public List<Order> Orders { get; set; }
        public Tracking Tracking { get; set; }
        public List<Tracking> TrackingList { get; set; }
        public ValidationMessage ValidationMessage { get; set; }
    }
}