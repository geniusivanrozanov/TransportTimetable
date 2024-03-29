﻿using TransportTimetable.BLL.Interfaces;

namespace TransportTimetable.BLL.DataTransferObjects;

public class StopDto : IDto<Guid>
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = null!;

    public double X { get; set; }
    
    public double Y { get; set; }
    
    public ICollection<RouteDto>? Routes { get; set; }
}