using Microsoft.Build.Framework;
using TransportTimetable.Interfaces;

namespace TransportTimetable.ViewModels.TransportType;

public class TransportTypeViewModelForUpdate : TransportTypeViewModelForManipulation, IViewModelForUpdate
{
    [Required]
    public Guid Id { get; set; }
}