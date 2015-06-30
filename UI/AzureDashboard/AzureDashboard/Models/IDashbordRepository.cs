namespace AzureDashboard.Models
{
  /// <summary>
  /// The DashbordRepository interface.
  /// </summary>
  public interface IDashbordRepository
  {
    #region Public methods

    /// <summary>
    /// The form report.
    /// </summary>
    /// <param name="periodInHours">
    /// The period in hours.
    /// </param>
    /// <param name="reportOption">
    /// The report option.
    /// </param>
    /// <returns>
    /// The report data instance<see cref="AvailabilityData"/>.
    /// </returns>
    AvailabilityData FormReport(int periodInHours, ReportOptions reportOption);

    /// <summary>
    /// The form report.
    /// </summary>
    /// <param name="periodInHours">
    /// The period in hours.
    /// </param>
    /// <returns>
    /// The report data instance <see cref="AvailabilityData"/>.
    /// </returns>
    AvailabilityData FormReport(int periodInHours);

    #endregion
  }
}