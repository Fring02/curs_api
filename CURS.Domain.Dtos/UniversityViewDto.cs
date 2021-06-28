using CURS.Domain.Core.Models;
using System;

namespace CURS.Domain.Dtos
{
    public class UniversityViewDto
    {
        public DateTime DateModified { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int ExtraId { get; set; }
        public Name Name { get; set; }
    }
}
