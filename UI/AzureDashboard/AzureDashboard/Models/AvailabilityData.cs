// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AvailabilityData.cs" company="Sitecore A/S">
//   Copyright (C) 2010 by Sitecore A/S
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AzureDashboard.Models
{
  /// <summary>
  /// The availability data.
  /// </summary>
  public class AvailabilityData
  {
    #region Enums

    /// <summary>
    /// The period type enum.
    /// </summary>
    public enum PeriodTypeEnum
    {
      /// <summary>
      /// The hour.
      /// </summary>
      Hour, 

      /// <summary>
      /// The day.
      /// </summary>
      Day
    }

    #endregion

    #region Public properties

    /// <summary>
    /// Gets or sets the period type.
    /// </summary>
    public PeriodTypeEnum PeriodType { get; set; }

    /// <summary>
    /// Gets or sets the statistics.
    /// </summary>
    public double[] Statistics { get; set; }

    #endregion
  }
}