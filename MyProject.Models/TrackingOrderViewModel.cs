using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class TrackingOrderViewModel : BaseModel
    {
        public Order Order { get; set; }
        public List<Order> Orders { get; set; }
        public Tracking Tracking { get; set; }
        public List<Tracking> TrackingList { get; set; }
    }
}
