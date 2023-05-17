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
        public ActionResult<int> CheckPassword([FromBody] string password)
        {
            if (password == "")
            {
                return 0;
            }
            PasswordService pw = new PasswordService();
            int result = pw.checkPassword(password);
            return result;
        }
    }
}
