using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.DataLayer
{
    public class UserStore
    {
        private static HttpClient client  = new HttpClient();
       
        public UserStore()
        {
            client.BaseAddress = new Uri("http://localhost:49411/api/");
        }

        public async Task<int> UserExistsAsync(User user)
        {
            try
            {
              
                    var jsonString = JsonConvert.SerializeObject(user);              
                    HttpResponseMessage response = await client.PostAsync("users/userexists", new StringContent(jsonString, Encoding.UTF8, "application/json"));
                    response.EnsureSuccessStatusCode();
                    var returnInt = await response.Content.ReadAsStringAsync();
                    return Convert.ToInt16(returnInt);
                
            }
            catch (Exception exeception)
            {
                return 3;
            }
        }
    }
}
