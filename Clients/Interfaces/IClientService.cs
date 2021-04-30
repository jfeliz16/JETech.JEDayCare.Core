﻿using JETech.NetCoreWeb;
using JETech.NetCoreWeb.Types;
using JETech.JEDayCare.Core.Clients.Models;
using System.Linq;
using System.Threading.Tasks;

namespace JETech.JEDayCare.Core.Clients.Interfaces
{
    public interface IClientService
    {
        Task<ActionResult<int>> Create(ActionArgs<ClientModel> args);
        ActionPaginationResult<IQueryable<ClientModel>> GetClients(ActionQueryArgs<ClientModel> args);
        ActionResult<ClientModel> GetClientById(int id);
    }
}