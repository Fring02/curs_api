using CURS.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CURS.Domain.Dtos.Filter;

namespace CURS.Domain.Interfaces.Data
{
    public interface IFilter<in TFilterDto, TResponseDto> where TFilterDto : IFilterDto where TResponseDto : IDto
    {
        Task<IEnumerable<TResponseDto>> GetByFilter(TFilterDto filter);
    }
}
