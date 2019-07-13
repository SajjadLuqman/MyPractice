using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.API.Constants
{
    public static class URLs
    {
        public static class Student
        {
            public const string GetAllStudentIHttpActionResult = "~/api/students/getAllStudentsIHttpActionResult";

            public const string getAllStudents = "~/api/students/getAllStudents";
            public const string GetStudentById = "~/api/students/GetStudentById/{studentId}";
            public const string DeleteStudentById = "~/api/students/DeleteStudentById/{studentId}";
            public const string UpdateStudent =  "~/api/students/UpdateStudent";
            public const string InsertStudent =  "~/api/students/InsertStudent";
        }
    }
}