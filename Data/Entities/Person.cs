using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JETech.JEDayCare.Core.Data.Entities
{
    
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string FullName { get; set; }

        [MaxLength(100)]
        public string FirstName { get; set; }

        [MaxLength(100)]
        public string LastName { get; set; }

        public int? TypeIdentityId { get; set; }

        [MaxLength(20)]
        public string IdentityId { get; set; }

        [MaxLength(12)]
        public string HomePhone { get; set; }

        [MaxLength(12)]
        public string CellPhone { get; set; }

        [MaxLength(12)]
        public string Fax { get; set; }

        public int? ContryId { get; set; }
        public Contry Contry { get; set; }

        public int? StateId { get; set; }
        public State State { get; set; }

        public int? CityId { get; set; }
        public City City { get; set; }

        [MaxLength(200)]
        public string Address { get; set; }

        public int? ZipCode { get; set; }

        [MaxLength(256)]
        public string Email { get; set; }        

        [Required]
        public DateTime InitDate { get; set; }
                
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }

        public int StatusId { get; set; }
        [Required]
        public Status Status { get; set; }
    }
}
