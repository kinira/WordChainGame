using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WordChain.Data.DataAccess;
using WordChain.Data.Models;
using WordChainGame.Models;

namespace WordChainGame.Controllers
{
    public class UsersController : ApiController
    {
        public IUserDataManager userData = new UserDataManager();

        [HttpPost]
        public void Register(User userdata)
        {

            if (userdata.Password.Length > 5 && userdata.Password.Length <=20)
            {
                if (!string.IsNullOrEmpty(userdata.Username))
                {
                    var us = new User()
                    {
                        FullName = userdata.FullName,
                        Email = userdata.Email,
                        Password = userdata.Password,
                        Username = userdata.Username
                    };
                    userData.RegisterUser(us);
                }
                else
                {
                    throw new FormatException("User information is not in the correct format!");
                }
            }
            else
            {
                throw new FormatException("User information is not in the correct format!");
            }
        }

        [HttpPost]
        public Guid Session(LoginModel login)
        {
            var guid = userData.Login(login.Username, login.Password);
            if (guid!= null)
            {
                return guid.Value;
            }
            throw new FormatException("User not exists");
        }

        [HttpGet]
        public IReadOnlyCollection<User> Get()
        {
            var us = userData.GetAllUsers();
            return us;
        }

        [HttpDelete]
        public void Delete(int id)
        {
            userData.DeleteUser(id);
        }
        //change password with old and new password in request body
    }
}