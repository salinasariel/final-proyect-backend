using final_proyect.Interfaces;
using final_proyect.Services;
using final_proyect_backend.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace final_proyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersCotroller : ControllerBase
    {
        private readonly IOfferService _offerService;

        public OffersCotroller(IOfferService offerService)
        {
            _offerService = offerService;
        }
        [HttpPost("NewOffer")]
        public ActionResult<int> CreateOffer([FromBody] Offers offer)
        {
            try
            {
                var offerId = _offerService.CreateOffers(offer);
                return Ok(offerId);
            }
            catch 
            {
                Console.WriteLine("Error al crear la oferta");
                return StatusCode(500);
            }
        }

        [HttpGet("GetAllOffers")]
        public ActionResult<List<Students>> GetStudents()
        {
            try
            {
                var offers = _offerService.GetOffers();
                return Ok(offers);
            }
            catch 
            {
                Console.WriteLine("Error al obtener las ofertas");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteOffer/{OfferId}")]
        public IActionResult DeleteOffer(int OfferId)
        {
            try
            {
                var result = _offerService.DeleteOfferById(OfferId);

                if (result)
                {
                    return Ok("Oferta laboral eliminada correctamente");
                }
                else
                {
                    return NotFound("Oferta laboral no encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar oferta laboral: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        

    }
}
