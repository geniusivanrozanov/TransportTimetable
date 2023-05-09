using TransportTimetable.DAL.Entities;
using TransportTimetable.DAL.Interfaces;

namespace TransportTimetable.DAL.Repositories;

public class TransportTypeRepository : RepositoryBase<TransportType>, ITransportTypeRepository
{
    public TransportTypeRepository(RepositoryContext context) : base(context)
    {
    }
}