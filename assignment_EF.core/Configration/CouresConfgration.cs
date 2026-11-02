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
    public class CouresConfgration : IEntityTypeConfiguration<Course>
    {
        public void Configure(EntityTypeBuilder<Course> builder)
        {
            builder.HasKey(c => c.id);
            builder.Property(c => c.title).HasColumnType("varchar(50)").IsRequired();
            builder.Property(c => c.Price).HasColumnType("decimal(18,2)").IsRequired();
            builder.Property(c => c.PublishedDate).HasDefaultValueSql("GETDATE()");
            builder.Property(c => c.description).HasColumnType("varchar(100)").IsRequired(false);
            builder.HasOne(c => c.instructor)
                   .WithMany(i => i.courses)
                   .HasForeignKey(c => c.instructorid);

            builder.HasOne(c=>c.category)
                   .WithMany(cat=>cat.courses)
                   .HasForeignKey(c=>c.categoryId);

            builder.HasData(
                new Course
                {
                    id = 1,
                    title = "C# Programming",
                    description = "Learn the fundamentals of C# programming language.",
                    Price = 199.99m,
                    PublishedDate = new DateTime(2026, 10, 1),
                    IsPublished = true,
                    Level = Enum.level.Beginner,
                    instructorid = 1,
                    categoryId = 1
                },
                new Course
                {
                    id = 2,
                    title = "ASP.NET Core Web Development",
                    description = "Build web applications using ASP.NET Core framework.",
                    Price = 249.99m,
                    PublishedDate = new DateTime(2026, 10, 1),
                    IsPublished = true,
                    Level = Enum.level.Intermediate,
                    instructorid = 2,
                    categoryId = 2
                },
                new Course
                {
                    id = 3,
                    title = "Mobile App Development with Xamarin",
                    description = "Create cross-platform mobile applications using Xamarin.",
                    Price = 299.99m,
                    PublishedDate = new DateTime(2026, 10, 1),
                    IsPublished = true,
                    Level = Enum.level.Intermediate,
                    instructorid = 3,
                    categoryId = 3
                },
                new Course
                {
                    id = 4,
                    title = "Data Science with Python",
                    description = "Learn data analysis and machine learning using Python.",
                    Price = 349.99m,
                    PublishedDate = new DateTime(2026, 10, 1),
                    IsPublished = false,
                    Level = Enum.level.Beginner,
                    instructorid = 1,
                    categoryId = 4
                },
                new Course
                {
                    id = 5,
                    title = "Machine Learning Fundamentals",
                    description = "Introduction to machine learning concepts and algorithms.",
                    Price = 399.99m,
                    PublishedDate = new DateTime(2026, 10, 1),
                    IsPublished = true,
                    Level = Enum.level.Advanced,
                    instructorid = 2,
                    categoryId = 5
                },
                new Course
                {
                    id = 6,
                    title = "Advanced C# Programming",
                    description = "Deep dive into advanced topics of C# programming language.",
                    Price = 449.99m,
                    PublishedDate = new DateTime(2026, 10, 1),
                    IsPublished = true,
                    Level = Enum.level.Advanced,
                    instructorid = 3,
                    categoryId = 1
                }

            );


        }
    }
}
