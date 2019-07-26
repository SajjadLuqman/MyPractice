using MyProject.DAL.Repositories;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.BusinessLogic
{
    public class BLUsers
    {
        private UsersRepository _repo;

        public BLUsers()
        {
            _repo = new UsersRepository();
        }


        public List<Users> Get()
        {
            return _repo.Get();
        }
        public Users GetById(string UsersId)
        {
            return _repo.GetById(UsersId);
        }
        public int DeleteById(int UsersId)
        {
            return _repo.DeleteById(UsersId);
        }
        public int Update(Users obj)
        {
            return _repo.Update(obj);
        }
        public int Insert(Users obj)
        {
            return _repo.Insert(obj);
        }
    }
}
