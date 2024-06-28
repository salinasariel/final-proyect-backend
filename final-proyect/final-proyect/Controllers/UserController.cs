using final_proyect.HashData;
using final_proyect.Interfaces;
using final_proyect.Models;
using final_proyect.Models.Dto;
using final_proyect.Models.DTO;
using final_proyect.Services;
using final_proyect_backend.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace final_proyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly EmailService _emailService;
        private readonly IHashData _hashData;


        public UserController(IUserService userService, EmailService emailService, IHashData hashData)
        {
            _userService = userService;
            _emailService = emailService;
            _hashData = hashData;
        }

        
        [HttpGet("GetAllStudents")]
        [Authorize(Policy = "Admin")]
        public ActionResult<List<Students>> GetStudents()
        {
            try
            {
                var students = _userService.GetStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener estudiantes: {ex.Message}");
                return StatusCode(500);
            }
        }

        
        [HttpGet("GetStudentsById/{userId}")]
        public ActionResult<Students> GetStudentById(int userId)
        {
            var student = _userService.GetStudentById(userId);
            if (student == null)
            {
                return BadRequest("No existe estudiante con esa ID");
            }
            return Ok(student);
        }

        [HttpGet("GetByEmail")]
        public IActionResult GetStudentByEmail(string email) 
        {
            var user = _userService.GetUserByEmail(email);
            if (user == null)
            {
                return BadRequest();
            }
            return Ok(user);
        }

        [HttpGet("GetEnterpriseById/{userId}")]
        public ActionResult<Students> GetEnterpriseById(int userId)
        {
            var ent = _userService.GetEnterpriseById(userId);
            if (ent == null)
            {
                return BadRequest("No existe empresa con esa ID");
            }
            return Ok(ent);
        }

        [HttpGet("GetAllStudentsTRUE")]
        public ActionResult<List<Enterprises>> GetAllStudentsTrue()
        {
            try
            {
                var students = _userService.GetStudentsTrue();
                return Ok(students);
            }
            catch
            {
                Console.WriteLine($"Error al obtener los estudiantes");
                return StatusCode(500);
            }
        }

        

        [HttpPost("register_student")]
        public ActionResult<int> CreateStudent([FromBody] RegisterStudentDTO dto)
        {
            var passwordHash = _hashData.DataHasher(dto.Password);

            Students studentRegister = new Students()
            {
                Email = dto.Email,
                PasswordHash = passwordHash,
                FileNumber = dto.FileNumber,
                Name = dto.Name,
                Dni = dto.Dni,
          };

            try
            {
                var studentID = _userService.CreateStudent(studentRegister);

                _emailService.SendInitialEmailStudent(studentRegister.Email, studentRegister.Name, studentRegister.FileNumber);
                return Ok($"Estudiante {dto.Name} | Legajo: {dto.FileNumber}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear el estudiante: {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpPut("ChangeStateStudent/{userId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult ChangeStateStudent(int userId)
        {
            try
            {
                int result = _userService.ChangeStateStudent(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        
        [HttpPut("UpdateStudent/{userId}")]
        [Authorize(Policy = "Student")]
        public ActionResult UpdateStudent(int userId, [FromBody] UpdateStudentDTO dto)
        {
            try
            {
                var student = _userService.GetStudentById(userId);

                if (student == null)
                {
                    throw new Exception("Estudiante no encontrado");
                }

                student.Name = dto.Name ?? student.Name;
                student.About = dto.About ?? student.About;

                student.FileNumber = dto.FileNumber ?? student.FileNumber;
                student.Dni = dto.Dni ?? student.Dni;
                student.Cuil = dto.Cuil ?? student.Cuil;
                student.PhoneNumber = dto.PhoneNumber ?? student.PhoneNumber;
                student.City = dto.City ?? student.City;
                student.Address = dto.Address ?? student.Address;
                student.BirthDate = dto.BirthDate ?? student.BirthDate;
                student.Sex = dto.Sex ?? student.Sex;
                student.CivilStatus = dto.CivilStatus ?? student.CivilStatus;
                student.Tittle = dto.Tittle ?? student.Tittle;
                student.EnglishLevel = dto.EnglishLevel ?? student.EnglishLevel;
                student.Education = dto.Education ?? student.Education;
                student.Experience = dto.Experience ?? student.Experience;

                _userService.UpdateStudent(student);
                return Ok(student);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la empresa: {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteStudent/{userId}")]
        [Authorize(Policy = "Admin")]

        public ActionResult DeleteStudent(int userId)
        {
            try
            {
                var result = _userService.DeleteStudentById(userId);

                if (result)
                {
                    return Ok("Estudiante eliminado correctamente");
                }
                else
                {
                    return NotFound("Estudiante no encontrado");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar estudiante: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }


        [HttpGet("GetAllEnterprises")]
        [Authorize(Policy = "Admin")]
        public ActionResult<List<Enterprises>> GetAllEnterprises()
        {
            try
            {
                var enterprise = _userService.GetAllEnterprises();
                return Ok(enterprise);
            }
            catch
            {
                Console.WriteLine($"Error al obtener las empresas");
                return StatusCode(500);
            }
        }

        [HttpGet("GetAllEnterprisesAviables")]
        [Authorize(Policy = "Admin")]
        public ActionResult<List<Enterprises>> GetEnterprisesAviables()
        {
            try
            {
                var enterprise = _userService.GetEnterprisesAviables();
                return Ok(enterprise);
            }
            catch
            {
                Console.WriteLine($"Error al obtener las empresas");
                return StatusCode(500);
            }
        }

        [HttpPost("CreateEnterprise")]
        public ActionResult<int> CreateEnterprise([FromBody] RegisterEnterpriseDTO dto)
        {

            var passwordHash = _hashData.DataHasher(dto.Password);

            Enterprises enterprise = new Enterprises()
            {
                Email = dto.Email,
                PasswordHash = passwordHash,
                City = dto.City,
                Cuit = dto.Cuit,
                Name = dto.Name,
            };

            try
            {
                var enterpriseId = _userService.CreateEnterprise(enterprise);
                return Ok($"Empresa {dto.Name} | ID: {enterpriseId}");
            }
            catch
            {
                Console.WriteLine($"Error al crear la empresa");
                return StatusCode(500);
            }
        }

        [HttpPut("UpdateEnterprise/{userId}")]
        [Authorize(Policy = "Enterprise")]
        public ActionResult UpdateEnterprise(int userId, [FromBody] UpdateEnterpriseDTO dto)
        {
            try
            {
                var passwordHashdto = _hashData.DataHasher(dto.Password);
                var enterprise = _userService.GetEnterpriseById(userId);

                if (enterprise == null)
                {
                    throw new Exception("Empresa no encontrada");
                }
                enterprise.Email = dto.Email ?? enterprise.Email;
                enterprise.PasswordHash = passwordHashdto ?? enterprise.PasswordHash;
                enterprise.Name = dto.Name ?? enterprise.Name;
                enterprise.About = dto.About ?? enterprise.About;
                enterprise.City = dto.City ?? enterprise.City;
                enterprise.WebPage = dto.WebPage ?? enterprise.WebPage;
                enterprise.LegalAbout = dto.LegalAbout ?? enterprise.LegalAbout;
                enterprise.ContactName = dto.ContactName ?? enterprise.ContactName;
                enterprise.ContactEmail = dto.ContactEmail ?? enterprise.ContactEmail;
                enterprise.ContactPhone = dto.ContactPhone ?? enterprise.ContactPhone;
                enterprise.EmployeesQuantity = dto.EmployeesQuantity ?? enterprise.EmployeesQuantity;
                enterprise.Cuit = dto.Cuit ?? enterprise.Cuit;
                 
                _userService.UpdateEnterprise(enterprise);
                return Ok(enterprise);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar la empresa: {ex.Message}");
                return StatusCode(500);
            }
        }


        [HttpPut("ChangeStateEnterprise/{userId}")]
        [Authorize(Policy = "Admin")]
        public ActionResult ChangeUserState(int userId)
        {
            try
            {
                int result = _userService.ChangeStateEnterprise(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("DeleteEnterprise/{userId}")]
        [Authorize(Policy = "Admin")]

        public ActionResult DeleteEnterprise(int userId)
        {
            try
            {
                var result = _userService.DeleteEnterpriseById(userId);

                if (result)
                {
                    return Ok("Empresa eliminada correctamente");
                }
                else
                {
                    return NotFound("Empresa no encontrada");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar empresa: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPut("{userId}/profilePhoto")]
        public IActionResult UpdateProfilePhoto(int userId, [FromBody] UpdateProfilePhotoDto dto)
        {
            if (!_userService.UpdateProfilePhoto(userId, dto))
            {
                return NotFound(new { message = "Usuario no encontrado" });
            }

            return Ok(new { message = "Foto de perfil actualizada" });
        }

    }
}
