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

        User RegisterUser(User newUser);

        void ChangePassword(int id,string oldPassword, string newPassword);

        IReadOnlyCollection<User> GetAllUsers();
    }
}
