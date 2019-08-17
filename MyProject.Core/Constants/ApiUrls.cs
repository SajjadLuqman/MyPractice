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

        public static class Order
        {
            public const string GetOrder = "/api/order/GetOrder";
            public const string GetOrderByOrderId = "/api/order/GetOrderByOrderId/{0}";
            public const string GetByAirWayBillNumberNumber = "/api/order/GetByAirWayBillNumberNumber/{0}";
            public const string DeleteOrderByOrderId = "/api/order/DeleteOrderByOrderId/{0}";
            public const string UpdateOrder = "/api/order/UpdateOrder";
            public const string InsertOrder = "/api/order/InsertOrder";
        }

        public static class Tracking
        {
            public const string GetTracking = "/api/Tracking/GetTracking";
            public const string GetTrackingByTrackingId = "/api/Tracking/GetTrackingByTrackingId/{0}";
            public const string GetTrackingByOrderId = "/api/Tracking/GetTrackingByOrderId/{0}";
            public const string DeleteTrackingByTrackingId = "/api/Tracking/DeleteTrackingByTrackingId/{0}";
            public const string UpdateTracking = "/api/Tracking/UpdateTracking";
            public const string InsertTracking = "/api/Tracking/InsertTracking";
        }

        public static class Users
        {
            public const string GetUsers = "/api/Users/GetUsers";
            public const string GetUsersByUsersId = "/api/Users/GetUsersByUsersId/{0}";
            public const string DeleteUsersByUsersId = "/api/Users/DeleteUsersByUsersId/{0}";
            public const string UpdateUsers = "/api/Users/UpdateUsers";
            public const string InsertUsers = "/api/Users/InsertUsers";
            public const string getToken = "/token";
        }

    }
}
