using ApiWebDesign.Data;
using ApiWebDesign.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace ApiWebDesign.Controllers
{
    [Route("api/Students")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public StudentsController(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        [HttpGet]
        [Route("get-students")]
        public IActionResult GetStudents()
        {
            var Students = _applicationDbContext.Students.ToList();
            var response = new ResponseModel<List<Student>>();
            response.StatusCode = HttpStatusCode.OK;
            response.Success = true;
            response.Message = "Successful";
            response.Data = Students;
            return Ok(response);
        }

        [HttpPost]
        [Route("create-students")]
        public IActionResult CreateStudents([FromBody] Student Model)
        {

            var response = new ResponseModel<Student>();
             if (!ModelState.IsValid)
            {
                response.StatusCode = HttpStatusCode.BadRequest;
                response.Success = false;
                response.Message = "please enter the required field";
                return BadRequest();
            }
            response.StatusCode = HttpStatusCode.OK;
            response.Success = true;
            response.Message = "Successful";
            _applicationDbContext.Students.Add(Model);
            _applicationDbContext.SaveChanges();
            response.Data = Model;
            return Ok(response);
        }

        [HttpGet]
        [Route("get-students-by-id/{id:int}")]
        public IActionResult GetStudentsById([FromRoute] int id)
        {
            var response = new ResponseModel<Student>();
            response.StatusCode = HttpStatusCode.OK;
            response.Success = true;
            response.Message = "Successful";
            var Student = _applicationDbContext.Students.Find(id);
           if(Student == null)
            {
                response.StatusCode = HttpStatusCode.NotFound;
                response.Success = false;
                response.Message = $"student id with '{id}' was not found";
                return NotFound(response);
            }
            response.Data = Student;
            return Ok(response);
        }
       
           
    }
}
