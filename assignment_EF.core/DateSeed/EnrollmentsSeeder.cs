using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_EF.core.DateSeed
{
    public class EnrollmentsSeeder
    {
        public static void SeedEnrollments(AppContext context)
        {
            if (!context.Enrollments.Any())
            {
                context.AddRange(new Model.Enrollment
                {
                    StudentId = 1,
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2026, 10, 1),
                    Status = Enum.Status.Active,
                    ProgressPercentage = 0,
                    FinalGrade = null
                },
                new Model.Enrollment
                {
                    StudentId = 2,
                    CourseId = 1,
                    EnrollmentDate = new DateTime(2026, 10, 1),
                    Status = Enum.Status.Active,
                    ProgressPercentage = 50,
                    FinalGrade = null
                },
                new Model.Enrollment
                {
                    StudentId = 3,
                    CourseId = 2,
                    EnrollmentDate = new DateTime(2026, 10, 1),
                    Status = Enum.Status.Active,
                    ProgressPercentage = 80,
                    FinalGrade = null
                },
                new Model.Enrollment
                {
                    StudentId = 4,
                    CourseId = 3,
                    EnrollmentDate = new DateTime(2026, 10, 1),
                    Status = Enum.Status.Active,
                    ProgressPercentage = 30,
                    FinalGrade = null
                }, new Model.Enrollment
                {
                    StudentId = 5,
                    CourseId = 4,
                    EnrollmentDate = new DateTime(2026, 10, 1),
                    Status = Enum.Status.Completed,
                    ProgressPercentage = 100,
                    FinalGrade = 80
                }, new Model.Enrollment
                {
                    StudentId = 6,
                    CourseId = 5,
                    EnrollmentDate = new DateTime(2026, 10, 1),
                    Status = Enum.Status.Dropped,
                    ProgressPercentage = 0,
                    FinalGrade = null
                }, new Model.Enrollment
                {
                    StudentId = 5,
                    CourseId = 6,
                    EnrollmentDate = new DateTime(2026, 10, 1),
                    Status = Enum.Status.Dropped,
                    ProgressPercentage = 0,
                    FinalGrade = null
                }, new Model.Enrollment
                {
                    StudentId = 6,
                    CourseId = 3,
                    EnrollmentDate = new DateTime(2026, 10, 1),
                    Status = Enum.Status.Completed,
                    ProgressPercentage = 100,
                    FinalGrade = 90
                });



                context.SaveChanges();


            }

        }
    }
}
