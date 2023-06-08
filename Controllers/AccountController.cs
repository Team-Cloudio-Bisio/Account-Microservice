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
        
        private readonly AccountMicroservice.Configuration.IConfiguration _configuration;
        private DBUtils db;

        public AccountController(AccountMicroservice.Configuration.IConfiguration configuration) {
            _configuration = configuration;

            db = new DBUtils();
        }
        
        [HttpPost("login", Name = "LoginUser")]
        public async Task<IActionResult> LoginUser(User user) {
            List<User>? res;

            res = await db.RetrieveUsers(_configuration);

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
        
       
    }
}
