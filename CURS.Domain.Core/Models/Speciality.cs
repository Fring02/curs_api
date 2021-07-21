using CURS.Domain.Interfaces.Core;

namespace CURS.Domain.Core.Models
{
    public class Speciality<TId> : IIdEntity<TId>
    {
        public TId ID { get; set; }
    }
}