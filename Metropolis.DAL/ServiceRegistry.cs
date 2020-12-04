using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Metropolis.DAL
{
    public static class ServiceRegistry
    {
        public static void RegisterDataServices(this IServiceCollection services, IConfiguration Configuration)
        {
            var ConnectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(ConnectionString));

        }
    }
}
