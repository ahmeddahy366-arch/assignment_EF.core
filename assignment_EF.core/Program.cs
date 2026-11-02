using assignment_EF.core.DateOperation;
using assignment_EF.core.DateSeed;
using Microsoft.EntityFrameworkCore;

namespace assignment_EF.core
{
    internal class Program
    {
        static void Main(string[] args)
        {

            using AppContext context= new AppContext();
            context.Database.Migrate();
            StudentSeeder.SeedStudent(context);
            EnrollmentsSeeder.SeedEnrollments(context);
            createOperation.AddInstructor(context);
            createOperation.AddCourse(context);
            createOperation.AddStudent(context);
            createOperation.addEnrollment(context, 10, 10);
            createOperation.GetCoursesByIDOrTitle(context, 10, "Introduction to Programming");
            createOperation.FilterCourses(context, 100, 200);
            createOperation.printCategories(context, 1);
            createOperation.StudentRosterEnrollmrded(context, 10);
            createOperation.UpdateProgressPercentage(context, 10, 10, 100);
            createOperation.publishCourse(context,5);
            createOperation.Unenroll(context, 10, 10);
            createOperation.RemoveCategory(context, 1);
            createOperation.SafeRemoveCategory(context, 1);
            createOperation.RemoveCourse(context, 1);
            createOperation.BulkRaiseCoursePrices(context, "Beginner");
            createOperation.BulkRaiseDelet(context);





        }
    }
}
