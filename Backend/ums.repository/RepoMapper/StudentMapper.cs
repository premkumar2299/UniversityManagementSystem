using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ums.Model;
using UniversityApp.Entities;

namespace Ums.Repository.RepoMapper
{
    public static class StudentMapper
    {
       public static StudEntity asEntity(this StudentModel student)
        {
            return new StudEntity()
            {
                StudRoll= student.StudRoll,
                StudName= student.StudName,
                StudFname= student.StudFname,
                Address= student.Address,
                Dob= student.Dob,
                Email= student.Email,
                Phone=student.Phone,
                Branch= student.Branch,
                Course= student.Course,
            };
        }
        public static StudentModel AsModel(this StudEntity stud) 
        {
            return new StudentModel()
            {
                StudRoll = stud.StudRoll,
                StudName = stud.StudName,
                Course = stud.Course,
                Address = stud.Address,
                Dob = stud.Dob,
                Email = stud.Email,
                Phone = stud.Phone,
                Branch = stud.Branch,
                StudFname = stud.StudFname,
            };
        }

    }
}
