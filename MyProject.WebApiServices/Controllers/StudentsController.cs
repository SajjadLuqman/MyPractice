using MyProject.BusinessLogic.StudentModuleBL;
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
    public class StudentsController : BaseApiController
    {
        private StudentBL _repo;
        public StudentsController()
        {
            _repo = new StudentBL();
        }
        
        [Route(URLs.Student.GetAllStudentIHttpActionResult)]
        [HttpGet]
        public IHttpActionResult GetStudentsBySP()
        {
            return Ok(_repo.GetStudentsBySP());
        }

        [Route(URLs.Student.getAllStudents)]
        [HttpGet]
        public HttpResponseMessage GetStudentsBySPSecondWay()
        {
            return OKResponse(_repo.GetStudentsBySP());
        }

        [Route(URLs.Student.GetStudentById)]
        [HttpPost]
        public HttpResponseMessage GetStudentsSPById(int studentId)
        {
            return OKResponse(_repo.GetStudentsSPById(studentId));
        }

        [Route(URLs.Student.DeleteStudentById)]
        [HttpPost]
        public HttpResponseMessage DeleteStudentById(int studentId)
        {
            return OKResponse(_repo.DeleteStudentById(studentId));
        }

        [Route(URLs.Student.UpdateStudent)]
        [HttpPost]
        public HttpResponseMessage UpdateWithDynamicParameters(Student obj)
        {
            return OKResponse(_repo.UpdateWithDynamicParameters(obj));
        }

        [Route(URLs.Student.InsertStudent)]
        [HttpPost]
        public HttpResponseMessage InsertWithDynamicParametersAndReturnValueOutPutParameter(Student obj)
        {
            return OKResponse(_repo.InsertWithDynamicParametersAndReturnValueOutPutParameter(obj));
        }

    }
}
