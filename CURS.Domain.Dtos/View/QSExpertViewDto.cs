using System;
using System.Collections.Generic;
using System.Text;

namespace CURS.Domain.Dtos
{
    public class QSExpertViewDto : IDto
    {
        public string FIORu { get; set; }
        public string FIOEn { get; set; }
        public string EmpUniversity { get; set; }
        public string Unit { get; set; }
        public string Position { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public NameDto University { get; set; }
        public NameDto Country { get; set; }
        public NameDto Title { get; set; }
        public NameDto Boolean { get; set; }
        public NameDto QS { get; set; }
    }
}
