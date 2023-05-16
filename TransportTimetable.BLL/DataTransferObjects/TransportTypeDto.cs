using TransportTimetable.BLL.Interfaces;

namespace TransportTimetable.BLL.DataTransferObjects;

public class TransportTypeDto : IDto<Guid>
{
    public Guid Id { get; set; }

    public string Name { get; set; } = null!;
}