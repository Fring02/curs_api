using System.Collections.Generic;

namespace CURS.Infrastructure.Data.Utils
{
    public class ProgrammesComparer : IComparer<List<object>>
    {
        public int Compare(List<object> x, List<object> y)
        {
            return (int) x[0] - (int) y[0];
        }
    }
}