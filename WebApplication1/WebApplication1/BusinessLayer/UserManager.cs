using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataLayer;
using WebApplication1.Models;

namespace WebApplication1.BusinessLayer
{
    public class UserManager
    {
        public UserStore userStore;
        public UserManager()
        {
            userStore = new UserStore();
        }
        
        public  User getUser()
        {
            return userStore.GetUsers();
        }

        public int UserExists(User user)
        {
            return userStore.VerifyUsers(user);
        }
    }
}
