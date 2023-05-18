using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace OurWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PasswordsController : ControllerBase
    {
        private readonly IPasswordService _passwordService;
        public PasswordsController(IPasswordService passwordService)
        {
            _passwordService = passwordService;
        }
        //POST api/<UsersController>
        [HttpPost]
        public ActionResult<int> CheckPassword([FromBody] string password)
        {
            if (password == "")
            {
                return 0;
            }
            int result = _passwordService.checkPassword(password);
            return result;
        }
    }
}
