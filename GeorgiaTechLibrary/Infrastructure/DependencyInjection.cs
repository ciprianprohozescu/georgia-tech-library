using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Persistance;
using Application.Interfaces;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryDbContext>(options =>
                    options.UseSqlServer(
                        configuration.GetConnectionString("LibraryConnection"),
                        b => b.MigrationsAssembly(typeof(LibraryDbContext).Assembly.FullName)));

            services.AddScoped<ILibraryDbContext>(provider => provider.GetService<LibraryDbContext>());

            return services;
        }
    }
}
