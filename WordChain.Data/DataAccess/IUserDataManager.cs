using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordChain.Data.Models;

namespace WordChain.Data.DataAccess
{
    public interface IUserDataManager
    {
        bool IsUserAdmin(int id);

        User GetUserInformation(int id);
        void DeleteUser(int id);

        void RegisterUser(User newUser);

        void ChangePassword(int id, string newPassword);

        IReadOnlyCollection<User> GetAllUsers();
        Guid? Login(string username, string password);

        bool IsLogged(Guid auth);
    }
}
