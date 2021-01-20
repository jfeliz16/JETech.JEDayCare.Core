using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace JETech.JEDayCare.Core.Data.Entities
{
    public class User : IdentityUser
    {   
        public Person Person { get; set; }
    }
}
