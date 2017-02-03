using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordChain.Data.DataAccess
{
    public class LoginManager : ILoginManager
    {
        public static WordChainContext db = new WordChainContext();
       public Active activeUsers = Active.Instance;
        public Guid? Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Username == username);

            if (user?.Password == password)
            {
                var guid = Guid.NewGuid();
                activeUsers.AddUser(guid, user.Id);
                return guid;
            }
            return null;
        }

        public bool Logout(Guid token)
        {

           return activeUsers.DeleteUser(token);
        }
    }
}
