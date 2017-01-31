using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordChain.Data.Models;

namespace WordChain.Data.DataAccess
{
    public class UserDataManager : IUserDataManager
    {
        public static WordChainContext db = new WordChainContext();

        public static ConcurrentDictionary<Guid, int> activeUsers = new ConcurrentDictionary<Guid, int>();

        public void ChangePassword(int id, string newPassword)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == id);
            user.Password = newPassword;
        }

        public void DeleteUser(int id)
        {
            var user = db.Users.Where(x => x.Id == id);
        }

        public IReadOnlyCollection<User> GetAllUsers()
        {
            return db.Users.ToList();
        }

        public User GetUserInformation(int id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id);
        }

        public bool IsUserAdmin(int id)
        {
            return db.Users.FirstOrDefault(x => x.Id == id).IsAdmin;
        }

        public Guid? Login(string username, string password)
        {
            var user = db.Users.FirstOrDefault(x => x.Username == username);
           
            if (user?.Password == password)
            {
                var guid = new Guid();
                activeUsers.GetOrAdd(guid, user.Id);
                return guid;
            }
            return null;

        }

        public void RegisterUser(User newUser)
        {
            if (!db.Users.Any())
            {
                newUser.IsAdmin = true;
            }
            db.Users.Add(newUser);
            db.SaveChanges();
        }

        public bool IsLogged(Guid auth)
        {
            return activeUsers.ContainsKey(auth);
        }
    }
}
