using System;
using System.Collections.Generic;

namespace CURS.Domain.Core.Models
{
    public class AhdCubesInfo<TId>
    {
        public int Index { get; set; }
        public string Collection { get; set; }
        public string ExtraCollection { get; set; }
        public string LocalField { get; set; }
        public string ForeignField { get; set; }
        public TId RelationId { get; set; }
        public AhdCubesInfoFilter Filters { get; set; }
        public string PeriodType { get; set; }
        public bool Accumulation { get; set; }
        public DateTime SplitByDate { get; set; }
    }
}