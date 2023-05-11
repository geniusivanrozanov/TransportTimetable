using AutoMapper;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.BLL.Services;

public abstract class ServiceBase<TDto> : IServiceBase<TDto>
{
    protected readonly IMapper Mapper;
    protected readonly IRepositoryManager Repository;

    protected ServiceBase(IMapper mapper, IRepositoryManager repository)
    {
        Mapper = mapper;
        Repository = repository;
    }

    public abstract Task<IEnumerable<TDto>> GetAll();

    public abstract Task<TDto?> GetById(Guid id);

    public abstract Task Create(TDto dto);

    public abstract Task Update(Guid id, TDto dto);

    public abstract Task Delete(Guid id);
    
    public abstract Task<bool> IsExist(Guid id);
}