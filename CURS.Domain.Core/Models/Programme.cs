using CURS.Domain.Interfaces.Core;

namespace CURS.Domain.Core.Models
{
    public class Programme : IEntity
    {
        public int ID { get; set; }
        public string ATT_DISCIPLINE { get; set; }
        public string ATT_SPECIALITIES { get; set; }
        public int ATT_COURSES { get; set; }
        public string ATT_LANGUAGE_DEPARTMENTS { get; set; }
        public double ATT_TOTAL_CREDITS { get; set; }
        public int ATT_COUNT_OF_STUDENTS { get; set; }
        public int ATT_GROUPS { get; set; }
        public int ATT_SUBGROUPS { get; set; }
        public double ATT_TOTAL { get; set; }
        public string ATT_LESSON_TYPE { get; set; }
        public double ATT_LECTURE { get; set; }
        public double ATT_LECTURE_FACT { get; set; }
        public double ATT_PRACTICE { get; set; }
        public double ATT_PRACTICE_FACT { get; set; }
        public double ATT_LABORATORY { get; set; }
        public double ATT_LABORATORY_FACT { get; set; }
        public double ATT_SRSP { get; set; }
        public double ATT_SRSP_FACT { get; set; }
        public double ATT_STUDY_PRACTICE { get; set; }
        public double ATT_PROD_PRACTICE { get; set; }
        public double ATT_PED_PRACTICE { get; set; }
        public double ATT_DIPLOMA_PRACTICE { get; set; }
        public double ATT_RESEARCH_PRACTICE { get; set; }
        public double ATT_LANGUAGE_PRACTICE { get; set; }
        public double ATT_DIPLOMA_WORK { get; set; }
        public double ATT_DISSERTATION { get; set; }
        public double ATT_GOS { get; set; }
        public double ATT_OTHER { get; set; }
        public double ATT_VALUE { get; set; }
        public int? ATT_GROUP_CODE { get; set; }
        public int? ATT_CONNECTION_CODE { get; set; } 
    }
}