using CURS.Domain.Interfaces.Core;

namespace CURS.Domain.Core.Models
{
    public class Degree<TId> : IIdEntity<TId>
    {
        public TId ID { get; set; }
    }
}