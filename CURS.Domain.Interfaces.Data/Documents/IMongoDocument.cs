using System;
using System.Collections.Generic;
using System.Text;

namespace CURS.Domain.Interfaces.Data.Documents
{
    public interface IMongoDocument<TId>
    {
        TId Id { get; set; }
    }
}
