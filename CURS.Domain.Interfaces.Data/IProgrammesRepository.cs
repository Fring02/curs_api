using CURS.Domain.Core.Models;
using CURS.Domain.Dtos;

namespace CURS.Domain.Interfaces.Data
{
    public interface IProgrammesRepository : IRepository<Programme, GrouppedProgrammesViewDto>
    {
        
    }
}