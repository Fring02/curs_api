using CURS.Domain.Core.Models;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CURS.Domain.Interfaces.Data
{
    public interface IUniversitiesRepository : IRepository<University>
    {
        Task<IEnumerable<UniversityViewDto>> GetByFilter(UniversityFilterDto filter);
    }
}
