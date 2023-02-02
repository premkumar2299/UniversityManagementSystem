using System.ComponentModel.DataAnnotations;

namespace ums.Model
{
    public class FacultyModel
    {
        [Key]
        public int EmpId { get; set; }
        public string? FacultyName { get; set; }
        public string? FacultyFname { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public int? Phone { get; set; }
        public string? Email { get; set; }
        public string? Education { get; set; }
        public string? Department { get; set; }

    }
}
