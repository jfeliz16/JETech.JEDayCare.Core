using JETech.NetCoreWeb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JETech.JEDayCare.Core.Clients.Models;
using System.Linq;
using JETech.NetCoreWeb.Helper;
using JETech.JEDayCare.Core.Data.Entities;
using JETech.NetCoreWeb.Types;
using JETech.JEDayCare.Core.Global;
using Microsoft.EntityFrameworkCore;

namespace JETech.JEDayCare.Core.Clients.Domain
{
    public class Client
    {
        private readonly ActionHelper _actionHelper;
        private readonly SicDbContext _sicDb;

        public Client(SicDbContext sicDb)
        {
            _actionHelper = new ActionHelper();
            _sicDb = sicDb;
        }

        public async Task<ActionResult<ClientModel>> Create(ActionArgs<ClientModel> args) 
        {            
            try
            {
                var cli = new JETech.JEDayCare.Core.Data.Entities.Person
                {
                     Address = args.Model.Address,
                     CellPhone = args.Model.CellPhone,
                     //City= args.Model.City,
                     //Contry = args.Model.CellPhone,
                     Email = args.Model.Email,
                     Fax = args.Model.Fax,
                     FirstName = args.Model.FirstName,
                     FullName = args.Model.FullName,
                     HomePhone = args.Model.HomePhone,
                     IdentityId = args.Model.IdentityId,
                     LastName = args.Model.LastName,
                     Status = new Status { Id = (int)StatusCode.Activo },
                     TypeIdentityId = args.Model.TypeIdentityId,
                     ZipCode = args.Model.ZipCode,
                };

                _sicDb.Persons.Add(cli);

                await _sicDb.SaveChangesAsync();

                args.Model.Id = cli.Id;

                return new ActionResult<ClientModel> { Data = args.Model };       
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ActionPaginationResult<IQueryable<ClientModel>> Get(ActionQueryArgs<ClientModel> args)
        {
            try
            {               
                var result = _sicDb.Clients
                    .Include(p => p.Person.Status)
                    .Select( c => new ClientModel { 
                        Address = c.Person.Address,
                        CellPhone = c.Person.CellPhone,
                        City = c.Person.City.Name,
                        Contry = c.Person.Contry.Name, 
                        Email = c.Person.Email,
                        Fax = c.Person.Fax,
                        FirstName =c.Person.FirstName,
                        FullName = c.Person.FullName,
                        HomePhone = c.Person.HomePhone,
                        Id  = c.Id,
                        IdentityId = c.Person.IdentityId,
                        LastName = c.Person.LastName,
                        StatusId = c.Person.Status.Id,
                        StatusName = c.Person.Status.Name,
                        TypeIdentityId = c.Person.TypeIdentityId,
                        ZipCode = c.Person.ZipCode
                    });

                if (args.Condiction != null)
                {
                    result = result.Where(args.Condiction);                    
                }

                return _actionHelper.GetPaginationResult<ClientModel>(args, result);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

