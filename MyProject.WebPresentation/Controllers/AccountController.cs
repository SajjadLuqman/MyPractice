using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.Models;
using MyProject.WebServices;

namespace MyProject.WebPresentation.Controllers
{
    public class AccountController : Controller
    {
        private UserService _userRepo;

        public AccountController()
        {
            _userRepo = new UserService();
        }

        // GET: Account
        public ActionResult Login()
        {
            ControllerContext.HttpContext.Session["token"] = null;
            ControllerContext.HttpContext.Session["userId"] = null;
            ControllerContext.HttpContext.Session["userName"] = null;
            ControllerContext.HttpContext.Session["token"] = null;
            ControllerContext.HttpContext.Session["userType"] = null;
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users users)
        {
                var result = _userRepo.GetTokenLogin(users);
                if (result != null && !string.IsNullOrEmpty(result.access_token))
                {
                      var userInfo = _userRepo.GetAllUsers().Where(x => x.UserName == users.UserName && x.Password == users.Password).FirstOrDefault();
                        ControllerContext.HttpContext.Session["token"] = result.access_token;
                        ControllerContext.HttpContext.Session["userId"] = userInfo.UserId;
                        ControllerContext.HttpContext.Session["userName"] = users.UserName ;
                        ControllerContext.HttpContext.Session["userType"] = userInfo.Type;
                        ControllerContext.HttpContext.Session["token"] = result.access_token;

                return RedirectToAction("Index", "Admin", new { area = "AdminPanel" });
                }
                else
                {
                    ViewBag.ErrorMessage = "UserName / Password Invalid!";
                }
            return View();
        }
    }
}