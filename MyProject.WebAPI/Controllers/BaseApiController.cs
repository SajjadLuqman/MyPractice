using MyProject.Core.Constants;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http;

namespace MyProject.API.Controllers
{
    public class BaseApiController : ApiController
    {
        protected string GetErrorMessages()
        {
            return string.Join(", ", ModelState.Values.Where(x => x.Errors.Count > 0).SelectMany(x => x.Errors).SelectMany(x => x.ErrorMessage).ToArray());
        }


        protected virtual HttpResponseMessage BadRequest(string errorMessage)
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.BadRequest,
                Content = new StringContent(errorMessage, Encoding.UTF8, MimeTypes.PLAIN)
            };
        }

        protected virtual HttpResponseMessage OK(string response)
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(JsonConvert.SerializeObject(response), Encoding.UTF8, MimeTypes.JSON)
            };
        }

        protected virtual HttpResponseMessage OKResponse(object response)
        {
            return new HttpResponseMessage()
            {
                StatusCode = HttpStatusCode.OK,
                Content = new ObjectContent(response.GetType(),response, new JsonMediaTypeFormatter(), MimeTypes.JSON)
            };
        }
    }
}
