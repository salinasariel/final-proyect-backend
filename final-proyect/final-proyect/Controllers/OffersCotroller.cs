using final_proyect.Interfaces;
using final_proyect.Services;
using final_proyect_backend.Models;
using Microsoft.AspNetCore.Authorization;
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
        private readonly IApplicationServices _applicationServices;
        private readonly IUserService _userService;

        public OffersCotroller(IOfferService offerService, IApplicationServices applicationServices, IUserService userService)
        {
            _offerService = offerService;
            _applicationServices = applicationServices;
            _userService = userService;
        }

        [Authorize(Policy = "Enterprise")]
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

        [HttpGet("GetAllOffersWithEnterprise")]
        public ActionResult<IEnumerable<object>> GetAllOffers()
        {
            var offers = _offerService.GetAllOffersAndEnterprises();
            return Ok(offers);
        }

        [Authorize(Policy = "AdminOrEnterprise")]
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



        [HttpGet("GetOffersByEnterprise")]

        public IActionResult GetOffersByEnterprise(int enterpriseId)
        {
            try
            {
                var result = _offerService.GetOffersByEnterprise(enterpriseId);

                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound($"La empresa con ID:{enterpriseId} no posee ninguna oferta.");
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine($"Error al listar las ofertas: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");

            }
         
        }


        [HttpGet("GetOfferById")]
        public ActionResult<Offers> GetOffersById(int offerId)
        {
            var offert = _offerService.GetOffersById(offerId);
            if (offert == null)
            {
                return BadRequest("No existe oferta con esa ID");
            }
            return Ok(offert);
        }


        [Authorize(Policy = "Admin")]
        [HttpPost("ChangeStateOffer")]
        public IActionResult ChangeStateOffer(int ofertaId)
        {
            var result = _offerService.ChangeStateOffer(ofertaId);

            if (result)
            {
                return Ok($"El estado de la oferta {ofertaId} ha cambiado exitosamente.");
            }
            else
            {
                return NotFound($"No existe una oferta con la ID {ofertaId}");
            }
        }


        [HttpGet("GetOfferByStudent")]
        public ActionResult<object> GetOfferAndEnterpriseByStudent(int studentId)
        {
            try
            {
                var aplicacionesEstudiante = _applicationServices.GetApplicationsByStudentId(studentId);
                var ofertasConEmpresas = new List<object>();

                foreach (var aplicacion in aplicacionesEstudiante)
                {
                    var offer = _offerService.GetOffersById(aplicacion.OfferId);
                    var enterprise = _userService.GetEnterpriseById(offer.UserId);

                    var ofertaConEmpresa = new
                    {
                        Offers = offer,
                        Enterprise = enterprise
                    };

                    ofertasConEmpresas.Add(ofertaConEmpresa);
                }

                return Ok(ofertasConEmpresas);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return BadRequest();
            }
        }


    }
}
