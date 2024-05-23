using final_proyect.Interfaces;
using final_proyect.Models.DTO;
using final_proyect.Services;
using final_proyect_backend.Models;
using Microsoft.AspNetCore.Mvc;
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

        [HttpPost("NewEnterprise")]
        public ActionResult<int> CreateEnterprise([FromBody] Enterprises enterprise)
        {
            try
            {
                var enterpriseId = _userService.CreateEnterprise(enterprise);
                return Ok(enterprise);
            }
            catch 
            {
                Console.WriteLine($"Error al crear la empresa");
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
