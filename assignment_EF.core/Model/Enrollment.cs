using assignment_EF.core.Enum;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace assignment_EF.core.Model
{
    [PrimaryKey(nameof(StudentId), nameof(CourseId))]
    public class Enrollment
    {

        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int CourseId { get; set; }
        public Course Course { get; set; }
        public DateTime EnrollmentDate { get; set; }
        public decimal ProgressPercentage { get; set; }
        public Status Status { get; set; }
        public decimal? FinalGrade { get; set; }

    }
}
