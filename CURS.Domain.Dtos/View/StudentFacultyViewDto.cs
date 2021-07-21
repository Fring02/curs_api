using CURS.Domain.Core.Models;

namespace CURS.Domain.Dtos
{
    public class StudentFacultyViewDto<TId>
    {
        public User<TId> User { get; set; }
        public Faculty<TId> Faculty { get; set; }
    }
}