using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Constants
{
   public static class ApiUrls
    {
        public static class Students
        {
            public const string GetAllStudent = "/api/students/getAllStudents";
            public const string GetStudentById = "/api/students/GetStudentById/{0}";
            public const string UpdateStudent = "/api/students/UpdateStudent";
            public const string InsertStudent = "/api/students/InsertStudent";
            public const string DeleteStudentById = "/api/students/DeleteStudentById/{0}";

        }

        public static class Teachers
        {

        }
        
    }
}
