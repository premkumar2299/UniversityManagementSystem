using ums.Model;
using UniversityApp.Dto_s;

namespace UniversityApp.Mappers
{
    public static class FacultyMapper
    {
        public static FacultyViewDto AsViewFDTO(this FacultyModel facultyModel)
        {
            return new FacultyViewDto
            {
                Address =  facultyModel.FacultyName,
                FacultyFname = facultyModel.FacultyFname,
                EmpId = facultyModel.EmpId,
               FacultyName=facultyModel.FacultyName,
            };
        }
        public static FacultyModel AsFModel(this FacultyDto facultyDto)
        {
            return new FacultyModel
            {
                Address = facultyDto.Address,
                FacultyName = facultyDto.FacultyName,
                FacultyFname = facultyDto.FacultyFname,
                EmpId = facultyDto.EmpId,
                Department = facultyDto.Department,
                Education = facultyDto.Education,
                Dob = facultyDto.Dob,
                Email = facultyDto.Email,
                Phone = facultyDto.Phone,

            };
        }

        public static FacultyDto AsFDTO(this FacultyModel facultyModel)
        {
            return new FacultyDto
            {
                Address = facultyModel.Address,
                FacultyName = facultyModel.FacultyName,
                FacultyFname = facultyModel.FacultyFname,
                EmpId = facultyModel.EmpId,
                Department = facultyModel.Department,
                Education = facultyModel.Education,
                Dob = facultyModel.Dob,
                Email = facultyModel.Email,
                Phone = facultyModel.Phone,

            };
        }
    }
}

