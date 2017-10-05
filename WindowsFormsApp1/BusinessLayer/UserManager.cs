using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.DataLayer;

namespace WindowsFormsApp1.BusinessLayer
{
    public class UserManager
    {
        private static HttpClient client;
        private UserStore userStore;
        public UserManager()
        {
            client = new HttpClient();
            userStore = new UserStore();
        }
        public  async Task<int> UserExists(User user)
        {
            var userExists = await userStore.UserExistsAsync(user);
            return userExists;
        }
    }
}
