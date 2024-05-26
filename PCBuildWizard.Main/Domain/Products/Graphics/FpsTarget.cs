using System.Collections.Generic;
using System.Linq;

namespace PCBuildWizard.Main.Domain.Products.Graphics
{
    public class FpsTarget
    {
        private const decimal BaseExponent = 0.75m;

        public static FpsTarget Low = new FpsTarget(30, BaseExponent * BaseExponent, 0.125m, "30");

        public static FpsTarget Medium = new FpsTarget(60, BaseExponent, 0.5m, "De 60 a 75");

        public static FpsTarget High = new FpsTarget(120, 1m, 1m, "De 120 a 165");

        public static FpsTarget VeryHigh = new FpsTarget(240, 1m / BaseExponent, 2m, "De 240 a 280");

        public static FpsTarget Default = High;

        //public static IReadOnlyCollection<FpsTarget> Available = new List<FpsTarget>
        //{
        //    Sixty, SeventyFive, OneHundredTwenty, OneHundredFortyFour, OneHundredSixtyFive, TwoHundredForty, TwoHundredEighty
        //};

        public static IReadOnlyCollection<FpsTarget> Available = new List<FpsTarget>
        {
            Medium, High, VeryHigh
        };

        private FpsTarget(int averageFps, decimal cpuGamingPerformanceExponent,
            decimal memoryVideoCardGamingPerformanceFactor, string name)
        {
            AverageFps = averageFps;
            CpuGamingPerformanceExponent = cpuGamingPerformanceExponent;
            MemoryVideoCardGamingPerformanceFactor = memoryVideoCardGamingPerformanceFactor;
            Name = name;
        }

        public int AverageFps { get; }

        public decimal CpuGamingPerformanceExponent { get; }

        //public decimal CpuValueFactorFor20PercentMorePerformance
        //{
        //    get { return (1m - this.CpuGamingPerformanceExponent) / 3m + 1m; }
        //}

        public decimal MemoryVideoCardGamingPerformanceFactor { get; }

        public string Name { get; }

        public static FpsTarget FindFromAvailable(int averageFps)
        {
            return Available.SingleOrDefault(f => f.AverageFps == averageFps);
        }

        public virtual bool Equals(FpsTarget other)
        {
            if (other == null)
                return false;

            return AverageFps.Equals(other.AverageFps);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as FpsTarget);
        }

        public override int GetHashCode()
        {
            return AverageFps.GetHashCode();
        }

        public override string ToString()
        {
            return AverageFps.ToString();
        }
    }
}
