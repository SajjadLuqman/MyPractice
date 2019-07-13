using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyProject.AppServices;

namespace MyProject.Controllers
{
    public class HomeController : Controller
    {
        private CommonService _repo;

        public HomeController()
        {
            _repo = new CommonService();
        }

        public ActionResult Index()
        {
            var allStudents = _repo.GetAllStudents();
            var student = _repo.GetStudentById(5);
            var Effect = _repo.DeleteStudentById(7);
            var effectRow = _repo.UpdateStudents(new Models.Student() { StudentId=10, Name="Pakistan ii ii", Address="Zindabauud" });
            var PKID =  _repo.AddStudents(new Models.Student() {  Name="Pakuuistan", Address= "Zindabahhhd" });
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
