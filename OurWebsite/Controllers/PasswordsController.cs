using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace OurWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        //POST api/<UsersController>
        [HttpPost]
        public int CheckPassword([FromBody] string password)
        {
            PasswordService pw = new PasswordService();
            int result = pw.checkPassword(password);
            return result;
        }
    }
}
