using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ums.Model;

namespace ums.service
{
    public interface IFacultyService
    {
        List<FacultyModel> GetAllFaculty();

        FacultyModel GetFacultyById(int empId);

        Task<FacultyModel> InsertFaculty(FacultyModel User);


        FacultyModel UpdateFaculty(int EmpId,FacultyModel User);

        HttpStatusCode DeleteFaculty(int empId);

        FacultyPaginator FilterFaculty(int pageno);

        IEnumerable<FacultyModel> SearchFaculty(string Name);
    }
}

