using System;
using System.Collections.Generic;
using System.Text;

namespace CURS.Domain.Core.Models
{
    public class University
    {
        public DateTime DateModified { get; set; }
        public DateTime DateOfCreation { get; set; }
        public DateTime ExtraCode { get; set; }
        public int ExtraId { get; set; }
        public Name Name { get; set; }
        public int ParentId { get; set; }
    }
}
