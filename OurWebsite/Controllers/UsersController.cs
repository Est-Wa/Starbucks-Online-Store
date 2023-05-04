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
        public UsersController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
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
            PasswordService pw = new PasswordService();
            int result = pw.checkPassword(user.Password);
            if(result<2)
                return BadRequest("password strength is too low");
            var _user = _mapper.Map<User>(user);
                   user.UserId = await _userService.AddUser(_user);
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


        // PUT api/<UsersController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<UserOld>> Put(int id, [FromBody] UserDTO user)
        {
            var _user = _mapper.Map<User>(user);
            if(await _userService.Update(_user, id))
                return Ok(200);
            return NotFound(400);
        }

    }
}
