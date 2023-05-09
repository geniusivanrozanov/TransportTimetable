using System.ComponentModel.DataAnnotations;

namespace TransportTimetable.DAL.Entities;

public class TransportType
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;
    
    public ICollection<Route>? Routes { get; set; }
}