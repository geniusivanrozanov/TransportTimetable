using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.DAL.Repositories;

public class TimeTableRepository : RepositoryBase<TimeTable>, ITimeTableRepository
{
    public TimeTableRepository(RepositoryContext context) : base(context)
    {
    }
}