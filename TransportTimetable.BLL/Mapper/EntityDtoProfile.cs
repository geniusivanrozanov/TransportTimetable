using AutoMapper;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.DAL.Entities;

namespace TransportTimetable.BLL.Mapper;

public class EntityDtoProfile : Profile
{
    public EntityDtoProfile()
    {
        CreateMap<TransportType, TransportTypeDto>().ReverseMap();
    }
}