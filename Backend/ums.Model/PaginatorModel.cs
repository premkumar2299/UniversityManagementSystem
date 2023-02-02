using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ums.Model
{
    public class PaginatorModel
    {
        public List<StudentModel> students { get; set; } = new List<StudentModel>(); 
        public int pageNumber { get; set; }
        public int totalPages { get; set; }
        public int totalElements { get; set; }
    }
}
