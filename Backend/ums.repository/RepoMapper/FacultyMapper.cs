using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ums.Model;
using UniversityApp.Entities;

namespace Ums.Repository.RepoMapper
{
    public static class FacultyMapper
    {
        public static FacultyEntity asEntity(this FacultyModel faculty)
        {
            return new FacultyEntity()
            {
                Address = faculty.Address,
                FacultyName = faculty.FacultyName,
                FacultyFname = faculty.FacultyFname,
                EmpId = faculty.EmpId,
                Department = faculty.Department,
                Education = faculty.Education,
                Dob = faculty.Dob,
                Email = faculty.Email,
                Phone = faculty.Phone,
            };
        }
        public static FacultyModel AsModel(this FacultyEntity teach)
        {
            return new FacultyModel()
            {
                Address = teach.Address,
                FacultyName = teach.FacultyName,
                FacultyFname = teach.FacultyFname,
                EmpId = teach.EmpId,
                Department = teach.Department,
                Education = teach.Education,
                Dob = teach.Dob,
                Email = teach.Email,
                Phone = teach.Phone,
            };
        }

    }
}

