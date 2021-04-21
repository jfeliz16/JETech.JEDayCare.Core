using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JETech.JEDayCare.Core.Data.Entities
{
    public class Contry
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(3)]
        public string Abbrv { get; set; }

        public ICollection<City> Cities { get; set; }
    }
}
