using System;
using System.Collections.Generic;

namespace CURS.Domain.Core.Models
{
    public class AhdCubeData
    {
        public DateTime DateOfCreation { get; set; }
        public DateTime DateModified { get; set; }
        public int Index { get; set; }
        public string PeriodType { get; set; }
        public bool Accumulation { get; set; }
        public DateTime DateEnd { get; set; }
        public IEnumerable<AhdItem> Items { get; set; }
    }

    public class AhdItem
    {
        public double Value { get; set; }
        public List<AhdItemPair> Pairs { get; set; }
    }

    public class AhdItemPair
    {
        public string Code { get; set; }
        public string Value { get; set; }
    }
}