using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.DAL.Repositories;

public class StopRepository : RepositoryBase<Stop>, IStopRepository
{
    public StopRepository(RepositoryContext context) : base(context)
    {
    }
}