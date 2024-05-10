using final_proyect.Interfaces;
using final_proyect.Models.Auth;
using final_proyect.Models.DTO;
using final_proyect_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;

namespace final_proyect.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;

        public AuthController(IConfiguration config, IUserService userService) 
        {
            _config = config;
            _userService = userService;
        }

        [HttpPost("Login")]
        public IActionResult Login([FromBody] CredentialsDTO credentials)
        {
            LoginResult loginResult = _userService.Login(credentials.Mail, credentials.Password);

            if (loginResult.Message == "mail incorrecto")
            {
                return BadRequest(loginResult.Message);
            }
            else if (loginResult.Message == "password incorrecto")
            {
                return BadRequest(loginResult.Message);
            }

            if (loginResult.Success)
            {
                Users user = _userService.GetUserByEmail(credentials.Mail);

                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:Key"]));

                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("email", user.Email));
                claimsForToken.Add(new Claim("userid", user.UserId.ToString()));


                var jwtSecurityToken = new JwtSecurityToken(
                   _config["Authentication:Issuer"],
                   _config["Authentication:Audience"],
                   claimsForToken,
                   DateTime.UtcNow,
                   DateTime.UtcNow.AddHours(1));
                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return Ok(tokenToReturn);
            }
            else { return BadRequest(); }

        }
       
     
    }
}
