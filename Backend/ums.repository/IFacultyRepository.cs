using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using ums.Model;

namespace ums.repository
{
    public interface IFacultyRepository
    {
        List<FacultyModel> GetAllFaculty();

        FacultyModel GetFacultyById(int empId);

        Task<FacultyModel> InsertFaculty(FacultyModel User);


        FacultyModel UpdateFaculty(FacultyModel User);

        HttpStatusCode DeleteFaculty(int empId);

        FacultyPaginator FilterFaculty(int pageno);
    }
}
