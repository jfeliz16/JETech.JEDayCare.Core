using JETech.JEDayCare.Core.Administration.Interfaces;
using JETech.JEDayCare.Core.Administration.Models;
using JETech.JEDayCare.Core.Data.Entities;
using JETech.NetCoreWeb.Exceptions;
using JETech.NetCoreWeb.Types;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace JETech.JEDayCare.Core.Administration.Services
{
    public class PersonService : IPersonService
    {
        private readonly JEDayCareDbContext _dbContext;

        public PersonService(JEDayCareDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<ActionResult<int>> Create(ActionArgs<PersonModel> args)
        {
            try
            {
                if (string.IsNullOrEmpty(args.Data.FullName))
                {
                    if (string.IsNullOrEmpty(args.Data.FirstName))
                        throw new JETechException("This field is required FirstName");

                    if (string.IsNullOrEmpty(args.Data.LastName))
                        throw new JETechException("This field is required LastName");

                    args.Data.FullName = $"{args.Data.FirstName.Trim()} {args.Data.LastName.Trim()}";
                } 

                var person = new Person
                {
                    Address = args.Data.Address,
                    BirthDate = args.Data.BirthDate,
                    CellPhone = args.Data.CellPhone,
                    CityId = args.Data.CityId,
                    ContryId = args.Data.ContryId,
                    FullName = args.Data.FullName,
                    Email = args.Data.Email,
                    Fax = args.Data.Fax,
                    FirstName = args.Data.FirstName,
                    HomePhone = args.Data.HomePhone,
                    IdentityId = args.Data.IdentityId,
                    LastName = args.Data.LastName,
                    StateId = args.Data.StateId,
                    StatusId = (int)Global.StatusCode.Activo,
                    TypeIdentityId = args.Data.TypeIdentityId,
                    ZipCode = args.Data.ZipCode
                };

                _dbContext.Persons.Add(person);
                await _dbContext.SaveChangesAsync();

                return new ActionResult<int> { Data = person.Id };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
