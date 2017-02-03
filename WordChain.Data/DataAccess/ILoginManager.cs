using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordChain.Data.DataAccess
{
    public interface ILoginManager
    {
        Guid? Login(string username, string password);
        bool Logout(Guid token);
    }
}
