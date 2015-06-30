// --------------------------------------------------------------------------------------------------------------------
// <copyright file="FakeDashbordRepository.cs" company="Sitecore A/S">
//   Copyright (C) 2010 by Sitecore A/S
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace AzureDashboard.Models
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  /// <summary>
  ///   The fake dashbord repository.
  /// </summary>
  public class FakeDashbordRepository : IDashbordRepository
  {
    #region Fields

    /// <summary>
    ///   The availability by hours.
    /// </summary>
    private static readonly Dictionary<DateTime, double> availabilityByHours = new Dictionary<DateTime, double>();

    #endregion

    #region Constructors

    /// <summary>
    ///   Initializes static members of the <see cref="FakeDashbordRepository" /> class.
    /// </summary>
    static FakeDashbordRepository()
    {
      var max = 100;
      var min = 98.5;

      // initialize storage with stub data
      int periodInHours = 24 * 50;

      DateTime startPoint = DateTime.UtcNow;

      startPoint = new DateTime(startPoint.Year, startPoint.Month, startPoint.Day, startPoint.Hour, 0, 0);

      for (int i = 0; i <= periodInHours; i++)
      {
       
        // add some extremes in generated data
        if (i % 4 == 0)
        {
          availabilityByHours.Add(startPoint - TimeSpan.FromHours(i), max);
          continue;
        }

        if (i % 7 == 0)
        {
          availabilityByHours.Add(startPoint - TimeSpan.FromHours(i), min);
          continue;
        }

        // generate random
        availabilityByHours.Add(startPoint - TimeSpan.FromHours(i), GetRandomDouble(min, max, 2));
      }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// The form report.
    /// </summary>
    /// <param name="periodInHours">
    /// The period in hours.
    /// </param>
    /// <param name="reportOptions">
    /// The report options.
    /// </param>
    /// <returns>
    /// The <see cref="AvailabilityData"/>.
    /// </returns>
    public AvailabilityData FormReport(int periodInHours, ReportOptions reportOptions)
    {
      // this is a stub
      // it should request real repository with data
      var data = new AvailabilityData();

      data.PeriodType = reportOptions.PeriodType;

      if (data.PeriodType == AvailabilityData.PeriodTypeEnum.Day)
      {
        data.Statistics = availabilityByHours.GroupBy(i => i.Key.Date).Take(periodInHours / 24).Select(j => Math.Round(j.Average(g => g.Value), 2)).ToArray();
      }
      else
      {
        data.Statistics = availabilityByHours.Take(periodInHours).Select(i => i.Value).ToArray();
      }

      return data;
    }

    /// <summary>
    /// The form report.
    /// </summary>
    /// <param name="periodInHours">
    /// The period in hours.
    /// </param>
    /// <returns>
    /// The <see cref="AvailabilityData"/>.
    /// </returns>
    public AvailabilityData FormReport(int periodInHours)
    {
      AvailabilityData data = this.FormReport(periodInHours, new ReportOptions
      {
        PeriodType = periodInHours > 24 ? AvailabilityData.PeriodTypeEnum.Day : AvailabilityData.PeriodTypeEnum.Hour
      });

      return data;
    }

    #endregion

    #region Private methods

    /// <summary>
    /// The get random double.
    /// </summary>
    /// <param name="min">
    /// The min.
    /// </param>
    /// <param name="max">
    /// The max.
    /// </param>
    /// <param name="roundDigits">
    /// The round digits.
    /// </param>
    /// <returns>
    /// The random value<see cref="double"/>.
    /// </returns>
    private static double GetRandomDouble(double min, double max, int roundDigits)
    {
      double delta = max - min;

      // it is not a good idea use Guid as a seed value as the value is time based but for testing/stub purposes it is OK. 
      return max - Math.Round(new Random(Guid.NewGuid().GetHashCode()).NextDouble() * delta, roundDigits);
    }

    #endregion
  }
}