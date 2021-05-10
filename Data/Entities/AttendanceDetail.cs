using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JETech.JEDayCare.Core.Data.Entities
{
    public class AttendanceDetail
    {
        public int Id { get; set; }

        public int AttendaceId { get; set; }

        [Required]        
        public Attendance Attendace { get; set; }

        public int ClientId { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        public int AttendaceValue { get; set; }
    }
}
