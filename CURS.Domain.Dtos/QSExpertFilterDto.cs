using System;
using System.Collections.Generic;
using System.Text;

namespace CURS.Domain.Dtos
{
    public class QSExpertFilterDto : IDto
    {
        public EmployerFilterDto Employer { get; set; }
        public string EmpUniversity { get; set; }
        public string Unit { get; set; }
        public string Position { get; set; }

        public UniversityIdFilterDto University { get; set; }
        public CountryFilterDto Country { get; set; }
        public TitleFilterDto Title { get; set; }
        public BooleanFilterDto Boolean { get; set; }
        public QSFilterDto QS { get; set; }
    }
}
