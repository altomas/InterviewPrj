using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AzureDashboard.Models
{
    public class DashbordRepository
    {
        static Dictionary<DateTime, double> availabilityByHours = new Dictionary<DateTime, double>();

        static DashbordRepository()
        {
            // initialize storage with stub data
            var periodInHours = 24 * 50;

            var startPoint = DateTime.UtcNow;

            startPoint = new DateTime(startPoint.Year, startPoint.Month, startPoint.Day, startPoint.Hour, 0, 0);

            for (int i = 0; i <= periodInHours; i++)
            {
                availabilityByHours.Add(startPoint - TimeSpan.FromHours(i),  Math.Round(new Random(Guid.NewGuid().GetHashCode()).NextDouble()*100, 2));
            }
        }

        public AvailabilityData FormReport(int periodInHours, ReportOption reportOption)
        {
            // this is a stub
            // it should request real repository with data

            var data = new AvailabilityData();

            data.PeriodType = reportOption.PeriodType;

            if (data.PeriodType == AvailabilityData.PeriodTypeEnum.Day)
            {
                data.Statistics = availabilityByHours.GroupBy(i => i.Key.Date).Take(periodInHours / 24).Select(j => Math.Round(j.Average(g => g.Value),2)).ToArray();
            }
            else
            {
                data.Statistics = availabilityByHours.Take(periodInHours).Select(i => i.Value).ToArray();
            }

            return data;
        }

        public AvailabilityData FormReport(int periodInHours)
        {
            AvailabilityData data = new DashbordRepository().FormReport(periodInHours, new ReportOption() { PeriodType = periodInHours > 24 ? AvailabilityData.PeriodTypeEnum.Day : AvailabilityData.PeriodTypeEnum.Hour });

            return data;
        }


        public class ReportOption
        {
            public AzureDashboard.Models.AvailabilityData.PeriodTypeEnum PeriodType { get; set; }
        }
    }
}