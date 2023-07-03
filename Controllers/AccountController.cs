using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AccountMicroservice.Model;
using AccountMicroservice.Utils;
using Microsoft.AspNetCore.Mvc;

namespace AccountMicroservice.Controllers {
        
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase {
        
        private DBUtils db;

        public AccountController() {
            db = new DBUtils();
        }
        
        [HttpPost("login", Name = "LoginUser")]
        public async Task<IActionResult> LoginUser(User user) {
            List<User>? res;

            res = await db.RetrieveUsers();

            if (res != null) {
                foreach (User u in res) {
                    if (u.Equals(user))
                        return StatusCode(200, "Login succesful!");
                }
                return StatusCode(401, "Login unsuccesful");
            }
            else
                return StatusCode(503, "Server error");
        }
        
        [HttpPost("signin", Name = "SigninUser")]
        public async Task<IActionResult> SigninUser(User user) {
            bool res;

            res = await db.AddUser(user);

            if (res != null) {
                if (res)
                        return StatusCode(200, "Signin succesful!");
                else return StatusCode(401, "Signin unsuccesful");
            }
            else
                return StatusCode(503, "Server error");
        }
        
       
    }
}
