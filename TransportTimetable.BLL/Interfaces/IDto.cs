namespace TransportTimetable.BLL.Interfaces;

public interface IDto<TId>
{
    TId Id { get; set; }
}