using JETech.JEDayCare.Core.Data.Entities;
using JETech.JEDayCare.Core.User.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.JEDayCare.Core.User.Helper
{
    public class UserConverter
    {
        public static Data.Entities.User ToUser(UserModel model) 
        {
            return new Data.Entities.User
            {                
                UserName = model.UserName,
                Email = model.UserName                
            };
        }
    }
}
