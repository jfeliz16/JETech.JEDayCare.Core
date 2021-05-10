using JETech.JEDayCare.Core.Administration.Models;
using JETech.JEDayCare.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace JETech.JEDayCare.Core.Administration.Helper
{
    class GeneralConverter
    {
        public static Person ToPerson(PersonModel model) => new Person
        {
            Id = model.Id,
            Address = model.Address,
            BirthDate = model.BirthDate,
            CellPhone = model.CellPhone,
            City = model.City,
            FullName = model.FullName,
            Email = model.Email,
            Fax = model.Fax,
            FirstName = model.FirstName,
            HomePhone = model.HomePhone,
            IdentityId = model.IdentityId,
            LastName = model.LastName,
            StateId = model.StateId,
            StatusId = model.StatusId,            
            ZipCode = model.ZipCode
        };
    }
}
