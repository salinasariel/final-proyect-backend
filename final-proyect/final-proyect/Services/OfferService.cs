﻿using final_proyect.Data;
using final_proyect.Interfaces;
using final_proyect_backend.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace final_proyect.Services
{
    public class OfferService : IOfferService
    {

        private readonly ApplicationDbContext _context;

        public OfferService(ApplicationDbContext context)
        {
            _context = context;
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

        /*public void DeleteOffers()
        {
            var allOffers = _context.Offers.ToList();
            _context.Offers.RemoveRange(allOffers);
            _context.SaveChanges();
        }*/

    }
}
