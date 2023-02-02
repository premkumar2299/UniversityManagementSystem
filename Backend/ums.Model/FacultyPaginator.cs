using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ums.Model
{
    public class FacultyPaginator
    {
        public List<FacultyModel> Faculty { get; set; } = new List<FacultyModel>();
        public int pageNumber { get; set; }
        public int totalPages { get; set; }
        public int totalElements { get; set;}
    }
}
