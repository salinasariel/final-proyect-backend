using final_proyect.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace final_proyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

    }
}
