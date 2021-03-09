using JETech.JEDayCare.Core.Administration.Models;
using JETech.NetCoreWeb.Types;
using System.Threading.Tasks;

namespace JETech.JEDayCare.Core.Administration.Interfaces
{
    public interface IPersonService
    {
        Task<ActionResult<int>> Create(ActionArgs<PersonModel> args);
    }
}