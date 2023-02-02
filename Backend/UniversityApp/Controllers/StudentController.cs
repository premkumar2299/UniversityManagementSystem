using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using ums.Model;
using ums.service;
using UniversityApp.Dto_s;
using UniversityApp.Entities;
using UniversityApp.Mappers;

namespace UMSapp.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : Controller
    {
        private readonly  IStudentService StudentService;
        public StudentController(IStudentService studentService)
        {
            this.StudentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult<List<StudentViewDto>>> Get()
        {
            var studentList = this.StudentService.Get();
            var studentViewListDTO = new List<StudentViewDto>();
            studentList.ForEach(s => studentViewListDTO.Add(s.AsViewDTO()));
            return Ok(studentViewListDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDTO>> GetStudById(int id)
        {
            var student = this.StudentService.GetStudById(id);
            if (student == null) return NotFound();
                return Ok(student.AsDTO());
        }

        [HttpPost]
        public async Task<ActionResult<StudentDTO>> InsertStud(StudentDTO student)
        {
            
            var CreatedStudent = (await this.StudentService.InsertStud(student.AsModel()))?.AsDTO();
            if (CreatedStudent == null) return Conflict("Student with ID already Exists ");
            return Ok(CreatedStudent);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateUser(int rollNum, StudentDTO Student)
        {
            var s = this.StudentService.GetStudById(rollNum);
            if(s== null)
            {
                return NotFound();
            }
            this.StudentService.UpdateUser(rollNum, Student.AsModel());
            return NoContent();
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteUser(int StudRoll)
        {
            var s = this.StudentService.GetStudById(StudRoll);
            if (s == null)
            {
                return NotFound();
            }
            
            this.StudentService.DeleteUser(StudRoll);
            return NoContent();
        }

        [HttpGet("pagedGet")]
        public async Task<ActionResult<PaginatorModel>> StudentPaged(int pgno)
        {
            try
            {
                
                return Ok(StudentService.FilterStudents(pgno));
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("search")]
        public ActionResult<IEnumerable<StudentModel>> StudentSearch([FromQuery] string name)
        {
            try
            {

               var result=  this.StudentService.SearchStudent(name);
                if (result.Any())
                {
                    return Ok(result);
                }
                return NotFound();

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
