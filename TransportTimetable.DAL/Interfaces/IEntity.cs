namespace TransportTimetable.DAL.Interfaces;

public interface IEntity<TId>
{
    TId Id { get; set; }
}