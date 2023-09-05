using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.BLL.Services;

public class RouteService : ServiceBase<RouteDto, Route>, IRouteService
{
    public RouteService(IMapper mapper, IRepositoryManager repositoryManager) : base(mapper, repositoryManager)
    {
    }

    public override async Task<IEnumerable<RouteDto>> GetAll()
    {
        var entity = await RepositoryManager.Route
            .Get()
            .Include(r => r.TransportType)
            .AsNoTracking()
            .ToArrayAsync();

        var dto = Mapper.Map<IEnumerable<RouteDto>>(entity);
        
        return dto;
    }

    public async Task PutStops(Guid id, IEnumerable<Guid> ids)
    {
        int order = 0;
        foreach (var stopId in ids)
        {
            RepositoryManager.RouteStop.Create(new RouteStop()
            {
                RouteId = id,
                StopId = stopId,
                Order = ++order
            });
        }

        await RepositoryManager.SaveAsync();
    }
}