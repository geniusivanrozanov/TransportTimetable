using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.DAL.Repositories;

public class RouteStopRepository : RepositoryBase<RouteStop>, IRouteStopRepository
{
    public RouteStopRepository(RepositoryContext context) : base(context)
    {
    }
}