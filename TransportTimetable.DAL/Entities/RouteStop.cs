namespace TransportTimetable.DAL.Entities;

public class RouteStop
{
    public Guid Id { get; set; }
    
    public int Order { get; set; }
    
    public Guid RouteId { get; set; }
    public Route? Route { get; set; }
    
    public Guid StopId { get; set; }
    public Stop? Stop { get; set; }
    
    public ICollection<TimeTable>? TimeTables { get; set; }
}