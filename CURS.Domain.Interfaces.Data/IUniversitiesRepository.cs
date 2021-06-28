using CURS.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CURS.Domain.Interfaces.Data
{
    public interface IUniversitiesRepository<TViewDto> where TViewDto : class
    {
       Task<IEnumerable<TViewDto>> GetByFilter(string name);
    }
}
