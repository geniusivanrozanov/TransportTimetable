using Microsoft.Extensions.DependencyInjection;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.BLL.Services;

namespace TransportTimetable.BLL.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection AddBllServices(this IServiceCollection services)
    {
        services.AddScoped<ITransportTypeService, TransportTypeService>();

        return services;
    }
}