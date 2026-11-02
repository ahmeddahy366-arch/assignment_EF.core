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
    public class InstructorConfgration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
        {
            builder.HasKey(i => i.id);
            builder.Property(i => i.FullName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(i => i.Email).HasColumnType("varchar(50)").IsRequired();
            builder.Property(i => i.Bio).HasColumnType("varchar(100)").IsRequired(false);
            builder.Property(i => i.JoinedDate).HasDefaultValueSql("GETDATE()");
            builder.HasData(
                new Instructor
                {
                    id = 1,
                    FullName = "John Doe",
                    Email = "john.doe@example.com",
                    Bio = "Experienced instructor with a passion for teaching programming.",
                    JoinedDate = new DateTime(2026, 10, 1)
                },
                new Instructor
                {
                    id = 2,
                    FullName = "Jane Smith",
                    Email = "jane.smith@example.com",
                    Bio = "Passionate instructor with expertise in web development.",
                    JoinedDate = new DateTime(2026, 7, 1)
                },

                new Instructor
                {
                    id = 3,
                    FullName = "Michael Johnson",
                    Email = "michael.johnson@example.com",
                    Bio = "Dedicated instructor with a focus on mobile development.",
                    JoinedDate = new DateTime(2026, 6, 1)
                }
            );
        }
    }
}
