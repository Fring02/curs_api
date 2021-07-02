using System;
using System.Collections.Generic;

namespace CURS.Domain.Dtos
{
    public class EntitiesFieldsDto : IDto
    {
        public IEnumerable<NameDto> Universities { get; set; }
        public IEnumerable<string> FioRus { get; set; }
        public IEnumerable<string> FioEngs { get; set; }
        public IEnumerable<NameDto> Countries { get; set; }
        public IEnumerable<string> EmpUniversities { get; set; }
        public IEnumerable<string> Units { get; set; }
        public IEnumerable<string> Positions { get; set; }
        public IEnumerable<NameDto> Titles { get; set; }
        public IEnumerable<DateTime> BirthDates { get; set; }
        public IEnumerable<string> MobileNumbers { get; set; }
        public IEnumerable<string> Emails { get; set; }
        public IEnumerable<NameDto> Booleans { get; set; }
        public IEnumerable<NameDto> Qss { get; set; }
    }
}