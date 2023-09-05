using TransportTimetable.BLL.DataTransferObjects;

namespace TransportTimetable.BLL.Interfaces;

public interface IRouteService : IServiceBase<RouteDto>
{
    public Task PutStops(Guid id, IEnumerable<Guid> ids);

}