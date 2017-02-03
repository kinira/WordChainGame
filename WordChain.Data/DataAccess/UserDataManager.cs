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
        public static ConcurrentDictionary<Guid, int> activeUsers = new ConcurrentDictionary<Guid, int>();
        public static WordChainContext db = new WordChainContext();

        public void ChangePassword(int id, string oldPassword, string newPassword)
        {
            var user = db.Users.FirstOrDefault(x => x.Id == id);
            if (user.Password == oldPassword)
            {
                user.Password = newPassword;
                db.SaveChanges();
            }
            else
            {
                throw new FormatException();
            }
        }

        public void DeleteUser(int id)
        {
            var user = db.Users.First(x => x.Id == id);
            db.Users.Remove(user);
            db.SaveChanges();
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
      

        public User RegisterUser(User newUser)
        {
            if (!db.Users.Any())
            {
                newUser.IsAdmin = true;
            }
            db.Users.Add(newUser);
            db.SaveChanges();

            return newUser;
        }
    }
}
