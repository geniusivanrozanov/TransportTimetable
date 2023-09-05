using TransportTimetable.BLL.DataTransferObjects;

namespace TransportTimetable.BLL.Interfaces;

public interface ITimeTableService : IServiceBase<TimeTableDto>
{
    public Task<IEnumerable<TimeTableDto>> GetByRoteAndStop(Guid routeId, Guid stopId);
}