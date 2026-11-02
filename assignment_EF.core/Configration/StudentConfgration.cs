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
    public class StudentConfgration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.FullName).HasColumnType("varchar(50)").IsRequired();
            builder.Property(s => s.Email).HasColumnType("varchar(50)").IsRequired();
            builder.Property(s => s.DateOfBirth).HasDefaultValueSql("GETDATE()");
        }
    }
}
