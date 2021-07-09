using CURS.Domain.Core.Models;

namespace CURS.Domain.Dtos
{
    public class ProgrammeViewDto : IDto
    {
        public int ID { get; set; }
        public string ATT_DISCIPLINE { get; set; }
        public string ATT_SPECIALITIES { get; set; }
        public string ATT_COURSES { get; set; }
        public string ATT_LANGUAGE_DEPARTMENTS { get; set; }
        public double ATT_TOTAL_CREDITS { get; set; }
        public int ATT_COUNT_OF_STUDENTS { get; set; }
        public string ATT_GROUPES { get; set; }
        public int ATT_SUBGROUPS { get; set; }
        public double ATT_TOTAL { get; set; }
        public string ATT_LESSON_TYPE { get; set; }
        public double ATT_LECTURE_FACT { get; set; }
        public string ATT_PRACTICE_FACT  => "факт";
        public double ATT_LABORATORY_FACT { get; set; }
        public double ATT_SRSP_FACT { get; set; }
        public int? ATT_GROUP_CODE { get; set; }
        public int? ATT_CONNECTION_CODE { get; set; } 
    }
}