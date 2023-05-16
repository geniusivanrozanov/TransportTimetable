using TransportTimetable.BLL.Interfaces;

namespace TransportTimetable.BLL.DataTransferObjects;

public class RouteDto : IDto<Guid>
{
    public Guid Id { get; set; }
    
    public string Number { get; set; } = null!;
    
    public string? Name { get; set; }
    
    public Guid TransportTypeId { get; set; }
    public string? TransportType { get; set; }
}