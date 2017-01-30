using System;
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

        public void RegisterUser(User newUser)
        {
            if (!db.Users.Any())
            {
                newUser.IsAdmin = true;
            }
            db.Users.Add(newUser);
            db.SaveChanges();
        }
    }
}
