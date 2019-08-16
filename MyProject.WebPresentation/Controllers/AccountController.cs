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
            return View();
        }

        [HttpPost]
        public ActionResult Login(Users users)
        {
            if (ModelState.IsValid)
            {
                var result = _userRepo.GetTokenLogin(users);
                if (result != null && !string.IsNullOrEmpty(result.access_token))
                {
                    ControllerContext.HttpContext.Session["token"] = result.access_token;
                    ControllerContext.HttpContext.Session["userId"] = _userRepo.GetAllUsers().Where(x=>x.UserName == users.UserName && x.Password== users.Password).FirstOrDefault().UserId;
                    ControllerContext.HttpContext.Session["userName"] = users.UserName ;
                    ControllerContext.HttpContext.Session["token"] = result.access_token;
                    return RedirectToAction("Index", "Admin", new { area = "AdminPanel" });
                }
                else
                {
                    ViewBag.ErrorMessage = "UserName / Password Invalid!";
                }
            }
            return View();
        }
    }
}