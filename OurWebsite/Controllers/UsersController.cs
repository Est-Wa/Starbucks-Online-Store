using AutoMapper;
using DTO;
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

        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ILogger<UsersController> _logger;
        public UsersController(IUserService userService, IMapper mapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _mapper = mapper;
            _logger = logger;
        }

        static private string path = "..//wwwroot";

        // GET api/<UsersController>/5
        [HttpGet("{id}")]
        public string? Get(int id)
        {
            return null;
        }

        // POST api/<UsersController>
        [HttpPost("register")]
        public async Task<ActionResult<UserOld>> RegisterPost([FromBody] UserDTO user)
        {
            _logger.LogInformation($"register attempt, User name: {user.UserName}, etc.");
            PasswordService pw = new PasswordService();
            int result = pw.checkPassword(user.Password);
            if(result<2)
                return BadRequest("password strength is too low");
            var _user = _mapper.Map<User>(user);
                   user.UserId = await _userService.AddUser(_user);
            _logger.LogInformation($"successfull register, user: {user}");
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
        }

        // POST api/<UsersController>
        [HttpPost("login")]
        public async Task<ActionResult<User>> LoginPost([FromBody] UserOld user)
        {
            _logger.LogInformation($"attempt to login, user: {user}");
            User data = await _userService.Login(user);
            if (data != null) {
                _logger.LogInformation($"login success, user: {user}");
                return data;

            }
            _logger.LogInformation($"failed to login, user: {user}");
            return NoContent();
        }


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserOld>> Put(int id, [FromBody] UserDTO user)
        {
            _logger.LogInformation($"attempt to change user information, userId: {id}");
            var _user = _mapper.Map<User>(user);
            if(await _userService.Update(_user, id)) {
                _logger.LogInformation($"success, user changed to {user}");
                return Ok(200);

            }
            _logger.LogInformation($"failed to change user.");

            return NotFound(400);
        }

    }
}
