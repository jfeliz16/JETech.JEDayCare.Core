using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JETech.JEDayCare.Core.Data.Entities
{
    public class Client
    {
        public int Id { get; set; }

        [Required]
        public Person Person { get; set; }
    }
}
