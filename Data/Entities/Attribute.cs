using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JETech.JEDayCare.Core.Data.Entities
{
    public class Attribute
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Descripcion { get; set; }

        [Required]
        [MaxLength(100)]
        public string Group { get; set; }

        [MaxLength(20)]
        public string ValueString { get; set; }

        public Int16? ValueNum { get; set; }
    }
}
