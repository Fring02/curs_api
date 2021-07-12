using System.Collections.Generic;

namespace CURS.Domain.Dtos
{
    public class GrouppedProgrammesViewDto : IDto
    {
        public string RelationKey { get; set; }
        public IEnumerable<ProgrammeViewDto> Programmes { get; set; }
    }
}