using System.Linq.Expressions;

namespace TransportTimetable.DAL.Interfaces;

public interface IRepositoryBase<TEntity>
{
    IQueryable<TEntity> Get();
    IQueryable<TEntity> Get(Expression<Func<TEntity, bool>> condition);
    void Create(TEntity entity);
    void Update(TEntity entity);
    void Delete(TEntity entity);
}