using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyProject.Core.Helpers
{
   public static class AppSettings
    {
        static NameValueCollection _appSetting = ConfigurationManager.AppSettings;

        public static string BaseApiUrl
        {
            get
            {
                return _appSetting["APIBaseURL"];
            }
        }
    }
}
