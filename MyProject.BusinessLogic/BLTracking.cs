using MyProject.DAL.Repositories;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BusinessLogic
{
    public class BLTracking
    {
        private TrackingRepository _repo;
        public BLTracking()
        {
            _repo = new TrackingRepository();
        }


        public List<Tracking> Get()
        {
            return _repo.Get();
        }

        public List<Tracking> GetByOrderId(string OrderId)
        {
            return _repo.GetByOrderId(OrderId);
        }

        public Tracking GetById(string TrackingId)
        {
            return _repo.GetById(TrackingId);
        }
        public int DeleteById(int TrackingId)
        {
            return _repo.DeleteById(TrackingId);
        }
        public int Update(Tracking obj)
        {
            return _repo.Update(obj);
        }
        public int Insert(Tracking obj)
        {
            return _repo.Insert(obj);
        }
    }
}
