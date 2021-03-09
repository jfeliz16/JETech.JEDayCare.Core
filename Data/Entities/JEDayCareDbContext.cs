using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JETech.JEDayCare.Core.Data;

namespace JETech.JEDayCare.Core.Data.Entities
{
    public class JEDayCareDbContext : IdentityDbContext<User>
    {
        public JEDayCareDbContext() : base()
        {
        }

        public JEDayCareDbContext(DbContextOptions<JEDayCareDbContext> opcions):base(opcions)
        {
        }

        public DbSet<Contry> Contries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Status> Statues { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Attribute> Attributes { get; set; }
        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=DESKTOP-GO9IDF3;Database=JEDayCare;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            BuildPerson(builder);
            BuildClient(builder);                
        }

        private void BuildPerson(ModelBuilder builder)
        {
            builder.Entity<Person>()
                   .Property(p => p.InitDate)
                   .HasDefaultValueSql("getdate()");
        }

        private void BuildClient(ModelBuilder builder) 
        {
            builder.Entity<Client>()
                   .HasOne(c => c.Parent)
                   .WithMany()
                   .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
