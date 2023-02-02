using ums.Model;
using UniversityApp.Dto_s;

namespace UniversityApp.Mappers
{
    public static class studentMapper
    {
        

        public static StudentViewDto AsViewDTO(this StudentModel studentModel) 
        {
            return new StudentViewDto { 
                Address= studentModel.Address,
                StudName= studentModel.StudName,
                StudFname= studentModel.StudFname,
                StudRoll = studentModel.StudRoll    
            };
        }
        public static StudentModel AsModel(this StudentDTO studentDto) 
        {
            return new StudentModel { 
                Address= studentDto.Address,
                StudName= studentDto.StudName,
                StudFname= studentDto.StudFname,
                StudRoll = studentDto.StudRoll,
                Branch = studentDto.Branch,
                Course = studentDto.Course,
                Dob = studentDto.Dob ,
                Email= studentDto.Email,
                Phone = studentDto.Phone,
            };
        }

        public static StudentDTO AsDTO(this StudentModel studentModel)
        {
            return new StudentDTO {
             Address = studentModel.Address,
             Branch = studentModel.Branch,
             Course= studentModel.Course,
             Dob = studentModel.Dob,
             Email= studentModel.Email,
             Phone = studentModel.Phone,
             StudFname= studentModel.StudFname,
             StudName= studentModel.StudName,
             StudRoll = studentModel.StudRoll
            };
        }
    }
}
