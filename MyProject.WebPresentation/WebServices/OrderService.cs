using MyProject.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyProject.Models;
using MyProject.Core.Helpers;
using MyProject.Core.Constants;
using MyProject.WebPresentation.Models;

namespace MyProject.WebServices
{
    public class OrderService : HttpClientService
    {
        public TrackingOrderViewModel GetAllOrders()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Order.GetOrder);
            var Content = Get<List<Order>>(URL);
            if (Content.IsSuccessful)
            {
                return new TrackingOrderViewModel() { Orders = Content.Model };
            }
            else
            {
                return new TrackingOrderViewModel() { ValidationMessage = new ValidationMessage() {  ErrorMessage = Content.Message } };
            }
        }

        public Order GetOrderById(int orderId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Order.GetOrderByOrderId, orderId);
            var Content = Get<Order>(URL);
            if (Content.IsSuccessful)
            {
                return Content.Model;
            }
            else
            {
                return new Order() { ValidationMessage = new ValidationMessage() {  ErrorMessage = Content.Message } };
            }
        }

        public ValidationMessage DeleteOrder(int orderId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Order.DeleteOrderByOrderId, orderId);
            var Content = Post<string>(URL);
            if (Content.IsSuccessful)
            {
                return new ValidationMessage();
            }
            else
            {
                return new ValidationMessage() { ErrorMessage = Content.Message };
            }
        }

        public ValidationMessage UpdateOrder(Order order)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Order.UpdateOrder);
            var Content = Post<string>(URL, order);
            if (Content.IsSuccessful)
            {
                return new ValidationMessage();
            }
            else
            {
                return new ValidationMessage() { ErrorMessage = Content.Message };
            }
        }

        public ValidationMessage AddOrder(Order order)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Order.InsertOrder);
            var Content = Post<string>(URL, order);
            if (Content.IsSuccessful)
            {
                return new ValidationMessage();
            }
            else
            {
                return new ValidationMessage() { ErrorMessage = Content.Message };
            }
        }
    }
}