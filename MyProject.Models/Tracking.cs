using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
   public class Tracking
    {
public int TrackingId { get; set; }
public int OrderId { get; set; }
        public string H_Date { get; set; }
        public string H_Time { get; set; }
        public string Status { get; set; }
        public string Location { get; set; }
        public string Link { get; set; }
        public string CreateDate { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }
    }
}
