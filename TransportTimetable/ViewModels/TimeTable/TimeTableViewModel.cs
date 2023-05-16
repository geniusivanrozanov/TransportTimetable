using TransportTimetable.Interfaces;

namespace TransportTimetable.ViewModels.TimeTable;

public class TimeTableViewModel : IViewModel
{
    public Guid Id { get; set; }
    
    public int Hours { get; set; }
    
    public int Minutes { get; set; }
    
    public DayOfWeek DayOfWeek { get; set; }
}