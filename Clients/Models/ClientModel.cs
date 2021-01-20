using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.JEDayCare.Core.Clients.Models
{
    public class ClientModel
    {
        public int Id { get; set; }

        public int ClientType { get; set; }
  
        public string FullName { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int? TypeIdentityId { get; set; }

        public string IdentityId { get; set; }

        public string HomePhone { get; set; }

        public string CellPhone { get; set; }

        public string Fax { get; set; }

        public string Contry { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public int? ZipCode { get; set; }

        public string Email { get; set; }

        public int StatusId { get; set; }

        public string StatusName { get; set; }        
    }
}
