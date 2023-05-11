using AutoMapper;
using TransportTimetable.BLL.Mapper;
using TransportTimetable.Mapper;

namespace TransportTimetable.Extensions;

public static class ServiceExtensions
{
    public static IServiceCollection ConfigureCors(this IServiceCollection services)
    {
        services.AddCors(options =>
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader()
            )
        );

        return services;
    }

    public static IServiceCollection ConfigureAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(EntityDtoProfile), typeof(DtoViewModelProfile));

        return services;
    }
}