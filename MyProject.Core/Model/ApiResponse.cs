﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Model
{
   public class ApiResponse<T>
    {
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessful { get { return StatusCode == HttpStatusCode.OK; } }

        public string Message { get; set; }
        public string TransactionNumber { get; set; }
        public T Model { get; set; }

        public ApiResponse(HttpStatusCode statusCode)
        {
            StatusCode = statusCode;
        }
    }
}
