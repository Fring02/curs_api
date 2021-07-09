using System;

namespace CURS.Domain.Core.Exceptions
{
    public class DocumentPresentException : Exception
    {
        public DocumentPresentException(string mes) : base(mes)
        {
            
        }
    }
}