using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JETech.JEDayCare.Core.Data.Entities
{
    
    public class Client 
    {
        [ForeignKey(nameof(Person))]
        public int Id { get; set; }
        public Person Person { get; set; }
        [Required]
        public int ParentId { get; set; }
        [ForeignKey("ParentId")]
        public Person Parent { get; set; }
    }
}
