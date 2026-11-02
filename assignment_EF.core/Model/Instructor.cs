using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_EF.core.Model
{
    public class Instructor
    {
        public int id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string? Bio { get; set; }
        public DateTime JoinedDate { get; set; }
        public ICollection<Course> courses { get; set; }

    }
}
