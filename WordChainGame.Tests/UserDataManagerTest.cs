using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordChain.Data.DataAccess;
using WordChain.Data.Models;

namespace WordChainGame.Tests
{
    [TestClass]
    public class UserDataManagerTest
    {
        IUserDataManager usermanager = new UserDataManager(); 
        [TestMethod]
        public void UserWithCorrectDataCanBeInserted()
        {
            var user = new User();
            user.Email = "test@test.test";
            user.Password = "Ivan123";
            user.Username = "Ivan";
            usermanager.RegisterUser(user);
        }
    }
}
