using final_proyect.Data;
using final_proyect.Interfaces;
using final_proyect_backend.Models;

namespace final_proyect.Services
{
    public class ApplicationServices : IApplicationServices
    {
        private readonly ApplicationDbContext _context;

        public ApplicationServices(ApplicationDbContext context)
        {
            _context = context;
        }

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
