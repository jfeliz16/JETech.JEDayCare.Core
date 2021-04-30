using JETech.JEDayCare.Core.Administration.Interfaces;
using JETech.JEDayCare.Core.Data.Entities;
using JETech.NetCoreWeb.Helper;
using JETech.NetCoreWeb.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JETech.JEDayCare.Core.Administration.Services
{
    public class GeneralService : IGeneralService
    {
        private readonly JEDayCareDbContext _dbContext;
        private readonly ActionHelper _actionHelper;

        public GeneralService(JEDayCareDbContext dbContext)
        {
            _dbContext = dbContext;
            _actionHelper = new ActionHelper();
        }

        public ActionPaginationResult<IQueryable<State>> GetStates(ActionQueryArgs<State> args)
        {
            try
            {
                var result = _dbContext.States
                    .Include( c=> c.Contry);

                if (args.Condiction != null) result.Where(args.Condiction);

                return _actionHelper.GetPaginationResult<State>(args, result);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
