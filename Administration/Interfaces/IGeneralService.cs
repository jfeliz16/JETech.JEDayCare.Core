using JETech.JEDayCare.Core.Data.Entities;
using JETech.NetCoreWeb.Types;
using System.Linq;

namespace JETech.JEDayCare.Core.Administration.Interfaces
{
    public interface IGeneralService
    {
        ActionPaginationResult<IQueryable<State>> GetStates(ActionQueryArgs<State> args);
    }
}