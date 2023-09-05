using AutoMapper;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.ViewModels.Route;
using TransportTimetable.ViewModels.Stop;
using TransportTimetable.ViewModels.TimeTable;
using TransportTimetable.ViewModels.TransportType;

namespace TransportTimetable.Mapper;

public class DtoViewModelProfile : Profile
{
    public DtoViewModelProfile()
    {
        CreateMap<TransportTypeDto, TransportTypeViewModel>().ReverseMap();
        CreateMap<TransportTypeViewModelForCreation, TransportTypeDto>().ReverseMap();
        CreateMap<TransportTypeViewModelForUpdate, TransportTypeDto>().ReverseMap();

        CreateMap<RouteDto, RouteViewModel>().ReverseMap();
        CreateMap<RouteDto, RouteWithStopsViewModel>().ReverseMap();
        CreateMap<RouteDto, RouteViewModelForCreation>().ReverseMap();
        CreateMap<RouteDto, RouteViewModelForUpdate>().ReverseMap();
        
        CreateMap<StopDto, StopViewModel>().ReverseMap();
        CreateMap<StopDto, StopViewModelForCreation>().ReverseMap();
        CreateMap<StopDto, StopViewModelForUpdate>().ReverseMap();
        CreateMap<StopDto, StopWithRoutesViewModel>().ReverseMap();
        
        CreateMap<TimeTableDto, TimeTableViewModel>().ReverseMap();
        CreateMap<TimeTableDto, TimeTableViewModelForCreation>().ReverseMap();
        CreateMap<TimeTableDto, TimeTableViewModelForUpdate>().ReverseMap();
    }
}