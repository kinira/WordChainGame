using System.Net;
using System.Net.Http;
using System.Web.Http;
using WordChain.Data.DataAccess;
using WordChain.Data.Models;

namespace WordChainGame.Controllers
{
    public class UsersController : ApiController
    {
        public UserDataManager userData = new UserDataManager();

        [HttpPost]
        public HttpResponseMessage Register(User userdata)
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
                    return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
                }
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.BadRequest);
            }

            return new HttpResponseMessage(System.Net.HttpStatusCode.Created);
        }
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var us = userData.GetAllUsers();
            return Request.CreateResponse(HttpStatusCode.OK, us);
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            userData.DeleteUser(id);
            return Request.CreateResponse(HttpStatusCode.NoContent, $"User with id {id} deleted!");
        }
        //change password with old and new password in request body
    }
}