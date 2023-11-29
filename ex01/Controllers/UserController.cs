
using Microsoft.AspNetCore.Mvc;

using servies;
using System.Diagnostics;
using System.Text.Json;
using Zxcvbn;
using DTO;
using AutoMapper;
using Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UserController : ControllerBase
    {
        private readonly IMapper map;

        private readonly string filePath = "./new.txt";

        private readonly IUserServies _UserServies;

        public UserController(IUserServies UserServies, IMapper _map)
        {
            _UserServies = UserServies;
            map = _map;
        }
        [Route("login")]
        // GET: api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> Get([FromBody] UserLosinDto userLogin)
        {
            var userName = userLogin.Email;
            var password = userLogin.Password;
            User user = await _UserServies.getUserByUserNameAndPassword(userName, password);
            if (user == null)
                return NotFound();
            return Ok(user);
         
        }


        // POST api/<UserController>
        public async Task<CreatedAtActionResult> Post([FromBody] UserDto UserDto)
        {
            User user = map.Map<UserDto,User >(UserDto);

            await _UserServies.CreateNewUser(user);
            return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);

        }
        [HttpPost("check")]
        public async Task<int> Check([FromBody] string password)
        {
            
            if (password != "")
            {
               
                return await _UserServies.check(password);
            }
            return -1;

        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] User userToUpdate)
        {
            userToUpdate.UserId = id;
            await _UserServies.Put(id, userToUpdate);
        }
        
    }
}
