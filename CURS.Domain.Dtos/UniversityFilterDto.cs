using CURS.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CURS.Domain.Dtos
{
    public class UniversityFilterDto
    {
        public DateTime DateModified { get; set; }
        public DateTime DateOfCreation { get; set; }
        public int ExtraId { get; set; }
        public string Name { get; set; }
    }
}
