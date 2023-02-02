using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ums.Model;
using Ums.Repository.RepoMapper;
using UniversityApp.Entities;

namespace ums.repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly umsdbContext dbContext;
        public StudentRepository(umsdbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        public List<StudentModel> Get()
        {
            var list = dbContext.StudInfos.Select(
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

        public StudentModel GetStudById(int StudRoll)
        {
            var stud = dbContext.StudInfos.FirstOrDefault(s => s.StudRoll == StudRoll);
            if (stud == null)
            {
                return null;
            }
            StudentModel student = stud.AsModel();
            return student;
        }

        public async Task<StudentModel?> InsertStud(StudentModel User)
        {
            var ExistingStudent = await dbContext.StudInfos.FirstOrDefaultAsync(s => s.StudRoll == User.StudRoll);
            if (ExistingStudent != null) return null;
            var entity = User.asEntity();
            await dbContext.StudInfos.AddAsync(entity);
            await dbContext.SaveChangesAsync();
            return User;
        }

        public StudentModel UpdateUser(int RollNum, StudentModel User)
        {
            var entity = dbContext.StudInfos.FirstOrDefault(s => s.StudRoll == RollNum);
            if (entity == null)
            {
                return null;
            }
            entity.StudRoll = User.StudRoll;
            entity.StudName = User.StudName;
            entity.StudFname = User.StudFname;
            entity.Address = User.Address;
            entity.Dob = User.Dob;
            entity.Phone = User.Phone;
            entity.Email = User.Email;
            entity.Course = User.Course;
            entity.Branch = User.Branch;

            dbContext.SaveChanges();
            return new StudentModel
            {
                StudName = entity.StudName,
                StudRoll = entity.StudRoll,
            };
        }


        public HttpStatusCode DeleteUser(int studRoll)
        {
            var entity = dbContext.StudInfos.FirstOrDefault(e => e.StudRoll == studRoll);
            dbContext.StudInfos.Remove(entity);
            dbContext.SaveChanges();
            return HttpStatusCode.OK;
        }

        public PaginatorModel FilterStudents(int pageno)
        {
            if (dbContext.StudInfos == null)
            {
                return null;
            }
            var PageSize = 7f;
            var totalPages = Math.Ceiling(dbContext.StudInfos.Count() / PageSize);
            var totalElements = dbContext.StudInfos.Count();
            var data = dbContext.StudInfos.Select(
            s => s.AsModel()).ToList();
            data = data.OrderBy(g => g.StudRoll).ToList();


            data = data.Skip((pageno - 1) * (int)PageSize).Take((int)PageSize).ToList();
            var response = new PaginatorModel()
            {
                students = data,
                totalElements = totalElements,
                totalPages = (int)totalPages,
                pageNumber = pageno,
            }; return response;
        }
    }
}

   


