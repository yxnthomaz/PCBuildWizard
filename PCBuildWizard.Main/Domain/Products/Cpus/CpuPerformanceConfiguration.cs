using PCBuildWizard.Main.Domain.Products.Graphics;
using PCBuildWizard.Main.Domain.Recommendations;
using System;
using System.Collections.Generic;

namespace PCBuildWizard.Main.Domain.Products.Cpus
{
    public class CpuPerformanceConfiguration
    {
        private static readonly Dictionary<WorkloadLevel, decimal> CurrentDrawFactorsByWorkloadLevel =
            new Dictionary<WorkloadLevel, decimal>()
            {
                { WorkloadLevel.None,    0.1m },
                { WorkloadLevel.Light,   0.3m },
                { WorkloadLevel.Medium,  0.6m },
                { WorkloadLevel.Heavy,   0.9m },
                { WorkloadLevel.Maximum, 1.0m },
            };

        protected CpuPerformanceConfiguration() { }

        public CpuPerformanceConfiguration(decimal singleThreadedPerformance, decimal multiThreadedPerformance,
            decimal gamingPerformanceFactor, decimal thermalPower, decimal coresCurrentDraw, decimal powerConsumption)
        {
            SingleThreadedPerformance = singleThreadedPerformance;
            MultiThreadedPerformance = multiThreadedPerformance;
            GamingPerformanceFactor = gamingPerformanceFactor;
            ThermalPower = thermalPower;
            CoresCurrentDraw = coresCurrentDraw;
            PowerConsumption = powerConsumption;
        }

        public virtual decimal SingleThreadedPerformance { get; protected set; }

        public virtual decimal MultiThreadedPerformance { get; protected set; }

        public virtual decimal GamingPerformanceFactor { get; protected set; }

        /* TODO: split into ModerateLoadThermalPower and HeavyLoadThermalPower */
        public virtual decimal ThermalPower { get; protected set; }

        public virtual decimal CoresCurrentDraw { get; protected set; }

        public virtual decimal PowerConsumption { get; protected set; }

        public virtual decimal GetDesktopPerformance(UseProfile useProfile)
        {
            if (useProfile == null)
                throw new ArgumentNullException(nameof(useProfile));

            return SingleThreadedPerformance * useProfile.SingleThreadFocus +
                MultiThreadedPerformance * useProfile.MultiThreadFocus;
        }

        public virtual decimal WeightedPerformance(UseProfile useProfile, FpsTarget fpsTarget)
        {
            if (useProfile == null)
                throw new ArgumentNullException(nameof(useProfile));

            if (fpsTarget == null)
                throw new ArgumentNullException(nameof(fpsTarget));

            decimal gamingPerformanceFactor = (decimal)Math
                .Pow((double)GamingPerformanceFactor, (double)fpsTarget.CpuGamingPerformanceExponent);

            decimal weightedPerformance =
                GetDesktopPerformance(useProfile.OrdinaryTasksRelatedUseProfile) * useProfile.OrdinaryTasksFocus +
                GetDesktopPerformance(useProfile) * useProfile.MainDesktopFocus +
                gamingPerformanceFactor * 100m * useProfile.GamingFocus;

            return weightedPerformance;
        }

        public virtual decimal GetThermalPower(WorkloadLevel workloadLevel)
        {
            decimal workloadThermalPowerFactor = new Dictionary<WorkloadLevel, decimal>()
            {
                { WorkloadLevel.None,    0.60m },
                { WorkloadLevel.Light,   0.70m },
                { WorkloadLevel.Medium,  0.80m },
                { WorkloadLevel.Heavy,   0.90m },
                { WorkloadLevel.Maximum, 1.00m },
                //{ WorkloadLevel.None,    0.20m },
                //{ WorkloadLevel.Light,   0.40m },
                //{ WorkloadLevel.Medium,  0.60m },
                //{ WorkloadLevel.Heavy,   0.80m },
                //{ WorkloadLevel.Maximum, 1.00m },
            }[workloadLevel];

            decimal thermalPowerStep = 2.5m;

            return Math.Round(ThermalPower * workloadThermalPowerFactor / thermalPowerStep) * thermalPowerStep;
        }

        public virtual decimal GetCoresCurrentDraw(WorkloadLevel workloadLevel)
        {
            var workloadCoresCurrentDrawFactor = CurrentDrawFactorsByWorkloadLevel[workloadLevel];

            return CoresCurrentDraw * workloadCoresCurrentDrawFactor;
        }
    }
}
