using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.DAL.Repositories;

public class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _context;

    private IRouteRepository? _routeRepository;
    private IStopRepository? _stopRepository;
    private ITransportTypeRepository? _transportTypeRepository;
    private ITimeTableRepository? _timeTableRepository;

    public RepositoryManager(RepositoryContext context)
    {
        _context = context;
    }

    public IRouteRepository Route => _routeRepository ??= new RouteRepository(_context);
    public IStopRepository Stop => _stopRepository ??= new StopRepository(_context);
    public ITransportTypeRepository TransportType => _transportTypeRepository ??= new TransportTypeRepository(_context);
    public ITimeTableRepository TimeTable => _timeTableRepository ??= new TimeTableRepository(_context);

    public void Save() => _context.SaveChanges();
    public Task SaveAsync() => _context.SaveChangesAsync();
    public IRepositoryBase<TEntity> RepositoryFor<TEntity>() where TEntity : GuidEntity
    {
        var entityType = typeof(TEntity);

        if (entityType == typeof(Route))
            return Route as IRepositoryBase<TEntity> ?? throw new InvalidOperationException();
        if (entityType == typeof(Stop))
            return Stop as IRepositoryBase<TEntity> ?? throw new InvalidOperationException();
        if (entityType == typeof(TransportType))
            return TransportType as IRepositoryBase<TEntity> ?? throw new InvalidOperationException();
        if (entityType == typeof(TimeTable))
            return TimeTable as IRepositoryBase<TEntity> ?? throw new InvalidOperationException();
        
        throw new ArgumentException();
    }
}