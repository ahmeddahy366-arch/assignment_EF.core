using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_EF.core.Model
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public int? categoryId { get; set; }
        public Category? category { get; set; }
        public ICollection<Category>? SupCategories { get; set; }

        public ICollection<Course> courses { get; set; }

    }
}
