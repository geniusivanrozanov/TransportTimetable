using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.DAL.Repositories;

public class RouteRepository : RepositoryBase<Route>, IRouteRepository
{
    public RouteRepository(RepositoryContext context) : base(context)
    {
    }
}