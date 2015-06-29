using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AzureDashboard.Models
{
    public class AvailabilityData
    {
        public enum PeriodTypeEnum { Hour, Day }

        public double[] Statistics { get; set; }

        public PeriodTypeEnum PeriodType { get; set; }
    }
}
