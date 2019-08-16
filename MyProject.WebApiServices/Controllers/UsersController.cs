using MyProject.BusinessLogic;
using MyProject.Models;
using MyProject.WebApiServices.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MyProject.WebApiServices.Controllers
{
    public class UsersController : BaseApiController
    {
        private BLUsers _repo;
        public UsersController()
        {
            _repo = new BLUsers();
        }

        [Authorize]
        [Route(URLs.Users.GetUsers)]
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_repo.Get());
        }

        [Authorize]
        [Route(URLs.Users.GetUsersByUsersId)]
        [HttpGet]
        public IHttpActionResult GetById(string UsersId)
        {
            return Ok(_repo.GetById(UsersId));
        }

        [Authorize]
        [Route(URLs.Users.DeleteUsersByUsersId)]
        [HttpPost]
        public IHttpActionResult DeleteById(int UsersId)
        {
            return Ok(_repo.DeleteById(UsersId));
        }

        [Authorize]
        [Route(URLs.Users.UpdateUsers)]
        [HttpPost]
        public IHttpActionResult Update(Users obj)
        {
            return Ok(_repo.Update(obj));
        }

        [Authorize]
        [Route(URLs.Users.InsertUsers)]
        [HttpPost]
        public IHttpActionResult Insert(Users obj)
        {
            return Ok(_repo.Insert(obj));
        }
    }
}
