using AutoMapper;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.BLL.Services;

public class StopService : ServiceBase<StopDto, Stop>, IStopService
{
    public StopService(IMapper mapper, IRepositoryManager repositoryManager) : base(mapper, repositoryManager)
    {
    }
}