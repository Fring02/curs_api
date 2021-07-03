using CURS.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using CURS.Domain.Core.Models;
using CURS.Domain.Dtos.Filter;

namespace CURS.Domain.Interfaces.Data
{
    public interface IQSExpertsRepository : IRepository<QSExpert>, IFilter<QSExpertFilterDto, QSExpertViewDto>
    {
    }
}
