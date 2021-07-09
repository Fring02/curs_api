using CURS.Domain.Core.Models;
using CURS.Domain.Dtos;
using CURS.Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CURS.Domain.Dtos.Filter;

namespace CURS.Domain.Interfaces.Data
{
    public interface IUniversitiesRepository : IRepository<University, UniversityViewDto>, IFilter<UniversityFilterDto, UniversityViewDto>
    {
    }
}
