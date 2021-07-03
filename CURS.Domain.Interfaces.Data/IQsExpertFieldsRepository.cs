using System.Threading.Tasks;
using CURS.Domain.Dtos;
using CURS.Domain.Dtos.Filter;

namespace CURS.Domain.Interfaces.Data
{
    public interface IQsExpertFieldsRepository
    {
        public Task<EntitiesFieldsDto> GetByFields(QsExpertFieldsFilterDto filter);
    }
}