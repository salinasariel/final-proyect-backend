using final_proyect.HashData;
using final_proyect.Interfaces;
using final_proyect.Models.Dto;
using final_proyect_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace final_proyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IHashData _hashData;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("createAdmin")]
        [Authorize(Policy = "Admin")]
        public ActionResult<int> CreateAdmin([FromBody] CreateAdminDTO dto)
        {
            var passwordHash = _hashData.DataHasher(dto.PasswordHash);

            Admins admin = new Admins()
            {
                Email = dto.Email,
                Name = dto.Name,
                About = dto.About,
                PasswordHash = passwordHash,
            };

            try
            {
                var idAdmin = _userService.CreateAdmin(admin);
                return Ok(admin.UserId);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500);
            }
        }

    }
}
