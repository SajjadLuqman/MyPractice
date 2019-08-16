using MyProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Models;
using MyProject.Core.Helpers;
using MyProject.Core.Constants;

namespace MyProject.WebServices
{
    public class OrderService : HttpClientService
    {
        public List<Order> GetAllOrders()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Order.GetOrder);
            var Content = Get<List<Order>>(URL);
            return Content.Model;
        }

        public Order GetOrderById(int orderId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Order.GetOrderByOrderId, orderId);
            var Content = Get<Order>(URL);
            return Content.Model;
        }

        public string DeleteOrder(int orderId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Order.DeleteOrderByOrderId, orderId);
            var Content = Post<string>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return Content.Message;
            }
        }

        public string UpdateOrder(Order order)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Order.UpdateOrder);
            var Content = Post<string>(URL, order);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return Content.Message;
            }
        }

        public string AddOrder(Order order)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Order.InsertOrder);
            var Content = Post<string>(URL, order);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return Content.Message;
            }
        }
    }
}