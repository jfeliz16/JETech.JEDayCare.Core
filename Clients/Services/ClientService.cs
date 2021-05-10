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
                    .Include(p => p.Parent)
                    .OrderByDescending(p => p.Id)
                    .Select(c => new ClientModel
                    {
                        Parent = new PersonModel
                        {
                            Address = c.Parent.Address,
                            CellPhone = c.Parent.CellPhone,
                            Email = c.Parent.Email,
                            Fax = c.Parent.Fax,
                            FirstName = c.Parent.FirstName,
                            FullName = $"{c.Parent.FirstName} {c.Parent.LastName}",
                            HomePhone = c.Parent.HomePhone,
                            LastName = c.Parent.LastName,
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

        public ActionResult<ClientModel> GetClientById(int id) 
        {
            try
            {
                var result = _dbContext.Clients
                   .Include(p => p.Person.Status)
                   .Include(p => p.Parent)                   
                   .Where(c => c.Id == id)
                   .Select(c => new ClientModel
                   {
                       Parent = new PersonModel
                       {
                           Address = c.Parent.Address,
                           CellPhone = c.Parent.CellPhone,
                           Email = c.Parent.Email,
                           Fax = c.Parent.Fax,
                           FirstName = c.Parent.FirstName,
                           FullName = $"{c.Parent.FirstName} {c.Parent.LastName}",
                           HomePhone = c.Parent.HomePhone,
                           LastName = c.Parent.LastName,
                           StateId =c.Parent.StateId,
                           ZipCode = c.Parent.ZipCode
                       },
                       Id = c.Id,
                       FirstNameChild = c.Person.FirstName,
                       LastNameChild = c.Person.LastName,
                       BirthDate = c.Person.BirthDate,
                       StatusId = c.Person.StatusId,
                       StatusName = c.Person.Status.Name
                   })
                   .SingleOrDefault();

                return new ActionResult<ClientModel> { Data = result };
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<ActionResult<int>> Create(ActionArgs<ClientModel> args) 
        {
            try
            {
                ValidateRequired(args);

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

        public async Task<ActionResult<bool>> Update(ActionArgs<ClientModel> args)
        {
            try
            {
                ValidateRequired(args);

                if (args.Data.Id == 0)
                {
                    throw new JETech.NetCoreWeb.Exceptions.JETechException("This field is required \"Id\"");
                }
                
                using (var trans = _dbContext.Database.BeginTransaction())
                {
                    var client = _dbContext.Clients.Find(args.Data.Id);

                    var clientModel = new PersonModel()
                    {
                        Id = args.Data.Id,
                        FirstName = args.Data.FirstNameChild,
                        LastName = args.Data.LastNameChild,
                        BirthDate = args.Data.BirthDate,
                        StatusId = args.Data.StatusId
                    };

                    args.Data.Parent.Id = client.ParentId;
                    args.Data.Parent.StatusId = args.Data.StatusId;

                    var createClient = await _personService.Update(new ActionArgs<PersonModel> { Data = clientModel });
                    var createParent = await _personService.Update(new ActionArgs<PersonModel> { Data = args.Data.Parent });

                    await trans.CommitAsync();                    
                }

                return new ActionResult<bool> { Data = true };
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidateRequired(ActionArgs<ClientModel> args) 
        {
            if (args.Data == null) throw new JETech.NetCoreWeb.Exceptions.JETechException("This field is required \"Data\"");
            if (args.Data.Parent == null) throw new JETech.NetCoreWeb.Exceptions.JETechException("This field is required \"Parent\"");
        }

        //public async Task<ActionResult<bool>> GetAttandecesWeek(ActionArgs<DateTime> args) 
        //{
        //    try
        //    {
        //        DateTime 
        //    }
        //    catch (Exception ex)
        //    {

        //        throw;
        //    }
        //}
    }
}
