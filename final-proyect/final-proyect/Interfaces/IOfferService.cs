using final_proyect_backend.Models;

namespace final_proyect.Interfaces
{
    public interface IOfferService
    {
        int CreateOffers(Offers offer);
        List<Offers> GetOffers();
        bool DeleteOfferById(int OfferId);
        public List<Offers> GetOffersByEnterprise(int enterpriseId);
        public Offers GetOffersById(int offerId);
        public bool ChangeStateOffer(int ofertaId);
        public IEnumerable<object> GetAllOffersAndEnterprises();
        

        }
}
