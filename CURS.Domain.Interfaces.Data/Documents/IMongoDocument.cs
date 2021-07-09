namespace CURS.Domain.Interfaces.Data.Documents
{
    public interface IMongoDocument<TId>
    {
        TId Id { get; set; }
    }
}
