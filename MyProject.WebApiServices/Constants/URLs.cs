using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.WebApiServices.Constants
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

        public static class Order
        {
            public const string GetOrder = "~/api/order/GetOrder";
            public const string GetOrderByOrderId = "~/api/order/GetOrderByOrderId/{OrderId}";
            public const string DeleteOrderByOrderId = "~/api/order/DeleteOrderByOrderId/{OrderId}";
            public const string UpdateOrder = "~/api/order/UpdateOrder";
            public const string InsertOrder = "~/api/order/InsertOrder";
        }

        public static class Tracking
        {
            public const string GetTracking = "~/api/Tracking/GetTracking";
            public const string GetTrackingByTrackingId = "~/api/Tracking/GetTrackingByTrackingId/{TrackingId}";
            public const string DeleteTrackingByTrackingId = "~/api/Tracking/DeleteTrackingByTrackingId/{TrackingId}";
            public const string UpdateTracking = "~/api/Tracking/UpdateTracking";
            public const string InsertTracking = "~/api/Tracking/InsertTracking";
        }

        public static class Users
        {
            public const string GetUsers = "~/api/Users/GetUsers";
            public const string GetUsersByUsersId = "~/api/Users/GetUsersByUsersId/{UsersId}";
            public const string DeleteUsersByUsersId = "~/api/Users/DeleteUsersByUsersId/{UsersId}";
            public const string UpdateUsers = "~/api/Users/UpdateUsers";
            public const string InsertUsers = "~/api/Users/InsertUsers";
            public const string getToken = "~/token";
        }
    }
}