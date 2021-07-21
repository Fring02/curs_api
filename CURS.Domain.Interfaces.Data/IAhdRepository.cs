using System.Threading.Tasks;

namespace CURS.Domain.Interfaces.Data
{
    public interface IAhdRepository
    {
        Task CalculateStudentsWithTranscript();
    }
}