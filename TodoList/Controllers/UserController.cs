using Microsoft.AspNetCore.Mvc;
using TodoList.Data.DTO;
using TodoList.Data.Entities;
using TodoList.Services.Interfaces;

namespace TodoList.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetAllUsers")]
        public IActionResult GetAllUsers() 
        {
            try
            {
                var usersDtos = _userService.GetAllUsers();
                if (usersDtos == null)
                    return NotFound();

                return Ok(usersDtos);
            }
            catch
            {
                return NotFound();
            }
            
        }

        [HttpGet("userId")]
        public IActionResult GetUserById(int userId)
        {
            try
            {
                var user = _userService.GetUserById(userId);
                if (user == null)
                    return NotFound();
                return Ok(user);
            }
            catch 
            { 
                return NotFound(); 
            }
            
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser(CreateUserDTO createUserDTO)
        {
            try
            {
                var newUser = _userService.CreateUser(createUserDTO);
                return CreatedAtAction(nameof(GetUserById), new {userId = newUser.Id_user}, newUser);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
