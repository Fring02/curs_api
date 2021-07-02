using System.Threading.Tasks;
using CURS.Domain.Dtos;

namespace CURS.Domain.Interfaces.Data
{
    public interface IQsExpertFieldsRepository
    {
        public Task<EntitiesFieldsDto> GetByFields(QsExpertFieldsFilterDto filter);
    }
}