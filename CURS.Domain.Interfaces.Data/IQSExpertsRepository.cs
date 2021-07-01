using CURS.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace CURS.Domain.Interfaces.Data
{
    public interface IQSExpertsRepository : IFilter<QSExpertFilterDto, QSExpertViewDto>
    {
    }
}
