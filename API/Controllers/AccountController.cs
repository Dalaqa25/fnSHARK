using API.Dtos;
using API.Dtos.RegisterDto;
using API.Interface;
using API.Models;
using API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [Route("API/register")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenInterface _tokenService;
        private readonly SignInManager<AppUser> _signInManager;
        public AccountController(UserManager<AppUser> userManager, ITokenInterface tokenService, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _signInManager = signInManager;
        }

        
        //HttpPost for Login
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userCheck = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == loginDto.UserName.ToLower());
            if (userCheck == null) return Unauthorized("Invalid Username!");

            var passwordCheck = await _signInManager.CheckPasswordSignInAsync(userCheck, loginDto.Password, false);
            if (!passwordCheck.Succeeded) return Unauthorized("UserName not found or/and password!");

            return Ok(
                new NewUserDto()
                {
                    UserName = userCheck.UserName,
                    Email = userCheck.Email,
                    Token = _tokenService.CreateToken(userCheck)
                }
            );
        }
        
        

        //HttpPost for Registration
        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var appUser = new AppUser
                {
                    UserName = registerDto.UserName,
                    Email = registerDto.Email,
                };

                if (registerDto.Password == null)
                {
                    return BadRequest("Password is required.");
                }

                var createdUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createdUser.Succeeded)
                {
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {
                        return Ok("Congratulations! User Created");
                    }
                    else
                    {
                        return BadRequest(roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createdUser.Errors);
                }
            }
            catch (Exception e)
            {
                
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
