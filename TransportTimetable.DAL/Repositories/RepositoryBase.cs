using System.Linq.Expressions;
using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.DAL.Repositories;

public abstract class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : GuidEntity
{
    private readonly RepositoryContext _context;

    protected RepositoryBase(RepositoryContext context)
    {
        _context = context;
    }

    public IQueryable<TEntity> Get() => _context.Set<TEntity>();

    public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition) => _context.Set<TEntity>().Where(condition);

    public void Create(TEntity entity) => _context.Set<TEntity>().Add(entity);

    public void Update(TEntity entity) => _context.Set<TEntity>().Update(entity);

    public void Delete(TEntity entity) => _context.Set<TEntity>().Remove(entity);
}