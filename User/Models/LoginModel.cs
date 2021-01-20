using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace JETech.JEDayCare.Core.User.Models
{
    public class LoginModel
    {   
        public string Username { get; set; }
       
        public string Password { get; set; }
     
        public bool RememberMe { get; set; }
    }
}
