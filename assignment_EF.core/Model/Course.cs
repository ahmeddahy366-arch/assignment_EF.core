using assignment_EF.core.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_EF.core.Model
{
    public class Course
    {
        public int id { get; set; }
        public string title { get; set; }
        public string? description { get; set; }
        public decimal Price { get; set; }
        public level Level { get; set; }
        public bool IsPublished { get; set; }
        public DateTime ?PublishedDate { get; set; }
        public int instructorid { get; set; }
        public Instructor instructor { get; set; }

        public int categoryId { get; set; }
        public Category category { get; set; }

        public ICollection<Enrollment> enrollments { get; set; }

    }
}
