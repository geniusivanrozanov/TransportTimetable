using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.BLL.Services;

public class TimeTableService : ServiceBase<TimeTableDto, TimeTable>, ITimeTableService
{
    public TimeTableService(IMapper mapper, IRepositoryManager repositoryManager) : base(mapper, repositoryManager)
    {
    }

    public override async Task Create(TimeTableDto dto)
    {
        var entity = Mapper.Map<TimeTable>(dto);

        var routeStop = await RepositoryManager.RouteStop
            .Get(rs => rs.RouteId.Equals(dto.RouteId) && rs.StopId.Equals(dto.StopId))
            .SingleOrDefaultAsync();

        if (routeStop == null)
        {
            throw new ArgumentException("Bad routeId or stopId");
        }

        entity.RouteStop = routeStop;
        
        RepositoryManager.TimeTable.Create(entity);

        await RepositoryManager.SaveAsync();

        Mapper.Map(entity, dto);
    }

    public async Task<IEnumerable<TimeTableDto>> GetByRoteAndStop(Guid routeId, Guid stopId)
    {
        var rs = await RepositoryManager.RouteStop
            .Get(rs => rs.RouteId.Equals(routeId) && rs.StopId.Equals(stopId))
            .SingleOrDefaultAsync();

        var tt = await RepositoryManager.TimeTable
            .Get(tt => tt.RouteStopId.Equals(rs.Id))
            .ProjectTo<TimeTableDto>(Mapper.ConfigurationProvider)
            .ToListAsync();

        return tt;
    }
}