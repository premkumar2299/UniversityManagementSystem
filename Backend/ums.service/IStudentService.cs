using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ums.Model;
using UniversityApp.Entities;

namespace ums.service
{
    public interface IStudentService
    {
        List<StudentModel> Get();

        StudentModel GetStudById(int StudRoll);

        Task<StudentModel?> InsertStud(StudentModel User);


        StudentModel UpdateUser(int RollNum, StudentModel User);

        HttpStatusCode DeleteUser(int StudRoll);

        PaginatorModel FilterStudents(int pageno);

        IEnumerable<StudentModel> SearchStudent(string Name);


    }
}
