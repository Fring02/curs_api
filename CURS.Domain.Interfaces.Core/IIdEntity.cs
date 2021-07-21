namespace CURS.Domain.Interfaces.Core
{
    public interface IIdEntity<TId>
    {
        public TId ID { get; set; }
    }
}