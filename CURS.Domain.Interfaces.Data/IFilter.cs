using CURS.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CURS.Domain.Interfaces.Data
{
    public interface IFilter<in TFilterDto, TResponseDto> where TFilterDto : IDto where TResponseDto : IDto
    {
        Task<IEnumerable<TResponseDto>> GetByFilter(TFilterDto filter);
    }
}
