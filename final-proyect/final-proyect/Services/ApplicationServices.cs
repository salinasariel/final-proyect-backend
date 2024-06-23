using final_proyect.Data;
using final_proyect.Interfaces;
using final_proyect.Observer;
using final_proyect_backend.Models;

namespace final_proyect.Services
{
    public class ApplicationServices : IApplicationServices
    {
        private readonly ApplicationDbContext _context;
        private readonly OfferSubject _offerSubject;

        public ApplicationServices(ApplicationDbContext context, OfferSubject offerSubject)
        {
            _context = context;
            _offerSubject = offerSubject;
        }

// 1 - Postulado
// 2 - Visto
// 3 - En fase final
// 4 - Descartado
// 5 - Aplicacion cancelada por el estudiante

        public bool ApplyForAnOffer(int studentId, int offerId)
        {
            var student = _context.Students.SingleOrDefault( a => a.UserId == studentId);
            var offer = _context.Offers.SingleOrDefault( a => a.OfferId == offerId);

            if (student == null || offer == null) 
            {
                return false;
            }

            else
            {
                Applications application = new Applications
                {
                    OfferId = offerId,
                    UserId = studentId,
                    AplicationState = 1,

                };

                _context.Applications.Add(application);
                _context.SaveChanges();
                _offerSubject.Notify(offer, student);

                return true;
            }
        }

        public List<Applications> GetApplications() 
        {
            return _context.Applications.ToList();
        }

        public List<Applications> GetApplicationsByStudentId(int studentId)
        {
            return _context.Applications.Where(a => a.UserId == studentId).ToList();


        }

        public List<Applications> GetApplicationsByOfferId(int offerId)
        {
            return _context.Applications.Where(a => a.OfferId == offerId).ToList();
        }



    }
}
