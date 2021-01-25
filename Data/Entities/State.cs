using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JETech.JEDayCare.Core.Data.Entities
{
    public class State
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public Contry Contry { get; set; }
    }
}
