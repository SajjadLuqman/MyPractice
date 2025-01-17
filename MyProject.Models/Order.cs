﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Models
{
    public class Order : BaseModel
    {
        public int? OrderId { get; set; }

        [Required(ErrorMessage = "Air Way Bill Number  Required")]
        [MinLength(12, ErrorMessage = "Min Length is 8 of Air Way Bill Number")]
        [MaxLength(12, ErrorMessage = "Max Length is 8 of Air Way Bill Number")]
        public string AirWayBillNumberNumber { get; set; }


        [Required(ErrorMessage = "Shipper is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is 50 of Shipper")]
        public string Shipper_SenderNameAddress { get; set; }

        [Required(ErrorMessage = "Consignee is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is 50 of Consignee")]
        public string Consignee_ReceiverNameAddress { get; set; }

        [Required(ErrorMessage = "Port Of Landing is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is 50 of Port Of Landing")]
        public string PortOfLanding { get; set; }

        [Required(ErrorMessage = "Prot Of Deliver is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is 50 of Prot Of Deliver")]
        public string ProtOfDeliver { get; set; }


        [MaxLength(20, ErrorMessage = "Max Length is 20 of MBL")]
        public string MBL_Container_Number { get; set; }

        [MaxLength(20, ErrorMessage = "AWB Max Length is 20 of AWB")]
        public string AWB_Number_AirWayBill { get; set; }

        [MaxLength(20, ErrorMessage = "MAWB Length is 20 of AWB")]
        public string MAWB { get; set; }

        [MaxLength(20, ErrorMessage = "HBL Length is 20 of AWB")]
        public string HBL { get; set; }



        [Required(ErrorMessage = "Carrier is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is 50 of Carrier")]
        public string Carrier { get; set; }

        [Required(ErrorMessage = "Number Of Equipments is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is 50 of Number Of Equipments")]
        public string NumberOfEquipments { get; set; }

        [Required(ErrorMessage = "Commodity is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is 50 of Commodity")]
        public string Commodity { get; set; }

        [Required(ErrorMessage = "Weight is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is 50 of Weight")]
        public string Weight { get; set; }

        [Required(ErrorMessage = "Volume is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is 50 of Volume")]
        public string Volume { get; set; }

        [Required(ErrorMessage = "Vessel Name & VOY is Required")]
        [MaxLength(50, ErrorMessage = "Max Length is 50 of Vessel Name & VOY")]
        public string VesselNameAndVOY { get; set; }

        [MaxLength(10, ErrorMessage = "Max Length is 10 of COD")]
        public string COD { get; set; }

        [DataType(DataType.Date)]
        [MaxLength(10, ErrorMessage = "Max Length is 10 of ETD")]
        public string ETD { get; set; }

        [MaxLength(10, ErrorMessage = "Max Length is 10 of ETA")]
        public string ETA { get; set; }


        public string CurrentStatus { get; set; }


        public DateTime CreateDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public string CreatedByName { get; set; }
        public string ModifiedByName { get; set; }

        public List<Tracking> ListTracking { get; set; }
    }
}
