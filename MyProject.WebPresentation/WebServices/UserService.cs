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
    public class UserService : HttpClientService
    {
        public List<Users> GetAllUsers()
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Users.GetUsers);
            var Content = Get<List<Users>>(URL);
            return Content.Model;
        }

        public Users GetUserById(int UserId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Users.GetUsersByUsersId, UserId);
            var Content = Post<Users>(URL);
            return Content.Model;
        }

        public Token GetTokenLogin(Users user)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Users.getToken);
            var Content = PostToken<Token>(URL,new { username = user.UserName, password = user.Password});
            return Content.Model;
        }

        public string DeleteUser(int UserId)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Users.DeleteUsersByUsersId, UserId);
            var Content = Post<string>(URL);
            return Content.Model;
        }

        public string UpdateUser(Users User)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Users.UpdateUsers);
            var Content = Post<string>(URL, User);
            return Content.Model;
        }

        public string AddUser(Users User)
        {
            var URL = string.Format(AppSettings.BaseApiUrl + ApiUrls.Users.InsertUsers);
            var Content = Post<string>(URL, User);
            return Content.Model;
        }
    }
}