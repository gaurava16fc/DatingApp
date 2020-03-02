// using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;
using DatingApp.API.Data;
using DatingApp.API.DTOs;
using DatingApp.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        public IAuthRepository _repo { get; }
        public AuthController(IAuthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDTO userForRegisterDTO)
        {
            userForRegisterDTO.UserName = userForRegisterDTO.UserName.ToLower();
            if (await _repo.UserExists(userForRegisterDTO.UserName))
                return BadRequest("Username already exists.");
            
            var newUser = new User 
            {
                UserName = userForRegisterDTO.UserName
            };
            var createdUser = await _repo.Register(newUser, userForRegisterDTO.Password);

            return StatusCode(201);
        }
    }
}