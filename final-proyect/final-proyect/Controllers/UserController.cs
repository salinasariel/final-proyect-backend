using final_proyect.Interfaces;
using final_proyect.Models.Dto;
using final_proyect.Models.DTO;
using final_proyect.Services;
using final_proyect_backend.Models;
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


        public UserController(IUserService userService, EmailService emailService)
        {
            _userService = userService;
            _emailService = emailService;
        }
        
        // ESTUDIANTES

        [HttpGet("GetAllStudents")]
        public ActionResult<List<Students>> GetStudents()
        {
            try
            {
                var students = _userService.GetStudents();
                return Ok(students);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al obtener estudiantes");
                return StatusCode(500);
            }
        }

        [HttpPost("CreateStudents")]
        public ActionResult<int> CreateStudent([FromBody] Students student)
        {
            try
            {
                var studentId = _userService.CreateStudent(student);
                var email = student.Email;
                var name = student.Name;
                int StudentNumber = student.FileNumber;
                    

                _emailService.SendInitialEmailStudent(email, name, StudentNumber);
                return Ok($"Estudiande ID:{studentId} creado correctamente ");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear estudiante: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
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

        [HttpPut("UpdateStudent/{userId}")]
        public IActionResult UpdateStudent(int userId, Students student)
        {
            if (userId != student.UserId)
            {
                return BadRequest();
            }

            var existingStudent = _userService.GetStudentById(userId);
            if (existingStudent == null)
            {
                return NotFound();
            }

            try
            {
                _userService.UpdateStudent(student);
                return NoContent();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al actualizar estudiante: {ex.Message}");
                return StatusCode(500);
            }
        }

        [HttpDelete("DeleteStudent/{userId}")]

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

        // EMPRESAS

        [HttpPost("CreateEnterprise")]
        public ActionResult<int> CreateEnterprise([FromBody] RegisterEnterpriseDTO dto)
        {
            Enterprises enterprise = new Enterprises()
            {
                Email = dto.Email,
                Password = dto.Password,
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

        // UPDATE EMPRESA

        [HttpPut("UpdateEnterprise/{userId}")]
        public ActionResult UpdateEnterprise(int userId, [FromBody] UpdateEnterpriseDTO dto)
        {
            try
            {
                var enterprise = _userService.GetEnterpriseById(userId);

                if (enterprise == null)
                {
                    throw new Exception("Empresa no encontrada");
                }
                enterprise.Email = dto.Email ?? enterprise.Email;
                enterprise.Password = dto.Password ?? enterprise.Password;
                enterprise.Name = dto.Name ?? enterprise.Name;

                enterprise.City = dto.City ?? enterprise.City;
                enterprise.WebPage = dto.WebPage ?? enterprise.WebPage;
                enterprise.AboutCompany = dto.AboutCompany ?? enterprise.AboutCompany;
                enterprise.LegalAbout = dto.LegalAbout ?? enterprise.LegalAbout;
                enterprise.CompanyAbout = dto.CompanyAbout ?? enterprise.CompanyAbout;
                enterprise.ContactName = dto.ContactName ?? enterprise.ContactName;
                enterprise.ContactEmail = dto.ContactEmail ?? enterprise.ContactEmail;
                enterprise.ContactPhone = dto.ContactPhone ?? enterprise.ContactPhone;
                enterprise.EnterpriseType = dto.EnterpriseType ?? enterprise.EnterpriseType;
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



        [HttpGet("GetAllEnterprisesAviables")]
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

        [HttpGet("GetAllEnterprises")]
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

        [HttpDelete("DeleteEnterprise/{userId}")]

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


        


    }
}
