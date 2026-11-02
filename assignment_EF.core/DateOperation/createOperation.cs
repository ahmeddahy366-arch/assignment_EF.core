using assignment_EF.core.Enum;
using assignment_EF.core.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_EF.core.DateOperation
{
    public class createOperation
    {
        public static void AddInstructor(AppContext context)
        {
            AppContext Context = new AppContext();
            Instructor instructor1 = new Instructor()
            {

                FullName = "John Smith",
                Email = "john.smith@example.com",
                Bio = "Experienced instructor with a passion for teaching programming.",
                JoinedDate = new DateTime(2026, 10, 1)

            };

            context.Instructors.Add(instructor1);

            context.SaveChanges();
            Console.WriteLine(instructor1.id);
            Console.WriteLine("INSTRUCTOR added successfully.");


        }

        public static void AddCourse(AppContext context)
        {

            AppContext Context = new AppContext();


            if (context.Instructors.Any() && context.Categories.Any())
            {
                context.Courses.Add(new Course
                {
                    title = "Introduction to Programming",
                    description = "Learn the basics of programming using C#.",
                    Price = 199.99m,
                    categoryId = 1,
                    Level = Enum.level.Beginner,
                    IsPublished = true,
                    instructorid = context.Instructors.First().id
                });

                context.SaveChanges();
                Console.WriteLine("Course added successfully.");


            }
            else
            {
                Console.WriteLine("No instructors or categories found. Please add instructors and categories first.");
            }




        }
        public static void AddStudent(AppContext context)
        {

            context.Students.AddRange(

        new Student { FullName = "Ali Ahmed", Email = "ali@example.com", DateOfBirth = new DateTime(2001, 5, 10) },
        new Student { FullName = "Sara Mohamed", Email = "sara@example.com", DateOfBirth = new DateTime(2002, 8, 20) },
        new Student { FullName = "Khaled Omar", Email = "khaled@example.com", DateOfBirth = new DateTime(2000, 2, 15) });

            context.SaveChanges();

            foreach (var student in context.Students)
            {
                Console.WriteLine($"Student ID: {student.Id}");
            }
        }

        public static void addEnrollment(AppContext context, int studentId, int courseId)
        {

            var student = context.Students.Find(studentId);
            var course = context.Courses.Find(courseId);


            if (student == null)
            {
                Console.WriteLine("Enrollment refused: Student does not exist.");
                return;
            }

            if (course == null)
            {
                Console.WriteLine("Enrollment refused: Course does not exist.");
                return;
            }

            if (course.IsPublished == false)
            {
                Console.WriteLine("Enrollment refused: Course is not published.");
                return;

            }
            if (context.Enrollments.Any(e => e.StudentId == studentId && e.CourseId == courseId))
            {
                Console.WriteLine("Enrollment refused: Student is already enrolled in this course.");
                return;
            }
            context.Enrollments.Add(new Enrollment
            {
                StudentId = studentId,
                CourseId = courseId,
                EnrollmentDate = DateTime.Now,
                ProgressPercentage = 0,
                Status = Enum.Status.Active
            });

            context.SaveChanges();
            Console.WriteLine("Enrollment added successfully.");


        }

        public static void GetCoursesByIDOrTitle(AppContext context, int courseId, string courseTitle)
        {
            var course = context.Courses.Find(courseId);
            if (course != null)
            {
                Console.WriteLine($"Found by Id: {course.title}");
            }
            else
            {
                Console.WriteLine("not found");

            }

            var title1 = context.Courses.FirstOrDefault(t => t.title == courseTitle);
            if (title1 != null)
            {

                Console.WriteLine($"Found by Title: {title1.title}");
            }
            else
            {
                Console.WriteLine("not found");
            }




        }

        public static void FilterCourses(AppContext context, decimal MinPrice, decimal MaxPrice)
        {
            var filteredCourses = context.Courses.Where(c => c.Price >= MinPrice && c.Price <= MaxPrice)
                                                 .OrderByDescending(p => p.Price)
                                                 .Select(c => new { c.title, c.Level, c.Price })
                                                 .ToList();

            foreach (var course in filteredCourses)
            {
                Console.WriteLine($" - {course.title}:{course.Level} ${course.Price}");
            }
        }


        //Sub-categories: Print the direct sub-categories of a given category, then print the top - level categories.

        public static void printCategories(AppContext context, int CategoriesId)
        {
            var SupCategorie = context.Categories.Where(c => c.categoryId == CategoriesId)
                                                .ToList();
            foreach (var sup in SupCategorie)
            {
                Console.WriteLine(sup.Name);

            }

            var printCategories = context.Categories.Where(c => c.categoryId == null)
                                                  .ToList();
            foreach (var print in printCategories)
            {
                Console.WriteLine(print.Name);
            }


        }


        public static void StudentRosterEnrollmrded(AppContext context, int coursesId)
        {
            var students = context.Enrollments.Where(c => c.CourseId == coursesId)
                                   .Select(c => c.Student.Id)
                                   .ToList();

            Console.WriteLine(students.Count());
            context.Students.Where(s => students.Contains(s.Id))
                    .ToList()
                    .ForEach(s => Console.WriteLine($"Student ID: {s.Id}, Name: {s.FullName}"));


        }

        public static void UpdateCoursePrice(AppContext context, int courseId, decimal newPrice)
        {
            var courses = context.Courses.Find(courseId);
            if (courses != null)
            {
                courses.Price = newPrice;
                context.SaveChanges();
                Console.WriteLine($"Course price updated successfully to {newPrice}.");
            }
            else
            {
                Console.WriteLine("Course not found.");


            }
        }


        public static void UpdateProgressPercentage(AppContext context, int studentId, int courseId, int newProgressPercentage)
        {

            if (newProgressPercentage < 0 || newProgressPercentage > 100)
            {
                Console.WriteLine("Invalid progress value. Must be between 0 and 100.");
                return;
            }
            var enrollment = context.Enrollments.Find(studentId, courseId);
            if (enrollment != null)
            {
                enrollment.ProgressPercentage = newProgressPercentage;

                if (newProgressPercentage == 100)
                {
                    enrollment.Status = Enum.Status.Completed;
                    context.SaveChanges();
                    Console.WriteLine($"Progress percentage updated successfully to {newProgressPercentage}%.");
                }
                


            }
            else
            {
                Console.WriteLine("not found");
            }
        }
       public static void publishCourse(AppContext context, int courseId)
        {

            var course = context.Courses.Find(courseId);
            if (course != null)
            {
                course.IsPublished = true;
                course.PublishedDate = DateTime.Now;
                context.SaveChanges();
                Console.WriteLine($"Course published successfully.");
            }
            else
            {
                Console.WriteLine("Course not found.");
            }
        }
        public static void Unenroll(AppContext context, int courseId,int studentId)
        {
            context.Enrollments.RemoveRange(context.Enrollments.Where(c=>c.StudentId==studentId && c.CourseId==courseId));
            context.SaveChanges();  

        }

       public static void RemoveCategory(AppContext context, int categoryID)
        {
          var category=  context.Categories.Find(categoryID);
            try
            {
                if (category != null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                    Console.WriteLine("Category deleted successfully.");
                }

            }
            catch(Microsoft.EntityFrameworkCore.DbUpdateException ex)
            {
                Console.WriteLine($"Error occurred while deleting category: {ex.Message}");

            }

        }


        public static void SafeRemoveCategory(AppContext context, int categoryID)
        {
            bool hasSubCategories = context.Categories.Any(c=>c.Id==categoryID);
           
                if (hasSubCategories)
                {
                    Console.WriteLine("Cannot delete this category because it contains sub-categories.");
                    return;
                }
      
                
                var category =context.Categories.Find(categoryID);
                if(category!=null)
                {
                    context.Categories.Remove(category);
                    context.SaveChanges();
                }
            else
            {
                Console.WriteLine("Category not found.");
            }
         


        }

        public static void RemoveCourse(AppContext context, int courseID)
        {


            Console.WriteLine(context.Enrollments.Where(c => c.CourseId == courseID).Count()); 

            var course=  context.Courses.Find(courseID);
            if(course!=null)
            {
                context.Courses.Remove(course);
                context.SaveChanges();
                int cont = context.Enrollments.Where(c => c.CourseId == courseID).Count();
                Console.WriteLine($"Enrollments removed. Remaining enrollments for the course: {cont}");
            }
            else { Console.WriteLine("Course not found."); }

            // Explanation: Why were the enrollments automatically removed?
            // Because of the "Cascade Delete" rule in the database relationship. 
            // When the parent Course is deleted, Entity Framework / SQL Server automatically 
            // removes all related child Enrollments to maintain database integrity and prevent orphaned records.
        }
        public static void BulkRaiseCoursePrices(AppContext context, string courseLevel)
        {
            int rowsAffected = context.Courses
                              .Where(c => c.Level.ToString() == courseLevel && c.IsPublished == true)
                              .ExecuteUpdate(c => c.SetProperty(co => co.Price, co => co.Price * 1.10m));
            Console.WriteLine($"Number of affected rows (Price Raise): {rowsAffected}");
        }

        public static void BulkRaiseDelet(AppContext context)
        {
            int rowsAffected = context.Enrollments
                              .Where(e=>e.Status == Status.Dropped)
                              .ExecuteDelete();
            Console.WriteLine($"Number of affected rows (dropped): {rowsAffected}");
        }
    }
}
  

