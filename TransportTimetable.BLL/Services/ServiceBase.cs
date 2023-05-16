using AutoMapper;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.BLL.Services;

public abstract class ServiceBase<TDto, TEntity> : IServiceBase<TDto>
    where TEntity : GuidEntity
    where TDto : IDto<Guid>
{
    private readonly IRepositoryBase<TEntity> _repository;
    
    protected readonly IMapper Mapper;
    protected readonly IRepositoryManager RepositoryManager;

    protected ServiceBase(IMapper mapper, IRepositoryManager repositoryManager)
    {
        Mapper = mapper;
        RepositoryManager = repositoryManager;
        _repository = RepositoryManager.RepositoryFor<TEntity>();
    }

    public virtual async Task<IEnumerable<TDto>> GetAll()
    {
        var dto = await _repository
            .Get()
            .AsNoTracking()
            .ProjectTo<TDto>(Mapper.ConfigurationProvider)
            .ToArrayAsync();
        
        return dto;
    }

    public virtual async Task<TDto?> GetById(Guid id)
    {
        var dto = await _repository
            .Get(e => e.Id.Equals(id))
            .AsNoTracking()
            .ProjectTo<TDto>(Mapper.ConfigurationProvider)
            .SingleOrDefaultAsync();
        
        return dto;
    }

    public virtual async Task Create(TDto dto)
    {
        var entity = Mapper.Map<TEntity>(dto);

        _repository.Create(entity);

        await RepositoryManager.SaveAsync();

        Mapper.Map(entity, dto);
    }

    public virtual async Task Update(Guid id, TDto dto)
    {
        dto.Id = id;
        
        var entity = await _repository
            .Get(e => e.Id.Equals(id))
            .FirstOrDefaultAsync();

        Mapper.Map(dto, entity);

        await RepositoryManager.SaveAsync();
    }

    public virtual async Task Delete(Guid id)
    {
        TEntity entity = Activator.CreateInstance<TEntity>();
        entity.Id = id;

        _repository.Delete(entity);

        await RepositoryManager.SaveAsync();
    }

    public virtual async Task<bool> IsExist(Guid id)
    {
        return await _repository
            .Get(e => e.Id.Equals(id))
            .AnyAsync();
    }
}