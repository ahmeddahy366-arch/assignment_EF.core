using assignment_EF.core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_EF.core.Configration
{
    public class CategoryConfgration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Name)
                   .IsRequired(true)
                   .HasMaxLength(50);
            builder.Property(c => c.Description)
                    .HasMaxLength(100)
                   .IsRequired(false);
            builder.HasOne(ca => ca.category)
                   .WithMany(c => c.SupCategories)
                   .HasForeignKey(ca => ca.categoryId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Category
            {
                Id = 1,
                Name = "Programming",
                Description = "All programming courses",
                categoryId = null
            }, new Category
            {
                Id = 2,
                Name = "Web Development",
                Description = "All web development courses",
                categoryId = 1
            }, new Category
            {
                Id = 3,
                Name = "Mobile Development",
                Description = "All mobile development courses",
                categoryId = 1
            }, new Category
            {
                Id = 4,
                Name = "Data Science",
                Description = "All data science courses",
                categoryId = null
            }, new Category
            {
                Id = 5,
                Name = "Machine Learning",
                Description = "All machine learning courses",
                categoryId = 4
            });



        }
    }
}
