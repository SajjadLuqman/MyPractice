using MyProject.API.Constants;
using MyProject.BusinessLogic;
using MyProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyProject.API.Controllers
{
    public class UsersController : ApiController
    {
        private BLUsers _repo;
        public UsersController()
        {
            _repo = new BLUsers();
        }

        [Route(URLs.Users.GetUsers)]
        [HttpGet]
        public List<Users> Get()
        {
            return _repo.Get();
        }

        [Route(URLs.Users.GetUsersByUsersId)]
        [HttpGet]
        public Users GetById(string UsersId)
        {
            return _repo.GetById(UsersId);
        }

        [Route(URLs.Users.GetUsersByUsersId)]
        [HttpPost]
        public int DeleteById(int UsersId)
        {
            return _repo.DeleteById(UsersId);
        }

        [Route(URLs.Users.UpdateUsers)]
        [HttpPost]
        public int Update(Users obj)
        {
            return _repo.Update(obj);
        }

        [Route(URLs.Users.InsertUsers)]
        [HttpPost]
        public int Insert(Users obj)
        {
            return _repo.Insert(obj);
        }
    }
}
