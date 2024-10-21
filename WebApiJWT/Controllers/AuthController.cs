using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using WebApiJWT.Dtos;
using WebApiJWT.Jwt;
using WebApiJWT.Models;

//using WebApiJWT.Models;
using WebApiJWT.Services;

namespace WebApiJWT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUser _iuser;
        public AuthController(IUser iuser)
        {
            _iuser = iuser;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(WebApiJWT.Models.RegisterRequest request)
        {
            var newUserDto = new AddUserDto
            {
                Email= request.Email,
                Password= request.Password
            };

           var res = await _iuser.AddUser(newUserDto);
            if (res.IsSucceed)
            
                return Ok(newUserDto);
            else
            return BadRequest(res.Message);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login (WebApiJWT.Models.LoginRequest loginRequest)
        {
            var loginuserDto = new LoginUserDto
            {
                Email = loginRequest.Email,
                Password = loginRequest.Password,
            };
            var res = await _iuser.LoginUser(loginuserDto);
            if(!res.IsSucceed)
                return BadRequest(res.Message);
            var user = res.Data;

            var config = HttpContext.RequestServices.GetRequiredService<IConfiguration>();
            var token = JwtHelper.GenerateJwt(new JwtDto
            {
                Id = user.Id,
                Email = user.Email,
                UserType = user.UserType,
                SecretKey = config["Jwt:SecretKey"]!,
                Issuer = config["Jwt:Issuer"]!,
                Audience = config["Jwt:Audience"]!,
                ExpireMinutes = int.Parse(config["Jwt:ExpireMinutes"]!)

            });
            // return Ok(token);
            return Ok(new LoginResponse
            {
                Message = "giriş başarılı",
                Token = token
            });
        }
    }
}
