using final_proyect_backend.Models;

namespace final_proyect.Interfaces
{
    public interface IOfferService
    {
        int CreateOffers(Offers offer);
        List<Offers> GetOffers();
        public void DeleteOffers();
    }
}
