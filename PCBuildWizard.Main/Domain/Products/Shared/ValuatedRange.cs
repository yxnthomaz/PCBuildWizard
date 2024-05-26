using System;

namespace PCBuildWizard.Main.Domain.Products.Shared
{
    public class ValuatedRange
    {
        private readonly Range<decimal> range;

        public ValuatedRange(decimal end, decimal valueFactor, ValuatedRange priorRange, int scale)
        {
            //if (priorRange != null && !priorRange.End.HasValue)
            //throw new ArgumentOutOfRangeException(nameof(priorRange));

            decimal epslon = (decimal)Math.Pow(10d, -scale);

            var begin = priorRange == null ? 0m : priorRange.End + epslon;
            range = new Range<decimal>(begin, end);

            ValueFactor = valueFactor;

            ReductionValue = priorRange == null ? 0m : priorRange.ReductionValue +
                Math.Round(priorRange.End * (valueFactor - priorRange.ValueFactor), scale);
        }

        public decimal Begin { get { return range.Begin; } }

        public decimal End { get { return range.End; } }

        public decimal ValueFactor { get; private set; }

        public decimal ReductionValue { get; private set; }

        public bool Contains(decimal point)
        {
            return range.Contains(point);
        }

        public decimal GetValue(decimal point)
        {
            if (!range.Contains(point))
                throw new ArgumentOutOfRangeException(nameof(point));

            return Math.Round(point * ValueFactor - ReductionValue, 2);
        }
    }
}
