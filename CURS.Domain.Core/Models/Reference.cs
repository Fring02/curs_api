using System;
using CURS.Domain.Interfaces.Core;

namespace CURS.Domain.Core.Models
{
    public class Reference : IEntity
    {
        public string UniqueNumber { get; set; }
        public DateTime DateOfCreate { get; set; }
        public DateTime DateModified { get; set; }
        public int Code { get; set; }
    }
}