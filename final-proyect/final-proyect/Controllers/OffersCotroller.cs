using final_proyect.Interfaces;
using final_proyect.Services;
using final_proyect_backend.Models;
using Microsoft.AspNetCore.Mvc;
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
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la empresa");
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
            catch (Exception ex)
            {
                Console.WriteLine("Error al obtener las ofertas");
                return StatusCode(500);
            }
        }

    }
}
