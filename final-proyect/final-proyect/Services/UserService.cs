using final_proyect.Data;
using final_proyect.Interfaces;
using final_proyect_backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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
        //ESTUDIANTES
        public int CreateStudent(Students student)
        {
            try
            {
                student.Rol = 3;
                _context.Add(student);
                _context.SaveChanges();
                return student.UserId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al crear estudiante");
                throw;
            }
        }

        public List<Students> GetStudents()
        {
            return _context.Students.Where(u => u.Rol == 3).ToList();
        }

        public Students GetStudentById(int userId)
        {
            return _context.Students.FirstOrDefault(s => s.UserId == userId && s.Rol == 3);
        }

        public void UpdateStudent(Students student)
        {
            var existingStudent = _context.Students.FirstOrDefault(s => s.UserId == student.UserId && s.Rol == 3);
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

            public bool DeleteStudentById(int userId)
        {
            try
            {
                var studentToDelete = _context.Students.FirstOrDefault(s => s.UserId == userId && s.Rol == 3);

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

        //EMPRESAS

        public int CreateEnterprise(Enterprises enterprise)
        {
            try
            {
                enterprise.UserState = false;
                enterprise.Rol = 2;
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
        public List<Enterprises> GetEnterprisesAviables()
        {
            return _context.Enterprises.Where(u => u.Rol == 2 && u.UserState == true).ToList();
        }

        public bool DeleteEnterpriseById(int userId)
        {
            try
            {
                var enterpriseToDelete = _context.Enterprises.FirstOrDefault(e => e.UserId == userId && e.Rol == 2);

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

        //ADMINS

        public int CreateAdmin(Admins admin)
        {
            try
            {
                admin.Rol = 1;
                _context.Add(admin);
                _context.SaveChanges();
                return admin.UserId;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear admin: {ex.Message}");
                throw;
            }
        }

        //Usuarios

        public List<Users> GetAllUsers()
        {
            return _context.Users.Where(u => u.Rol == 3 || u.Rol == 2 || u.Rol == 1 ).ToList();

        }
    }
}
