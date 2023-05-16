using TransportTimetable.BLL.Interfaces;

namespace TransportTimetable.BLL.DataTransferObjects;

public class TimeTableDto : IDto<Guid>
{
    public Guid Id { get; set; }
    
    public byte Hours { get; set; }
    
    public byte Minutes { get; set; }
    
    public DayOfWeek DayOfWeek { get; set; }
    
    public Guid RouteId { get; set; }
    
    public Guid StopId { get; set; }
}