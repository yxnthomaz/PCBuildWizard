using System;
using System.Collections.Generic;
using System.Linq;

namespace PCBuildWizard.Main.Domain.Products.Shared
{
    public class ValuatedTable
    {
        private readonly ISet<ValuatedRange> ranges;

        public ValuatedTable(int scale)
        {
            Scale = scale;
            ranges = new HashSet<ValuatedRange>();
        }

        public int Scale { get; }

        public decimal GetValue(decimal point)
        {
            if (point < 0)
                throw new ArgumentOutOfRangeException(nameof(point));

            return ranges.Single(f => f.Contains(point)).GetValue(point);
        }

        internal void Add(decimal end, decimal valueFactor)
        {
            var newRange = new ValuatedRange(end, valueFactor, ranges.LastOrDefault(), Scale);

            ranges.Add(newRange);
        }
    }
}
