using Microsoft.AspNetCore.Mvc;

using final_proyect_backend.Models;
using System;
using System.Linq;
using final_proyect.Data;

namespace final_proyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DataController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public DataController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("users")]
        public IActionResult AddUser(Users user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok("User added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to add user: {ex.Message}");
            }
        }

        [HttpPost("offers")]
        public IActionResult AddOffer(Offers offer)
        {
            try
            {
                _context.Offers.Add(offer);
                _context.SaveChanges();
                return Ok("Offer added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to add offer: {ex.Message}");
            }
        }

        [HttpPost("applications")]
        public IActionResult AddApplication(Applications application)
        {
            try
            {
                // Check if user and offer exist before adding the application
                var existingUser = _context.Users.Any(u => u.UserId == application.UserId);
                var existingOffer = _context.Offers.Any(o => o.OfferId == application.OfferId);

                if (!existingUser || !existingOffer)
                {
                    return BadRequest("User or offer not found.");
                }

                _context.Applications.Add(application);
                _context.SaveChanges();
                return Ok("Application added successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to add application: {ex.Message}");
            }
        }
    }
}
