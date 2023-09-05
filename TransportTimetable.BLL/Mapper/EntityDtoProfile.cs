using AutoMapper;
using NetTopologySuite.Geometries;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.DAL.Entities;

namespace TransportTimetable.BLL.Mapper;

public class EntityDtoProfile : Profile
{
    public EntityDtoProfile()
    {
        CreateMap<TransportType, TransportTypeDto>().ReverseMap();

        CreateMap<Route, RouteDto>()
            .ForMember(r => r.Stops, opt =>
            {
                opt.AllowNull();
                opt.MapFrom(x => x.RouteStops.OrderBy(rs => rs.Order).Select(rs => rs.Stop));
            })
            .ForMember(r => r.TransportType, opt =>
            {
                opt.MapFrom(x => x.TransportType.Name);
            })
            .ReverseMap()
            .ForMember(r => r.TransportType, opt =>
            {
                opt.Ignore();
            });

        CreateMap<Stop, StopDto>()
            .ForMember(s => s.X, opt =>
            {
                opt.MapFrom(x => x.Location.X);
            })
            .ForMember(s => s.Y, opt =>
            {
                opt.MapFrom(x => x.Location.Y);
            })
            .ForMember(s => s.Routes, opt =>
            {
                opt.MapFrom(x => x.RouteStops.Select(rs => rs.Route));
            })
            .ReverseMap()
            .ForMember(s => s.Location, opt =>
            {
                opt.MapFrom(x => new Point(x.X, x.Y) {SRID = 4326});
            });

        CreateMap<TimeTable, TimeTableDto>()
            .ForMember(t => t.Hours, opt =>
            {
                opt.MapFrom(x => x.Time.Hours);
            })
            .ForMember(t => t.Minutes, opt =>
            {
                opt.MapFrom(x => x.Time.Minutes);
            })
            .ForMember(t => t.RouteId, opt =>
            {
                opt.MapFrom(x => x.RouteStop.RouteId);
            })
            .ForMember(t => t.StopId, opt =>
            {
                opt.MapFrom(x => x.RouteStop.StopId);
            })
            .ReverseMap()
            .ForMember(t => t.Time, opt =>
            {
                opt.MapFrom(x => new TimeSpan(x.Hours, x.Minutes, 0) { });
            })
            .ForMember(t => t.RouteStop, opt =>
            {
                opt.Ignore();
            });
    }
}