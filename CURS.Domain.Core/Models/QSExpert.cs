using CURS.Domain.Interfaces.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace CURS.Domain.Core.Models
{
    public class QSExpert : IEntity
    {
        public DateTime DateOfCreation { get; set; }
        public DateTime DateModified { get; set; }
        public int ExtraId { get; set; }
        public Employer Employer { get; set; }
        public string EmpUniversity { get; set; }
        public string Unit { get; set; }
        public string Organization { get; set; }
        public string Sector { get; set; }
        public string Position { get; set; }
    }
}
