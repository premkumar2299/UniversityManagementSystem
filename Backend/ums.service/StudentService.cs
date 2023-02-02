using Microsoft.EntityFrameworkCore;
using System.Net;
using ums.Model;
using ums.repository;
using Ums.Repository.RepoMapper;
using UniversityApp.Entities;

namespace ums.service
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repo;
        private readonly int _pageSize = 5;

        public StudentService(IStudentRepository repo)
        {
            _repo = repo;
        }

        public List<StudentModel> Get()
        {
            return _repo.Get();
        }

        public StudentModel GetStudById(int StudRoll)
        {
            return _repo.GetStudById(StudRoll);
        }

        public async Task<StudentModel?> InsertStud(StudentModel User)
        {
            return await _repo.InsertStud(User);
        }

        public StudentModel UpdateUser(int RollNum, StudentModel User)
        {
            return _repo.UpdateUser(RollNum, User);
        }

        public HttpStatusCode DeleteUser(int StudRoll)
        {
            return _repo.DeleteUser(StudRoll);

        }

        public PaginatorModel FilterStudents(int pageno)
        {
            return _repo.FilterStudents(pageno);
        }
        public  IEnumerable<StudentModel> SearchStudent(string Name)
        {
            IQueryable<StudentModel> query = _repo.Get().AsQueryable();
            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(a => a.StudName.Contains(Name));
            }
            return query.ToList();

        }
    } 
}
