using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;
using MyProject.Core.Constants;
using MyProject.Core.Model;
using Newtonsoft.Json;
using System.Web;
using System.Security.Claims;

namespace MyProject.Core.Services
{
   public class HttpClientService
    {
        static HttpClient _httpClient = new HttpClient(new HttpClientHandler { UseCookies = false });

        static HttpClientService()
        {
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MimeTypes.JSON));
        }

        public ApiResponse<T> Get<T>(string uri) where T : class
        {
            return Send<T>(uri, HttpMethod.Get);
        }

        public ApiResponse<T> Post<T>(string uri, object input = null) where T : class
        {
            return Send<T>(uri, HttpMethod.Post,input);
        }

        private static ApiResponse<T> Send<T>(string uri, HttpMethod method, object input = null)
        {
            var request = new HttpRequestMessage(method, uri);
            if(input != null)
            {
                var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, MimeTypes.JSON);
                request.Content = content;
            }

            var identity = HttpContext.Current.User.Identity as ClaimsIdentity;
            var accessToken = identity.Claims.Where(x => x.Type == Headers.BEARER_TOKEN).FirstOrDefault();
            if(accessToken !=null )
            {
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer",accessToken.Value);
                request.Headers.Add("lang", System.Threading.Thread.CurrentThread.CurrentUICulture.Name);
            }

            request.Headers.AcceptLanguage.Add(new StringWithQualityHeaderValue("en"));
            var response = _httpClient.SendAsync(request).Result;
            var apiResponse = new ApiResponse<T>(response.StatusCode);

            if(!response.IsSuccessStatusCode)
            {
                apiResponse.Message = response.Content.ReadAsStringAsync().Result;
            }
            else 
            {
                if(typeof(T)==typeof(byte[]))
                {
                    apiResponse.Model = (T)(object)response.Content.ReadAsByteArrayAsync().Result;
                }
                else
                {
                    var result = response.Content.ReadAsStringAsync().Result;
                    apiResponse.Model = JsonConvert.DeserializeObject<T>(result);
                }
            }
            return apiResponse;
        }
    }
}
