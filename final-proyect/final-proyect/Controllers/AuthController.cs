using final_proyect.Interfaces;
using final_proyect.Models.Auth;
using final_proyect.Models.DTO;
using final_proyect_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Security.Cryptography.Xml;
using System.Text;

namespace final_proyect.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IUserService _userService;
        private readonly IAuthServices _authService;

        public AuthController(IConfiguration config, IUserService userService, IAuthServices authService) 
        {
            _config = config;
            _userService = userService;
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] CredentialsDTO dto)
        {
            LoginResult loginResult = _authService.Login(dto);
            if (loginResult.Message == "Email incorrecto")
            {
                return NotFound("Email incorrecto");
            }
            else if (loginResult.Message == "Contraseña incorrecta")
            {
                return Unauthorized("Contraseña incorrecta");
            }

            if (loginResult.Success)
            {
                var user = _userService.GetUserByEmail(dto.Mail);

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Authentication:SecretForKey"]));
                var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claimsForToken = new List<Claim>
        {
            new Claim("email", user.Email),
            new Claim("userid", user.UserId.ToString()),
            new Claim("rol", user.Rol.ToString())
        };

                var jwtSecurityToken = new JwtSecurityToken(
                    _config["Authentication:Issuer"],
                    _config["Authentication:Audience"],
                    claimsForToken,
                    expires: DateTime.UtcNow.AddHours(1),
                    signingCredentials: credentials);

                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return Ok(tokenToReturn);
            }
            else
            {
                return BadRequest();
            }
        }




































    }


}

