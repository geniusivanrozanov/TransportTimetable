using AutoMapper;
using Microsoft.EntityFrameworkCore;
using TransportTimetable.BLL.DataTransferObjects;
using TransportTimetable.BLL.Interfaces;
using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.BLL.Services;

public class TransportTypeService : ServiceBase<TransportTypeDto>, ITransportTypeService
{
    public TransportTypeService(IRepositoryManager repository, IMapper mapper) : base(mapper, repository)
    {
    }

    public override async Task<IEnumerable<TransportTypeDto>> GetAll()
    {
        var entities = await Repository
            .TransportType
            .Get()
            .AsNoTracking()
            .ToArrayAsync();

        var transportTypes = Mapper.Map<IEnumerable<TransportTypeDto>>(entities);

        return transportTypes;
    }

    public override async Task<TransportTypeDto?> GetById(Guid id)
    {
        var entity = await Repository
            .TransportType
            .Get(tt => tt.Id.Equals(id))
            .AsNoTracking()
            .FirstOrDefaultAsync();

        var transportType = Mapper.Map<TransportTypeDto?>(entity);

        return transportType;
    }

    public override async Task Create(TransportTypeDto dto)
    {
        var entity = Mapper.Map<TransportType>(dto);
        
        Repository.TransportType.Create(entity);

        await Repository.SaveAsync();

        Mapper.Map(entity, dto);
    }

    public override async Task Update(Guid id, TransportTypeDto dto)
    {
        var entity = await Repository
            .TransportType
            .Get(tt => tt.Id.Equals(id))
            .FirstOrDefaultAsync();

        Mapper.Map(dto, entity);

        await Repository.SaveAsync();
    }

    public override async Task Delete(Guid id)
    {
        var entity = new TransportType { Id = id };
        
        Repository.TransportType.Delete(entity);

        await Repository.SaveAsync();
    }

    public override async Task<bool> IsExist(Guid id)
    {
        return await Repository
            .TransportType
            .Get(tt => tt.Id.Equals(id))
            .AsNoTracking()
            .AnyAsync();
    }
}