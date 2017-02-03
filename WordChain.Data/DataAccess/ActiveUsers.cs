using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordChain.Data.DataAccess
{
    public sealed class Active
    {
        private static readonly Lazy<Active> lazy =
            new Lazy<Active>(() => new Active());
        private ConcurrentDictionary<Guid, int> activeUsers = null;


        public static Active Instance { get { return lazy.Value; } }


        private Active()
        {
            if (activeUsers == null)
            {
                activeUsers = new ConcurrentDictionary<Guid, int>();
            }
        }

        public void AddUser(Guid id, int userID)
        {
            activeUsers.GetOrAdd(id, userID);
        }

        public bool DeleteUser(Guid id)
        {
            int userId;
            var rem = activeUsers.TryRemove(id, out userId);
            return rem;
        }

        public int IsUserInsession(Guid token)
        {
            if (activeUsers.ContainsKey(token))
            {
               return activeUsers[token];
            }
            return -1;
        }
    }
}
