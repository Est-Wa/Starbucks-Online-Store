using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

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
            int numberOfUsers = System.IO.File.ReadLines("./Users.txt").Count();
            user.UserId = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText("./Users.txt", userJson + Environment.NewLine);
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        // POST api/<UsersController>
        [HttpPost("login")]
        public ActionResult<User> LoginPost([FromBody] User user)
        {
            User data = new User();
            using (StreamReader reader = System.IO.File.OpenText("./Users.txt"))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    User currentUser = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (currentUser.UserName == user.UserName && currentUser.Password == user.Password)
                        data = currentUser;
                }
            }
            if (data != null)
                return data;
            return NoContent();
        }

        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(int id, [FromBody] User user)
        {
            user.UserId = id;
            string textToReplace = string.Empty;
            using (StreamReader reader = System.IO.File.OpenText("./Users.txt"))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {

                    User currentUser = JsonSerializer.Deserialize<User>(currentUserInFile);
                    if (currentUser.UserId == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText("./Users.txt");
                text = text.Replace(textToReplace, JsonSerializer.Serialize(user));
                System.IO.File.WriteAllText("./Users.txt", text);
            }
            return Ok(200);
        }

        // DELETE api/<UsersController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
