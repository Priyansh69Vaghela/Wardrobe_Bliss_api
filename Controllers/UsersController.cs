using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Wardrobe_Bliss_api.Data;
using Wardrobe_Bliss_api.Models;

namespace Wardrobe_Bliss_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UsersData _usersData;

        public UsersController(IConfiguration configuration) {

            _usersData = new UsersData(configuration);  
                
        }
        [HttpGet]
        public IActionResult getAllUsers()
        {
            var data = _usersData.GetAllUsers();
            return Ok(data);
        }

        [HttpGet("{id}")]
        public IActionResult UserGetByID(int id)
        {
            var Users = _usersData.SelectByID(id);
            return Ok(Users);
        }
        [HttpDelete("{id}")]
        public IActionResult UserDelete(int id)
        {
            var Users = _usersData.DeleteByID(id);
            return Ok(Users);
        }

        #region User Insert
        [HttpPost]
        public IActionResult UserInsert([FromBody] Users User)
        {
            var Users = _usersData.UserInsert(User);
            return Ok(Users);
        }
        #endregion

        #region User Update
        [HttpPut("{id}")]
        public IActionResult UserUpdate(int id, [FromBody] Users User)
        {
            var Users = _usersData.UserUpdate(id, User);
            return Ok(Users);
        }
        #endregion
    }
}
