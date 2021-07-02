namespace CURS.Domain.Dtos
{
    public class QsExpertFieldsFilterDto : IDto
    {
        public bool University { get; set; }
        public bool FioRu { get; set; }
        public bool FioEn { get; set; }
        public bool Country { get; set; }
        public bool EmpUniversity { get; set; }
        public bool Unit { get; set; }
        public bool Position { get; set; }
        public bool Title { get; set; }
        public bool BirthDate { get; set; }
        public bool MobileNumber { get; set; }
        public bool Email { get; set; }
        public bool Boolean { get; set; }
        public bool Qs { get; set; }
    }
}