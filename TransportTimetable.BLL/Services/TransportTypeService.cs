using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.BLL.Services;

public class TransportTypeService : ServiceBase<TransportTypeDto, TransportType>, ITransportTypeService
{
    public TransportTypeService(IRepositoryManager repository, IMapper mapper) : base(mapper, repository)
    {
    }
    
    public override async Task<IEnumerable<TransportTypeDto>> GetAll()
    {
        var dto = await RepositoryManager.TransportType
            .Get()
            .AsNoTracking()
            .OrderBy(tt => tt.Name)
            .ProjectTo<TransportTypeDto>(Mapper.ConfigurationProvider)
            .ToArrayAsync();
        
        return dto;
    }
}