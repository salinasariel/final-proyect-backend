using final_proyect.Data;
using final_proyect.Interfaces;
using final_proyect.Models.Auth;
using final_proyect_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace final_proyect.Services
{
    public class UserService : IUserService
    {

        // Admin Role = 1
        // Enterprise Role = 2
        // Students Role = 3

        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        // - INICIAR SESION ---------------------------------------------------------------------------
       
        public LoginResult Login(string mail, string password)
        {
            LoginResult result = new LoginResult();

            Users? usersLogin = _context.Users.SingleOrDefault(u => u.Email == mail);

            if (usersLogin == null)
            {
                throw new ArgumentNullException("mail o password no pueden ser nulos.");
            }

            else if (usersLogin != null)
            {
                if (usersLogin.Password == password)
                {
                    result.Success = true;
                    result.Message = "Login OK";
                }
                else
                {
                    result.Success = false;
                    result.Message = "password incorrecto";
                }
            }
            else
            {
                result.Success = false;
                result.Message = "mail incorrecto";
            }

            return result;
        }

        // - REGISTRO ESTUDIANTE -----------------------------------------------------------
        public int CreateStudent(Students student)
        {
            try
            {
                student.Rol = Models.UsersRoleEnum.Student;
                _context.Add(student);
                _context.SaveChanges();

                Console.WriteLine($"{student.Name} registrado exitosamente.");
                return student.UserId;
                
            }
            catch 
            {
                Console.WriteLine("Error al crear estudiante");
                throw;
            }
        }


        // - OBTENER LISTA DE ESTUDIANTES ----------------------------------------------
        public List<Students> GetStudents()
                {
                    return _context.Students.Where(u => u.Rol == Models.UsersRoleEnum.Student).ToList();
                }


        public void UpdateStudent(Students student)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.UserId == student.UserId && s.Rol == Models.UsersRoleEnum.Student);
            if (existingStudent != null)
            {
                existingStudent.Name = student.Name;
                existingStudent.Email = student.Email;
                existingStudent.Password = student.Password;
                existingStudent.PhoneNumber = student.PhoneNumber;
                existingStudent.City = student.City;
                existingStudent.Address = student.Address;
                existingStudent.BirthDate = student.BirthDate;
                existingStudent.Sex = student.Sex;
                existingStudent.CivilStatus = student.CivilStatus;
                existingStudent.Tittle = student.Tittle;
                existingStudent.FileNumber = student.FileNumber;
                existingStudent.CareerAge = student.CareerAge;
                existingStudent.EnglishLevel = student.EnglishLevel;
                existingStudent.CvFile = student.CvFile;
                existingStudent.HighSchoolFile = student.HighSchoolFile;
                existingStudent.CoursesFile = student.CoursesFile;

                _context.SaveChanges();
            }
            else
            {
                throw new Exception("Estudiante no encontrado.");
            }
        }

        // - OBTENER ESTUDIANTE POR MAIL ------------------------------------------------

        public Users? GetUserByEmail(string email)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email);
        }

        // - OBTENER ESTUDIANTE POR ID -------------------------------------------------

        public Students GetStudentById(int userId)
        {
            return _context.Students.FirstOrDefault(s => s.UserId == userId && s.Rol == Models.UsersRoleEnum.Student);
        }

        // - BORRAR ESTUDIANTE ----------------------------------------------------------

        public bool DeleteStudentById(int userId)
        {
            try
            {
                var studentToDelete = _context.Students.FirstOrDefault(s => s.UserId == userId && s.Rol == Models.UsersRoleEnum.Student);

                if (studentToDelete != null)
                {
                    _context.Students.Remove(studentToDelete);
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

                Console.WriteLine($"Error al eliminar estudiante: {ex.Message}");
                throw;
            }
        }

        // - CREAR EMPRESA -------------------------------------------------------------------------------------

        public int CreateEnterprise(Enterprises enterprise)
        {
            try
            {
                enterprise.UserState = false;
                enterprise.Rol = Models.UsersRoleEnum.Enterprise;
                _context.Add(enterprise);
                _context.SaveChanges();
                return enterprise.UserId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear la empresa");
                throw;
            }
        }

        // - OBTENER LISTA DE EMPRESAS -------------------------------------------------------------------------
        public List<Enterprises> GetEnterprisesAviables()
        {
            return _context.Enterprises.Where(u => u.Rol == Models.UsersRoleEnum.Enterprise && u.UserState == true).ToList();
        }

        // BORRAR EMPRESA --------------------------------------------------------------------------------------
        public bool DeleteEnterpriseById(int userId)
        {
            try
            {
                var enterpriseToDelete = _context.Enterprises.FirstOrDefault(e => e.UserId == userId && e.Rol == Models.UsersRoleEnum.Enterprise);

                if (enterpriseToDelete != null)
                {
                    _context.Enterprises.Remove(enterpriseToDelete);
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

                Console.WriteLine($"Error al eliminar empresa: {ex.Message}");
                throw;
            }

        }

       

    }
}
