using Delete.Models;
using Delete.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Delete.API.Controllers
{
    public class StudentController : BaseApiController
    {
        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        
        [HttpGet]
        [Route("GetStudents")]
        [Produces(typeof(IEnumerable<Student>))]
        public async Task<IActionResult> GetStudents()
        {
            return Ok(await _studentService.GetStudentsAsync());
        }


        [HttpGet]
        [Route("GetById/{id}")]
        [Produces(typeof(Student))]
        public IActionResult GetStudentById(int id)
        {
            var student = _studentService.GetStudentById(id);

            if (student != null)
                return Ok(student);

            return NotFound();
        }

        [HttpPost]
        [Route("Add")]
        [Produces(typeof(Student))]
        public IActionResult AddStudent(Student student)
        {
            return Ok(_studentService.AddStudent(student));
        }

        [HttpPut]
        [Route("Update")]
        [Produces(typeof(Student))]
        public IActionResult UpdateStudent(Student student)
        {
            var _student = _studentService.GetStudentById(student.Id);

            if (_student != null)
                return Ok(_studentService.UpdateStudent(student));

            return BadRequest();
        }

        [HttpDelete]
        [Route("Delete")]
        [Produces(typeof(Student))]
        public bool DeleteStudent(int id)
        {
            var isDeleted = _studentService.DeleteStudent(id);

            return isDeleted;
        }
    }
}
