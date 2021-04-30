using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.JEDayCare.Core.Administration.Models
{
    public class PersonModel
    {
        public int Id { get; set; }      
        public string FullName { get; set; }        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int? TypeIdentityId { get; set; }
        public string IdentityId { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public string Fax { get; set; }
        public int? ContryId { get; set; }
        public int? StateId { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int? ZipCode { get; set; }
        public string Email { get; set; }        
        public DateTime InitDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public int StatusId { get; set; }
        public int StatusName { get; set; }        
    }
}
