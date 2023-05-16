using TransportTimetable.BLL.Interfaces;

namespace TransportTimetable.BLL.DataTransferObjects;

public class TimeTableDto : IDto<Guid>
{
    public Guid Id { get; set; }
    
    public int Hours { get; set; }
    
    public int Minutes { get; set; }
    
    public DayOfWeek DayOfWeek { get; set; }
    
    public Guid? RouteId { get; set; }
    
    public Guid? StopId { get; set; }
}