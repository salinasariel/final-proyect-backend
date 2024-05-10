using final_proyect.Models.Auth;
using final_proyect_backend.Models;
using System.Collections.Generic;

namespace final_proyect.Interfaces
{
    public interface IUserService
    {
        int CreateStudent(Students student);
        List<Students> GetStudents();

        int CreateEnterprise(Enterprises enterprise);

        List<Enterprises> GetEnterprisesAviables();

        bool DeleteStudentById(int userId);
        bool DeleteEnterpriseById(int userId);

        public Students? GetStudentById(int userId);
        public void UpdateStudent(Students student);

        public LoginResult Login(string mail, string password);
        public Users? GetUserByEmail(string email);


    }
}
