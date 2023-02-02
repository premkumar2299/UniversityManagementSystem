using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ums.Model;
using ums.repository;

namespace ums.service
{
    public class FacultyService : IFacultyService
    {
        private readonly IFacultyRepository _repo;

        public FacultyService(IFacultyRepository repo)
        {
            _repo = repo;
        }

        public List<FacultyModel> GetAllFaculty()
        {
            return _repo.GetAllFaculty();
            
        }

        public FacultyModel GetFacultyById(int empId)
        {
            return _repo.GetFacultyById(empId);
        }

        public Task<FacultyModel> InsertFaculty(FacultyModel User)
        {
            return _repo.InsertFaculty(User);
        }

        public FacultyModel UpdateFaculty(int EmpId,FacultyModel User)
        {
            return _repo.UpdateFaculty(User);
        }

        public HttpStatusCode DeleteFaculty(int empId)
        {
            return _repo.DeleteFaculty(empId);
        }


        public FacultyPaginator FilterFaculty(int pageno)
        {
            return _repo.FilterFaculty(pageno);
        }


        public IEnumerable<FacultyModel> SearchFaculty(string Name)
        {
            IQueryable<FacultyModel> query = _repo.GetAllFaculty().AsQueryable();
            if (!string.IsNullOrEmpty(Name))
            {
                query = query.Where(a => a.FacultyName.Contains(Name));
            }
            return query.ToList();
        }
    }
}
