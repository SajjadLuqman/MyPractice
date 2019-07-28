using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyProject.WebAPI.Models
{
    public class TokenModel
    {
        public string access_token { get; set; }
        public string expires_in { get; set; }
        public string token_type { get; set; }
        public string userName { get; set; }
        public string expires { get; set; }
        public string issued { get; set; }
    }
}