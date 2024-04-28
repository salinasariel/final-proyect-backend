﻿using final_proyect.Data;
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
    }
}
