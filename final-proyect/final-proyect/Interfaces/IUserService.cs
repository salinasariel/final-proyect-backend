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
        List<Users> GetAllUsers();
        int CreateAdmin(Admins admin);
        public Students? GetStudentById(int userId);
        public void UpdateStudent(Students student);
    }
}
