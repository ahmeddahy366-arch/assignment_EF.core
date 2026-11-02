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
    public class EnorllmentConfgration : IEntityTypeConfiguration<Enrollment>
    {
        public void Configure(EntityTypeBuilder<Enrollment> builder)
        {
            builder.Property(e => e.FinalGrade).IsRequired(false).HasColumnType("decimal(18,2)");
            builder.Property(e => e.ProgressPercentage).IsRequired().HasColumnType("decimal(18,2)");
            builder.Property(e => e.EnrollmentDate).HasDefaultValueSql("GETDATE()");
            builder.HasOne(e => e.Student).WithMany(s => s.enrollments).HasForeignKey(e => e.StudentId);
            builder.HasOne(e => e.Course).WithMany(c => c.enrollments).HasForeignKey(e => e.CourseId);
            builder.HasKey(e => new { e.StudentId, e.CourseId });  



        }
    }
}
