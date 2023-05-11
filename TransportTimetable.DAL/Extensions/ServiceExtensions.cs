using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetTopologySuite.Triangulate.Tri;
using TransportTimetable.DAL.Interfaces;
using TransportTimetable.DAL.Repositories;

namespace TransportTimetable.DAL.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("sqlConnection");
        services.AddDbContext<RepositoryContext>(options =>
        {
            options.UseSqlServer(
                connectionString,
                sqlServerOptions =>
                {
                    sqlServerOptions.UseNetTopologySuite();
                });
        });
        
        return services;
    }

    public static IServiceCollection AddRepositoryManager(this IServiceCollection services)
    {
        services.AddScoped<IRepositoryManager, RepositoryManager>();
        
        return services;
    }
}