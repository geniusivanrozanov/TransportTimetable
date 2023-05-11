using AutoMapper;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.ViewModels.TransportType;

namespace TransportTimetable.Mapper;

public class DtoViewModelProfile : Profile
{
    public DtoViewModelProfile()
    {
        CreateMap<TransportTypeDto, TransportTypeViewModel>().ReverseMap();
    }
}