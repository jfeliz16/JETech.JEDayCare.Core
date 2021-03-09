using JETech.NetCoreWeb;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using JETech.JEDayCare.Core.Clients.Models;
using System.Linq;
using JETech.JEDayCare.Core.Clients.Interfaces;
using JETech.JEDayCare.Core.Data.Entities;
using JETech.NetCoreWeb.Types;
using JETech.JEDayCare.Core.Administration.Interfaces;
using JETech.JEDayCare.Core.Administration.Models;
using Microsoft.EntityFrameworkCore;
using JETech.NetCoreWeb.Helper;

namespace JETech.JEDayCare.Core.Clients.Services
{
    public class ClientService : IClientService
    {
        private readonly JEDayCareDbContext _dbContext;
        private readonly IPersonService _personService;        
        private readonly ActionHelper _actionHelper;

        public ClientService(JEDayCareDbContext dbContext,
                             IPersonService personService) {
            _dbContext = dbContext;
            _personService = personService;            
            _actionHelper = new ActionHelper();
        }

        public ActionPaginationResult<IQueryable<ClientModel>> GetClients(ActionQueryArgs<ClientModel> args)
        {
            try
            {
                var result = _dbContext.Clients
                    .Include(p => p.Person.Status)
                    .Select(c => new ClientModel
                    {
                        Parent =
                        {
                            Address = c.Parent.Address,
                            CellPhone = c.Parent.CellPhone,
                            Email = c.Parent.Email,
                            Fax = c.Parent.Fax,
                            FirstName = c.Parent.FirstName,
                            HomePhone = c.Parent.HomePhone,
                            IdentityId = c.Parent.IdentityId,
                            LastName = c.Parent.LastName,
                            StatusId = c.Parent.Status.Id,
                            TypeIdentityId = c.Parent.TypeIdentityId,
                            ZipCode = c.Parent.ZipCode
                        },
                        Id = c.Id,
                        FirstNameChild = c.Person.FirstName,
                        LastNameChild = c.Person.LastName,
                        BirthDate = c.Person.BirthDate,
                        StatusId = c.Person.StatusId,
                        StatusName = c.Person.Status.Name
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

        public async Task<ActionResult<int>> Create(ActionArgs<ClientModel> args) 
        {
            try
            {
                if (args.Data == null) throw new JETech.NetCoreWeb.Exceptions.JETechException("This field is required \"Data\"");
                if (args.Data.Parent == null) throw new JETech.NetCoreWeb.Exceptions.JETechException("This field is required \"Parent\"");

                int id = 0;
                using (var trans = _dbContext.Database.BeginTransaction())
                {
                    var clientModel = new PersonModel() 
                    {
                        FirstName = args.Data.FirstNameChild,
                        LastName = args.Data.LastNameChild,
                        BirthDate = args.Data.BirthDate
                    };

                    var createClient = await _personService.Create(new ActionArgs<PersonModel> {Data = clientModel });
                    var createParent = await _personService.Create(new ActionArgs<PersonModel> { Data = args.Data.Parent });                    

                    var client = new Client { Id = createClient.Data, ParentId = createParent.Data };

                    _dbContext.Clients.Add(client);
                    await _dbContext.SaveChangesAsync();

                    await trans.CommitAsync();
                    id = createClient.Data;
                }

                return new ActionResult<int> { Data = id };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
