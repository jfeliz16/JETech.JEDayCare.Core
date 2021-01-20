using JETech.JEDayCare.Core.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JETech.JEDayCare.Core.Data
{
    public class SeedDb
    {
        private readonly JEDayCareDbContext _dbContext;

        public SeedDb(JETech.JEDayCare.Core.Data.Entities.JEDayCareDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task SeedAsync() 
        {
            await _dbContext.Database.EnsureCreatedAsync();
            await CheckStatus();
        }

        private async Task CheckStatus() 
        {
            if (!_dbContext.Statues.Any())
            {
                _dbContext.Statues.Add(new Status { Id = 1, Name = "Activo" });
                _dbContext.Statues.Add(new Status { Id = 2, Name = "Inactivo" });

                await _dbContext.SaveChangesAsync();
            }
        } 
    }
}
