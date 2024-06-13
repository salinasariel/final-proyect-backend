﻿using final_proyect.Models;
using final_proyect.Models.Auth;
using final_proyect_backend.Models;
using System.Collections.Generic;

namespace final_proyect.Interfaces
{
    public interface IUserService
    {
        // Student Services
        int CreateStudent(Students student);
        List<Students> GetStudents();
        public List<Students> GetStudentsTrue();
        public int ChangeStateStudent(int userId);
        bool DeleteStudentById(int userId);
        public void UpdateStudent(Students studentToUpdate);
        public Students? GetStudentById(int userId);

        // Enterprise Services
        int CreateEnterprise(Enterprises enterprise);
        public int ChangeStateEnterprise(int userId);
        List<Enterprises> GetEnterprisesAviables();
        public List<Enterprises> GetAllEnterprises();
        public void UpdateEnterprise(Enterprises enterpriseToUpdate);
        public Enterprises GetEnterpriseById(int userId);
        bool DeleteEnterpriseById(int userId);

        // User Services
        public LoginResult Login(string mail, string password);
        public Users? GetUserByEmail(string email);
        public bool UpdateProfilePhoto(int userId, UpdateProfilePhotoDto dto);

    }
}
