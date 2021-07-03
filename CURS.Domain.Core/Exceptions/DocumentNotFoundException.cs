using System;

namespace CURS.Domain.Core.Exceptions
{
    public class DocumentNotFoundException : Exception
    {
        public DocumentNotFoundException(string message) : base(message)
        {
            
        }
    }
}