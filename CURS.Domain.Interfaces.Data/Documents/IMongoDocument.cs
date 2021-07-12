using CURS.Domain.Interfaces.Core;

namespace CURS.Domain.Interfaces.Data.Documents
{
    public interface IMongoDocument<TId> : IEntity
    {
        TId Id { get; set; }
    }
}
