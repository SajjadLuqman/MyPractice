using MyProject.DAL.Repositories;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BusinessLogic
{
    public class BLOrder
    {
        private OrderRepository _repo;
        public BLOrder()
        {
            _repo = new OrderRepository();
        }


        public List<Order> Get()
        {
            return _repo.Get();
        }
        public Order GetById(int OrderId)
        {
            return _repo.GetById(OrderId);
        }

        public Order GetByAirWayBillNumberNumber(string airWayBillNumberNumber)
        {
            return _repo.GetByAirWayBillNumberNumber(airWayBillNumberNumber);
        }

        public int DeleteById(int OrderId)
        {
            return _repo.DeleteById(OrderId);
        }
        public int Update(Order obj)
        {
            return _repo.Update(obj);
        }
        public int Insert(Order obj)
        {
            return _repo.Insert(obj);
        }
    }
}
