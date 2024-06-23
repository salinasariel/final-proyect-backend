using final_proyect.Interfaces;
using final_proyect.Services;
using final_proyect_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace final_proyect.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : ControllerBase
    {
        private readonly IApplicationServices _services;

        public ApplicationController(IApplicationServices services) 
        {
            _services = services;
        }

        [Authorize(Policy = "Student")]
        [HttpPost("ApplyForAnOffer")]
        public IActionResult ApplyForAnOffer([FromBody] Applications application)
        {
            var applyOffer = _services.ApplyForAnOffer(application.UserId, application.OfferId);

            if (applyOffer)
            {
                Console.WriteLine($"Estudiante ID:{application.UserId} postulado a Oferta ID: {application.OfferId} | IDpost: {application.ApplicationID}");
                return Ok(application);
            }
            else 
            {
                return BadRequest();
            }
        }

        [HttpGet("GetAllApplications")]
        public ActionResult <List<Applications>> GetAllApplications()
        {
            try
            {
                var appl = _services.GetApplications();
                return Ok(appl);
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }
        }

        [Authorize(Policy = "Student")]
        [HttpGet("GetApplicationsByStudentID")]
        public ActionResult <List<Applications>> GetApplicationsByStudentID(int studentId)
        {
            try
            {
                var applS = _services.GetApplicationsByStudentId(studentId);
                return Ok(applS);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }
        }



        [HttpGet("GetApplicationsByOfferID")]
        public ActionResult<List<Applications>> GetApplicationsByOfferID(int offerId)
        {
            try
            {
                var applO = _services.GetApplicationsByOfferId(offerId);
                return Ok(applO);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }
        }






    }
}
