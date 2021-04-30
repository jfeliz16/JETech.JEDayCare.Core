using JETech.JEDayCare.Core.Administration.Interfaces;
using JETech.JEDayCare.Core.Administration.Services;
using JETech.JEDayCare.Core.Clients.Interfaces;
using JETech.JEDayCare.Core.Clients.Services;
using JETech.JEDayCare.Core.Data;
using JETech.JEDayCare.Core.User.Interfaces;
using JETech.JEDayCare.Core.User.Services;
using Microsoft.Extensions.DependencyInjection;

namespace JETech.JEDayCare.Core.Extensions
{
    public static class JEDayCareDependenceInjections
    {
        public static void AddJEDayCareDependences(this IServiceCollection services) 
        {
            services.AddTransient<SeedDb>();            
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IGeneralService, GeneralService>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
