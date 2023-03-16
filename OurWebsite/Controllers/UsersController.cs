using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;
using Zxcvbn;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsersController : ControllerBase
    {

        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //UserService uc = new();

        static private string path = "..//wwwroot";

        //GET: api/<UsersController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string? Get(int id)
        {
            return null;
        }

        // POST api/<UsersController>
        [HttpPost("register")]
        public async Task<ActionResult<UserOld>> RegisterPost([FromBody] User user)
        {

            user.UserId = await _userService.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        // POST api/<UsersController>
        [HttpPost("login")]
        public async Task<ActionResult<User>> LoginPost([FromBody] UserOld user)
        {
            User data = await _userService.Login(user);
            if (data != null)
                return data;
            return NoContent();
        }

        //POST api/<UsersController>
        [HttpPost("checkPw")]
        public int CheckPassword([FromBody] string password) 
        {
            int result = Zxcvbn.Core.EvaluatePassword(password).Score;
            return result;
        }
        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserOld>> Put(int id, [FromBody] User user)
        {
            if(await _userService.Update(user, id))
                return Ok(200);
            return NotFound(400);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
