using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.BusinessLayer;
using Newtonsoft.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        UserManager userManager = new UserManager();
        // GET: api/values
        [HttpGet]
        [Route("GetUsers")]
        public User GetUsers()
        {   
            return userManager.getUser();
        }

        [HttpPost]
        [Route("UserExists")]
        public int UserExists([FromBody] User user)
        {
            return userManager.UserExists(user);
        }
    }


}
