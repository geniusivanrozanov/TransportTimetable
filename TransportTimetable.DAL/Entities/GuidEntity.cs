using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.DAL.Entities;

public abstract class GuidEntity : IEntity<Guid>
{
    public Guid Id { get; set; }
}