using final_proyect_backend.Models;

namespace final_proyect.Interfaces
{
    public interface IApplicationServices
    {
        public bool ApplyForAnOffer(int studentId, int offerId);
        public List<Applications> GetApplications();

        public List<Applications> GetApplicationsByStudentId(int studentId);
        public List<Applications> GetApplicationsByOfferId(int offerId);


    }
}
