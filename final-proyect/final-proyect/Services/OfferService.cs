using final_proyect.Data;
using final_proyect.Interfaces;
using final_proyect.Observer;
using final_proyect_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace final_proyect.Services
{
    public class OfferService : IOfferService
    {

        private readonly ApplicationDbContext _context;
        private readonly IUserService _userService;


        public OfferService(ApplicationDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;


        }
        public int CreateOffers(Offers offer)
        {
            try
            {
                offer.OfferState = true;
                _context.Add(offer);
                _context.SaveChanges();
                return offer.OfferId;
            }
            catch 
            {
                Console.WriteLine("Error al crear la oferta laboral");
                throw;
            }
        }
        public List<Offers> GetOffers()
        {
            return _context.Offers.Where(u => u.OfferState == true).ToList();
        }


        public IEnumerable<object> GetAllOffersAndEnterprises()
        {
            var offers = _context.Offers.ToList();
            var offersWithEnterprises = new List<object>();

            foreach (var offer in offers)
            {
                var enterprise = _userService.GetEnterpriseById(offer.UserId);
                var offerWithEnterprise = new
                {
                    offer.OfferId,
                    offer.Tittle,
                    offer.About,
                    offer.PublishedDate,
                    offer.FinishDate,
                    offer.From,
                    offer.Location,
                    offer.Sector,
                    offer.SkillsRequired,
                    offer.InmediteIncorporation,
                    offer.Intern,
                    offer.CareerMinimumAge,
                    offer.CareersInterested,
                    offer.InternTime,
                    offer.IsPaid,
                    offer.OfferState,
                    Enterprise = enterprise
                };
                offersWithEnterprises.Add(offerWithEnterprise);
            }

            return offersWithEnterprises;
        }



        public bool DeleteOfferById(int OfferId)
        {
            try
            {
                var offerToDelete = _context.Offers.FirstOrDefault(o => o.OfferId == OfferId);

                if (offerToDelete != null)
                {
                    _context.Offers.Remove(offerToDelete);
                    _context.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine($"Error al eliminar oferta laboral: {ex.Message}");
                throw;
            }
        }


        public List<Offers> GetOffersByEnterprise(int enterpriseId)
        {
            return _context.Offers.Where(e => e.UserId == enterpriseId).ToList();
        }

        public Offers GetOffersById(int offerId)
        {
            return _context.Offers.FirstOrDefault(s => s.OfferId == offerId );
        }

        public bool ChangeStateOffer(int ofertaId)
        {
            var oferta = _context.Offers.FirstOrDefault(o => o.OfferId == ofertaId);

            if (oferta != null) 
            {
                oferta.OfferState = !oferta.OfferState;
                _context.SaveChanges();

                Console.WriteLine($"El estado de la oferta ID:{ofertaId} ahora es{oferta.OfferState}");
                return true;
            }
            else
            {
                Console.WriteLine($"No existe una oferta con la ID:{ofertaId}");
                return false;
            }
   
        }





            /*public void DeleteOffers()
            {
                var allOffers = _context.Offers.ToList();
                _context.Offers.RemoveRange(allOffers);
                _context.SaveChanges();
            }*/

        }
}
