using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JETech.JEDayCare.Core.Data;

namespace JETech.JEDayCare.Core.Data.Entities
{
    public class SicDbContext : IdentityDbContext<User>
    {
        public SicDbContext() : base()
        {
        }

        public SicDbContext(DbContextOptions<SicDbContext> opcions):base(opcions)
        {
        }

        public DbSet<Contry> Contries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Status> Statues { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GO9IDF3;Database=SIC;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }
    }
}
