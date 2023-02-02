using System;
using System.Collections.Generic;

namespace UniversityApp.Entities
{
    public partial class StudEntity
    {
        public int StudRoll { get; set; }
        public string? StudName { get; set; }
        public string? StudFname { get; set; }
        public string? Address { get; set; }
        public DateTime? Dob { get; set; }
        public int? Phone { get; set; }
        public string? Email { get; set; }
        public string? Course { get; set; }
        public string? Branch { get; set; }
    }
}
