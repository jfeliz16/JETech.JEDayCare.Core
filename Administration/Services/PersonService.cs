using JETech.JEDayCare.Core.Administration.Helper;
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
                ValidateRequired(args.Data);

                var person = GeneralConverter.ToPerson(args.Data);

                _dbContext.Persons.Add(person);
                await _dbContext.SaveChangesAsync();

                return new ActionResult<int> { Data = person.Id };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<ActionResult<bool>> Update(ActionArgs<PersonModel> args)
        {
            try
            {
                ValidateRequired(args.Data);

                var person = GeneralConverter.ToPerson(args.Data);

                _dbContext.Set<Person>().Update(person);
                await _dbContext.SaveChangesAsync();

                return new ActionResult<bool> { Data = true };
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void ValidateRequired(PersonModel model) 
        {
            if (string.IsNullOrEmpty(model.FullName))
            {
                if (string.IsNullOrEmpty(model.FirstName))
                    throw new JETechException("This field is required FirstName");

                if (string.IsNullOrEmpty(model.LastName))
                    throw new JETechException("This field is required LastName");

                model.FullName = $"{model.FirstName.Trim()} {model.LastName.Trim()}";
            }
        }
    }
}
