using final_proyect.Data;
using final_proyect.Interfaces;
using final_proyect.Models;
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
                student.About = "Completa tu perfil";
                student.Rol = Models.UsersRoleEnum.Student;
                student.UserState = false;
                student.ProfilePhoto = "/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAMCAgMCAgMDAwMEAwMEBQgFBQQEBQoHBwYIDAoMDAsKCwsNDhIQDQ4RDgsLEBYQERMUFRUVDA8XGBYUGBIUFRT/2wBDAQMEBAUEBQkFBQkUDQsNFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBT/wAARCAEHAQcDASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD9K6KKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAoooo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";
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

        // - DAR DE ALTA ESTUDIANTE -------------------------------------------------------------------------------------

        public int ChangeStateStudent(int userId)
        {
            var student = _context.Students.FirstOrDefault(s => s.UserId == userId && s.Rol == Models.UsersRoleEnum.Student);

            if (student == null)
            {
                throw new Exception("El studiante a dar de alta no puede ser null");
            }

            else
            {
                student.UserState = !student.UserState;
            }

            _context.SaveChanges();
            return (userId);

        }


        // - OBTENER LISTA DE ESTUDIANTES ----------------------------------------------
        public List<Students> GetStudents()
                {
                    return _context.Students.Where(u => u.Rol == Models.UsersRoleEnum.Student).ToList();
                }

        // - Obtener Lista de estudiantes TRUE -----------------------------------------

        public List<Students> GetStudentsTrue()
        {
            return _context.Students.Where(u => u.Rol == Models.UsersRoleEnum.Student && u.UserState == true).ToList();
        }


        // EDITAR ESTUDIANTE
        public void UpdateStudent(Students studentToUpdate)
        {
            if (studentToUpdate == null)
            {
                throw new Exception("Estudiante a actualizar no puede ser null");
            }

            var studentExist = _context.Students.FirstOrDefault(e => e.UserId == studentToUpdate.UserId && e.Rol == UsersRoleEnum.Student);

            if (studentExist == null)
            {
                throw new Exception("Estudiante no encontrado");
            }

            _context.Entry(studentExist).CurrentValues.SetValues(studentToUpdate);
            _context.SaveChanges();
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

        public Enterprises GetEnterpriseById(int userId)
        {
            return _context.Enterprises.FirstOrDefault(s => s.UserId == userId && s.Rol == Models.UsersRoleEnum.Enterprise);
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
                enterprise.About = "Completa tu perfil";
                enterprise.UserState = false;
                enterprise.Rol = Models.UsersRoleEnum.Enterprise;
                enterprise.ProfilePhoto = "/9j/4AAQSkZJRgABAQEAYABgAAD/2wBDAAMCAgMCAgMDAwMEAwMEBQgFBQQEBQoHBwYIDAoMDAsKCwsNDhIQDQ4RDgsLEBYQERMUFRUVDA8XGBYUGBIUFRT/2wBDAQMEBAUEBQkFBQkUDQsNFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBQUFBT/wAARCAEFAUADASIAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/9oADAMBAAIRAxEAPwD9U6KKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigBKPxr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qkZ3RvxnPAr2/wD4dU/Bz/oJeLP/AAYQf/GKP+HVPwd/6Cfiz/wYQf8Axij2lDl5NbD9nX5ufS58y/8ABQr9pzwB+0NpfgiHwXqVzfvpc1210J7OWDaJBCFxvUZ+43Svdv2b/wBvj4O/Dn4E+B/DGu63fW2saVpkVrdRR6ZPIquo5AZVIP4Guk/4dU/B3/oJ+LP/AAYQf/GKP+HVPwc/6CXiz/wYQf8AxihzoOChrZCVOupOel2dJ/w8s+BH/Qxaj/4J7n/4ij/h5Z8CP+hi1H/wT3P/AMRXN/8ADqn4Of8AQS8Wf+DCD/4xR/w6p+Dn/QS8Wf8Agwg/+MVn/s/maf7R5Hyz/wAFDv2lfAf7Q3/CCf8ACFajcagNJ+2/bBPZywbfN8jZjeoz/q26V+kf7L3/ACbf8L/+xa0//wBJ0rwL/h1T8Hf+gl4s/wDBhB/8Yr6w8C+EbL4f+C9C8Maa0z6do9lDYWzXDBpDHEgRdxAAJwozgCipUpumoQ6DpQmqjnPqblFFFch1hRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAFFFFABRRRQAUUUUAJRilooAKKKKACiiigAooooAKKKKACiiigAooooATaKWiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigAooooAKKKKACiiigD//2Q==";
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


        // - EDITAR EMPRESA -----------------------------------------------------------------------------------------

        public void UpdateEnterprise(Enterprises enterpriseToUpdate)
        {
            if (enterpriseToUpdate == null)
            {
                throw new Exception("La empresa a actualizar no puede ser null");
            }

            var enterpriseExist = _context.Enterprises.FirstOrDefault(e => e.UserId == enterpriseToUpdate.UserId && e.Rol == UsersRoleEnum.Enterprise);

            if (enterpriseExist == null)
            {
                throw new Exception("Empresa no encontrada");
            }

            _context.Entry(enterpriseExist).CurrentValues.SetValues(enterpriseToUpdate);
            _context.SaveChanges();
        }

        // - DAR DE ALTA EMPRESA -------------------------------------------------------------------------------------

        public int ChangeStateEnterprise(int  userId)
        {
           var enterprise = _context.Enterprises.FirstOrDefault(s => s.UserId == userId && s.Rol == Models.UsersRoleEnum.Enterprise);

            if (enterprise == null)
            {
                throw new Exception("La empresa a dar de alta no puede ser null");
            }

            else
            {
                enterprise.UserState = !enterprise.UserState;
            }

            _context.SaveChanges();
            return (userId);        

        }


        // - OBTENER LISTA DE EMPRESAS HABILITADAS -----------------------------------------A--------------------------------
        public List<Enterprises> GetEnterprisesAviables()
        {
            return _context.Enterprises.Where(u => u.Rol == Models.UsersRoleEnum.Enterprise && u.UserState == true).ToList();
        }

        // - OBTENER LISTA DE EMPRESAS -------------------------------------------------------------------------------------
        
        public List<Enterprises> GetAllEnterprises() 
        {
            return _context.Enterprises.Where( u => u.Rol == Models.UsersRoleEnum.Enterprise ).ToList();
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
        public bool UpdateProfilePhoto(int userId, UpdateProfilePhotoDto dto)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == userId);
            if (user == null)
            {
                return false;
            }

            user.ProfilePhoto = dto.ProfilePhoto;
            _context.SaveChanges();

            return true;
        }


    }
}
