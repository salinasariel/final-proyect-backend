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
    }
}
