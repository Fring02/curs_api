using System;

namespace CURS.Domain.Dtos.Filter
{
    public class UniversityFilterDto : IFilterDto
    {
        public DateTime DateModified { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int ExtraId { get; set; }
        public string Name { get; set; }
    }
}
