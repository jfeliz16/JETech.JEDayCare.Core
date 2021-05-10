using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JETech.JEDayCare.Core.Data.Entities
{
    public class Attendance
    {
        public int Id { get; set; }

        [Required]
        public DateTime DateAttendance { get; set; }

        public ICollection<AttendanceDetail> AttendanceDetails { get; set; }
    }
}
