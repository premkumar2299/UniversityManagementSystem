using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ums.Model;
using Ums.Repository.RepoMapper;
using UniversityApp.Entities;

namespace ums.repository
{
    public class FacultyRepository : IFacultyRepository
    {
        private readonly umsdbContext dbContext;
        public FacultyRepository(umsdbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        
        public List<FacultyModel> GetAllFaculty()
        {

            var list = dbContext.TeacherInfos.Select(
             s => s.AsModel()
              ).ToList();

            if (list.Count() < 0)
            {
                return null;
            }
            else
            {
                return list;
            }
        }

        public FacultyModel GetFacultyById(int empId)
        {

            var faculty = dbContext.TeacherInfos.FirstOrDefault(s => s.EmpId == empId);
            if (faculty == null)
            {
                return null;
            }
            FacultyModel teach = faculty.AsModel();
            
            return teach;
        }

        public async Task<FacultyModel?> InsertFaculty(FacultyModel fa)
        {
            var ExistingFaculty = await dbContext.TeacherInfos.FirstOrDefaultAsync(f => f.EmpId == fa.EmpId);
            if (ExistingFaculty != null) return null;
            var entity = fa.asEntity();
            await dbContext.TeacherInfos.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return fa;  
        }

        public FacultyModel UpdateFaculty(FacultyModel User)
        {
            var entity = dbContext.TeacherInfos.FirstOrDefault(s => s.EmpId == User.EmpId);

            if (entity == null) { return null; }

            entity.EmpId = User.EmpId;
            entity.FacultyName = User.FacultyName;
            entity.FacultyFname = User.FacultyFname;
            entity.Address = User.Address;
            entity.Dob = User.Dob;
            entity.Phone = User.Phone;
            entity.Email = User.Email;
            entity.Education = User.Education;
            entity.Department = User.Department;

            dbContext.SaveChanges();
            return new FacultyModel
            {

                FacultyName = entity.FacultyName,
                EmpId = entity.EmpId,

            };
        }


     

        public HttpStatusCode DeleteFaculty(int empId)
        {
                
                var entity= dbContext.TeacherInfos.FirstOrDefault(e=>e.EmpId==empId);
                dbContext.TeacherInfos.Remove(entity);
                dbContext.SaveChanges();
                return HttpStatusCode.OK;
        }

        public FacultyPaginator FilterFaculty(int pageno)
        {
            if (dbContext.TeacherInfos == null)
            {
                return null;
            }
            var PageSize = 7f;
            var totalPages = Math.Ceiling(dbContext.TeacherInfos.Count() / PageSize);
            var totalElements = dbContext.TeacherInfos.Count();
            var data = dbContext.TeacherInfos.Select(
            s => s.AsModel()).ToList();
            data = data.OrderBy(g => g.EmpId).ToList();


            data = data.Skip((pageno - 1) * (int)PageSize).Take((int)PageSize).ToList();
            var response = new FacultyPaginator()
            {
                Faculty = data,
                totalElements = totalElements,
                totalPages = (int)totalPages,
                pageNumber = pageno,
            }; return response;
        }
    }
}
