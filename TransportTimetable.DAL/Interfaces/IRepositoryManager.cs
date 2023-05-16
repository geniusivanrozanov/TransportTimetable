using TransportTimetable.DAL.Entities;

namespace TransportTimetable.DAL.Interfaces;

public interface IRepositoryManager
{
    IRouteRepository Route { get; }
    IStopRepository Stop { get; }
    ITransportTypeRepository TransportType { get; }
    ITimeTableRepository TimeTable { get; }

    void Save();
    Task SaveAsync();

    IRepositoryBase<TEntity> RepositoryFor<TEntity>() where TEntity : GuidEntity;
}