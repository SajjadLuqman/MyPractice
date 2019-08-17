using Dapper;
using MyProject.DAL.Constants;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace MyProject.DAL.Repositories
{
   public class TrackingRepository : BaseRepository
    {
        public List<Tracking> Get()
        {
            return QueryExecutor.Query<Tracking>(StoreProcedures.spOrderTrackingShow.ToString(), null, CommandType.StoredProcedure).ToList();
        }
        public Tracking GetById(string TrackingId)
        {
            return QueryExecutor.Query<Tracking>(StoreProcedures.spOrderTrackingByTrackId.ToString(), new { TrackingId }, CommandType.StoredProcedure).ToList().FirstOrDefault();
        }
        public List<Tracking> GetByOrderId(string OrderId)
        {
            return QueryExecutor.Query<Tracking>(StoreProcedures.spOrderTrackingByOrderId.ToString(), new { OrderId }, CommandType.StoredProcedure).ToList();
        }
        public int DeleteById(int TrackingId)
        {
            return QueryExecutor.Execute(StoreProcedures.spDeleteTracking.ToString(), new { TrackingId }, CommandType.StoredProcedure);
        }
        public int Update(Tracking obj)
        {
            return QueryExecutor.Execute(StoreProcedures.spUpdateTracking.ToString(), new { obj.H_Date, obj.H_Time,obj.Link,obj.Location,obj.ModifiedBy,obj.ModifiedDate,obj.OrderId,obj.Status,obj.TrackingId ,obj.Pieces});
        }
        public int Insert(Tracking obj)
        {
            return QueryExecutor.Execute(StoreProcedures.spInsertTracking.ToString(), new { obj.H_Date, obj.H_Time, obj.Link, obj.Location, obj.CreatedBy, obj.CreateDate, obj.OrderId, obj.Status, obj.TrackingId, obj.Pieces });
        }
    }
}
