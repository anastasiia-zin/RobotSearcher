using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Models;
using Requests.Auth;
using Services.Interfaces;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("user/")]
    public class UserController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAuthService _authService;

        public UserController(UserManager<AppUser> userManager, IAuthService authService)
        {
            _userManager = userManager;
            _authService = authService;
        }

        [HttpPost("token")]
        [ProducesResponseType(typeof(LoginUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> LoginAsync(LoginUserRequest request)
        {
            var user = await _userManager.FindByEmailAsync(request.Email);

            if (user == null || !await _userManager.CheckPasswordAsync(user, request.Password))
            {
                return BadRequest("The email or password is incorrect.");
            }

            var userRoles = await _userManager.GetRolesAsync(user);
            var token = _authService.GenerateToken(user.Id, userRoles);
            var result = new LoginUserResponse()
            {
                Token = token
            };

            return Ok(result);
        }

        [HttpPost]
        [ProducesResponseType(typeof(RegisterUserResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddUserAsync(RegisterUserRequest request)
        {
            if (_userManager.Users.Any(x => x.Email == request.Email))
            {
                return BadRequest("This email already exists");
            }

            if (_userManager.Users.Any(x => x.UserName == request.Phone))
            {
                return BadRequest("This phone already exists");
            }

            var user = new AppUser()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.Email,
                Email = request.Email,
                PhoneNumber = request.Phone
            };

            var identityResult = await _userManager.CreateAsync(user, request.Password);
            if (!identityResult.Succeeded) return BadRequest(identityResult.Errors);

            var addRoleResult = await _userManager.AddToRoleAsync(user, "user");
            if (!addRoleResult.Succeeded)
                return BadRequest(addRoleResult.Errors);

            var result = new RegisterUserResponse()
            {
                Email = user.Email,
                Phone = user.PhoneNumber
            };
            result.Role = "user";
            return Ok(result);
        }
    }
}