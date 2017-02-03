using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using WordChain.Data.DataAccess;
using WordChain.Data.Models;
using WordChainGame.Attributes;
using WordChainGame.Models;

namespace WordChainGame.Controllers
{
    public class UsersController : ApiController
    {
        public IUserDataManager userData = new UserDataManager();

        [HttpPost]
        public IHttpActionResult Register(User userdata)
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
                    var cr = userData.RegisterUser(us);

                    return Created("User created!", cr.Id);
                }
                else
                {
                    return BadRequest("User information is not in the correct format!");
                }
            }
            else
            {
                return BadRequest("User information is not in the correct format!");
            }
        }       

        [HttpGet]
        [TokenValidation]
        public IHttpActionResult Get()
        {
            var us = userData.GetAllUsers();
            return Ok(us);
        }

        [HttpDelete]
        [TokenValidation]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                userData.DeleteUser(id);
                return Ok("Deleted");
            }
            catch (Exception)
            {
               return NotFound();
            }
        }

        [HttpPut]
        [TokenValidation]
        public IHttpActionResult ChangePassword(int userId, ChangePasswordBindingModel model)
        {
            try
            {
                if (model.NewPassword == model.ConfirmPassword)
                    userData.ChangePassword(userId, model.OldPassword, model.NewPassword);
                else
                    return BadRequest();
            }
            catch (Exception)
            {
                return BadRequest();
            }
            return Ok("Password changed!");
        }
    }
}