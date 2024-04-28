﻿using final_proyect.Interfaces;
using final_proyect_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace final_proyect.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
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

        [HttpPost("NewStudents")]
        public ActionResult<int> CreateStudent([FromBody] Students student)
        {
            try
            {
                var studentId = _userService.CreateStudent(student);
                return Ok(studentId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al crear estudiante: {ex.Message}");
                return StatusCode(500, "Error interno del servidor");
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
            catch (Exception ex)
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
            catch (Exception ex)
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

        /*[HttpPost("NewOffer")]
        public ActionResult<int> CreateOffer*/
    }
}
