﻿namespace TransportTimetable.DAL.Entities;

public class TimeTable
{
    public Guid Id { get; set; }
    
    public TimeSpan Time { get; set; }
    
    public DayOfWeek DayOfWeek { get; set; }
    
    public Guid RouteStopId { get; set; }
    public RouteStop? RouteStop { get; set; }
}