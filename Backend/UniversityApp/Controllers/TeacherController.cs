using Microsoft.AspNetCore.Http;
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
    public class TeacherController : Controller
    {
        private readonly IFacultyService FacultyService;
        public TeacherController(IFacultyService facultyService)
        {
            this.FacultyService = facultyService;
        }

        [HttpGet]
        public async Task<ActionResult<List<FacultyViewDto>>> GetAllFaculty()
        {
            var facultyList = this.FacultyService.GetAllFaculty();
           

            var facultyViewListDTO = new List<FacultyViewDto>();
            facultyList.ForEach(s => facultyViewListDTO.Add(s.AsViewFDTO()));
            return Ok(facultyViewListDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<FacultyDto>> GetFacultyById(int id)
        {

            var faculty = this.FacultyService.GetFacultyById(id);
            if (faculty == null) return NotFound();
            Console.WriteLine("phone :"+faculty.Phone.ToString());
            return Ok(faculty.AsFDTO());
        }

        [HttpPost]
        public async Task<ActionResult<FacultyDto>> InsertFaculty(FacultyModel faculty)
        {
            var CreatedFaculty = (await this.FacultyService.InsertFaculty(faculty))?.AsFDTO();
            if (CreatedFaculty == null) return Conflict("Faculty with ID already Exists ");
            return Ok(CreatedFaculty);
        }

        [HttpPut]
        public async Task<FacultyDto> UpdateFaculty(int EmpId,FacultyDto faculty)
        {

            return this.FacultyService.UpdateFaculty(EmpId, faculty.AsFModel()).AsFDTO();
        }

        [HttpDelete("id")]
        public async Task<ActionResult> DeleteFaculty(int empId)
        {
            var s = this.FacultyService.GetFacultyById(empId);
            if (s == null)
            {
                return NotFound();
            }

            this.FacultyService.DeleteFaculty(empId);
            return NoContent();
        }

        [HttpGet("pagedfaculty")]
        public async Task<ActionResult<FacultyPaginator>> FacultyPaged(int pgno)
        {
            try
            {

                return Ok(FacultyService.FilterFaculty(pgno));

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpGet("Fsearch")]
        public ActionResult<IEnumerable<FacultyModel>> StudentSearch([FromQuery] string name)
        {
            try
            {

                var result = this.FacultyService.SearchFaculty(name);
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



