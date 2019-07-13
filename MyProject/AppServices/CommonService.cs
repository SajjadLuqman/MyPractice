using MyProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Models;
using MyProject.Core.Helpers;
using MyProject.Core.Constants;

namespace MyProject.AppServices
{
    public class CommonService : HttpClientService
    {
        public List<Student> GetAllStudents()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Students.GetAllStudent);
            var Content = Get<List<Student>>(URL);
            return Content.Model;
        }

        public Student GetStudentById(int studentId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Students.GetStudentById, studentId);
            var Content = Post<Student>(URL);
            return Content.Model;
        }

        public string DeleteStudentById(int studentId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Students.DeleteStudentById, studentId);
            var Content = Post<string>(URL);
            return Content.Model;
        }

        public string UpdateStudents(Student student)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Students.UpdateStudent);
            var Content = Post<string>(URL,student);
            return Content.Model;
        }

        public string AddStudents(Student student)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Students.InsertStudent);
            var Content = Post<string>(URL, student);
            return Content.Model;
        }
    }
}