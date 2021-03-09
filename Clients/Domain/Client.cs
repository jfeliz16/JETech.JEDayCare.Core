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
        private readonly JEDayCareDbContext _sicDb;

        public Client(JEDayCareDbContext sicDb)
        {
            _actionHelper = new ActionHelper();
            _sicDb = sicDb;
        }

        public ActionPaginationResult<IQueryable<ClientModel>> Get(ActionQueryArgs<ClientModel> args)
        {
            try
            {
                var result = _sicDb.Clients
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
                        FirstNameChild =c.Person.FirstName,
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
    }
}

