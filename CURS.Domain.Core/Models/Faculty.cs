using CURS.Domain.Interfaces.Core;

namespace CURS.Domain.Core.Models
{
    public class Faculty<TId> : IIdEntity<TId>
    {
        public TId ID { get; set; }
    }
}