using MyProject.Models;
using MyProject.WebServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyProject.WebPresentation.Areas.AdminPanel.Controllers
{
    public class UserManageController : Controller
    {
        private UserService _userRepo;

        public UserManageController()
        {
            _userRepo = new UserService();
        }

        // GET: AdminPanel/UserManage
        public ActionResult NewUser(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                var model = _userRepo.GetUserById(Convert.ToInt32(Id));
                if (!model.ValidationMessage.HasError)
                {
                    return View(model);
                }
                else
                {
                    ViewBag.Message = "Error Occured, Please contact admin";
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        [HttpPost]
        public ActionResult NewUser(Users users)
        {
            if (ModelState.IsValid)
            {
                var Result = new ValidationMessage();

                if (users.UserId == 0 || users.UserId == null)
                {
                    if (_userRepo.GetAllUsers().Where(x => x.UserName.ToUpper() == users.UserName.ToUpper()).Any())
                    {
                        ViewBag.Message = "UserName Already Exist";
                        return View();
                    }

                    Result = _userRepo.AddUser(users);
                }
                else
                {
                    if (_userRepo.GetAllUsers().Where(x => x.UserName.ToUpper() == users.UserName.ToUpper()).Count() > 1)
                    {
                        ViewBag.Message = "UserName Already Exist";
                        return View();
                    }

                    Result = _userRepo.UpdateUser(users);
                }

                if (!Result.HasError)
                {
                    ViewBag.Message = "Successfully User Information Saved.";
                    ModelState.Clear();
                }
                else
                {
                    ModelState.AddModelError("ErrorOccurd!", Result.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult AllUsers()
        {
            var Model = _userRepo.GetAllUsers();
            return View(Model);
        }

        public ActionResult DeleteUser(string Id)
        {
            var model = _userRepo.GetUserById(Convert.ToInt32(Id));
            if (!model.ValidationMessage.HasError)
            {
                return View(model);
            }
            else
            {
                ViewBag.Message = "Error Occured, Please contact admin";
                return View();
            }
        }

        [HttpPost]
        public ActionResult DeleteUser(Users user)
        {
            var result =  _userRepo.DeleteUser((int)user.UserId);
            if (!result.HasError)
            {
                ViewBag.Message = "Successfully Delete.";
            }
            else
            {
                ViewBag.Message = "Error Occured, Please contact admin";
            }
            return View();
        }
    }
}