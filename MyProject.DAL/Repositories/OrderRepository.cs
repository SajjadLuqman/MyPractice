using Dapper;
using MyProject.DAL.Constants;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MyProject.DAL.Repositories
{
   public class OrderRepository : BaseRepository
    {
        public List<Order> Get()
        {
            return QueryExecutor.Query<Order>(StoreProcedures.spOrderShow.ToString(), null, CommandType.StoredProcedure).ToList();
        }
        public Order GetById(string OrderId)
        {
            return QueryExecutor.Query<Order>(StoreProcedures.spOrderShow.ToString(), new { OrderId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }
        public int DeleteById(int OrderId)
        {
            return QueryExecutor.Execute(StoreProcedures.spOrderDelete.ToString(), new { OrderId }, CommandType.StoredProcedure);
        }
        public int Update(Order obj)
        {
            return QueryExecutor.Execute(StoreProcedures.spOrderUpdate.ToString(), new { obj.AirWayBillNumberNumber, obj.AWB_Number_AirWayBill, obj.Carrier, obj.COD, obj.Commodity, obj.Consignee_ReceiverNameAddress, obj.ModifiedDate, obj.ModifiedBy, obj.CurrentStatus, obj.ETA, obj.ETD, obj.MBL_Container_Number, obj.NumberOfEquipments, obj.PortOfLanding, obj.ProtOfDeliver, obj.Shipper_SenderNameAddress, obj.VesselNameAndVOY, obj.Volume, obj.Weight });
        }
        public int Insert(Order obj)
        {
            return QueryExecutor.Execute(StoreProcedures.spOrderInsert.ToString(), new { obj.AirWayBillNumberNumber, obj.AWB_Number_AirWayBill, obj.Carrier, obj.COD,obj.Commodity,obj.Consignee_ReceiverNameAddress,obj.CreateDate,obj.CreatedBy,obj.CurrentStatus,obj.ETA,obj.ETD,obj.MBL_Container_Number,obj.NumberOfEquipments,obj.PortOfLanding,obj.ProtOfDeliver,obj.Shipper_SenderNameAddress,obj.VesselNameAndVOY,obj.Volume,obj.Weight });
        }
    }
}
