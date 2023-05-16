using Microsoft.Build.Framework;
using TransportTimetable.Interfaces;

namespace TransportTimetable.ViewModels.Route;

public class RouteViewModelForUpdate : IViewModelForUpdate
{
    [Required]
    public Guid Id { get; set; }
    
    [Required]
    public string Number { get; set; } = null!;
    
    public string? Name { get; set; }
    
    [Required]
    public Guid TransportTypeId { get; set; }
}