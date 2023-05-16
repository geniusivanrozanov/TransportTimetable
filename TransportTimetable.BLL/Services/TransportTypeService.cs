using AutoMapper;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.BLL.Services;

public class TransportTypeService : ServiceBase<TransportTypeDto, TransportType>, ITransportTypeService
{
    public TransportTypeService(IMapper mapper, IRepositoryManager repositoryManager) : base(mapper, repositoryManager)
    {
    }
}