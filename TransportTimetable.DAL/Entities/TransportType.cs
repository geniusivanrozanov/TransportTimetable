namespace TransportTimetable.DAL.Entities;

public class TransportType : GuidEntity
{
    public string Name { get; set; } = null!;
    
    public ICollection<Route>? Routes { get; set; }
}