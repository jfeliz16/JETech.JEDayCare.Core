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

namespace JETech.JEDayCare.Core.Clients.Services
{
    public class ClientService : IClientService
    {
        private readonly SicDbContext _dbContext;
        private readonly Domain.Client _client;

        public ClientService(SicDbContext dbContext) {
            _dbContext = dbContext;
            _client = new Domain.Client(dbContext);
        }

        public ActionPaginationResult<IQueryable<ClientModel>> GetClients(ActionQueryArgs<ClientModel> args)
        {
            try
            {
                return _client.Get(args);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
