using JETech.JEDayCare.Core.Administration.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JETech.JEDayCare.Core.Clients.Models
{
    public class ClientModel
    {
        public int Id { get; set; }
        public string FullName => $"{FirstNameChild} {LastNameChild}";
        public string FirstNameChild { get; set; }
        public string LastNameChild { get; set; }
        public int StatusId { get; set; }

        [Display(Name = "Status")]
        public string StatusName { get; set; }
        public DateTime? BirthDate { get; set; }
        public PersonModel Parent { get; set; }
    }
}
