namespace TransportTimetable.BLL.Interfaces;

public interface IServiceBase<TDto>
{
    Task<IEnumerable<TDto>> GetAll();
    Task<TDto?> GetById(Guid id);
    Task Create(TDto dto);
    Task Update(Guid id, TDto dto);
    Task Delete(Guid id);
    Task<bool> IsExist(Guid id);
}