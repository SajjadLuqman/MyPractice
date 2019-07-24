using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string AirWayBillNumberNumber { get; set; }
        public string Shipper_SenderNameAddress { get; set; }
        public string Consignee_ReceiverNameAddress { get; set; }
        public string PortOfLanding { get; set; }
        public string ProtOfDeliver { get; set; }
        public string MBL_Container_Number { get; set; }
        public string AWB_Number_AirWayBill { get; set; }
        public string Carrier { get; set; }
        public string NumberOfEquipments { get; set; }
        public string Commodity { get; set; }
        public string Weight { get; set; }
        public string Volume { get; set; }
        public string VesselNameAndVOY { get; set; }
        public string COD { get; set; }
        public string ETD { get; set; }
        public string ETA { get; set; }
        public string CurrentStatus { get; set; }
        public string CreateDate { get; set; }
        public string ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }

        public List<Tracking> ListTracking { get; set; }
    }
}
