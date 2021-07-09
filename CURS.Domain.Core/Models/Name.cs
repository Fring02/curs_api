using System;
using CURS.Domain.Interfaces.Core;

namespace CURS.Domain.Core.Models
{
    public class Name : IEntity
    {
        public string NameEn { get; set; }
        public string NameKk { get; set; }
        public string NameRu { get; set; }

    }
}