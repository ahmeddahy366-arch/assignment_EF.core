using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assignment_EF.core.DateSeed
{
    public class StudentSeeder
    {

        public static void SeedStudent(AppContext context)
        {
            if (!context.Students.Any())
            {
                context.AddRange(
                    new Model.Student
                    {
                  
                        FullName = "John Doe",
                        Email = "john.doe@example.com",
                        DateOfBirth = new DateTime(2026, 10, 1),

                    }, new Model.Student
                    {
                        FullName = "Jane Smith",
                        Email = "jane.smith@example.com",
                       DateOfBirth = new DateTime(2026, 10, 1),

                    },
                    new Model.Student
                    {
                    
                        FullName = "Michael Johnson",
                        Email = "michael.johnson@example.com",
                            DateOfBirth = new DateTime(2026, 10, 1),

                    },
                    new Model.Student
                    {
                        FullName = "Emily Davis",
                        Email = "emily.davis@example.com",
                        DateOfBirth = new DateTime(2026, 10, 1),

                    },
                    new Model.Student
                    {
                
                        FullName = "David Wilson",
                        Email = "david.wilson@example.com",
                        DateOfBirth = new DateTime(2026, 10, 1),

                    },
                    new Model.Student
                    {
                       
                        FullName = "Sarah Thompson",
                        Email = "sarah.thompson@example.com",
                        DateOfBirth = new DateTime(2026, 10, 1),

                    }


                );
                context.SaveChanges();
            }
                
        }
    }

}