using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        UserService uc = new();

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
        public ActionResult<User> RegisterPost([FromBody] User user)
        {
            user.UserId = uc.AddUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        // POST api/<UsersController>
        [HttpPost("login")]
        public ActionResult<User> LoginPost([FromBody] User user)
        {
            User data = uc.Login(user);
            if (data != null)
                return data;
            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            if(uc.Update(user,id))
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
