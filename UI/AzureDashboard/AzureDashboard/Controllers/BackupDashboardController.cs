// --------------------------------------------------------------------------------------------------------------------
// <copyright file="BackupDashboardController.cs" company="Sitecore A/S">
//   Copyright (C) 2010 by Sitecore A/S
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace AzureDashboard.Controllers
{
  using System.Configuration;
  using System.Web.Mvc;
  using System.Web.Script.Serialization;
  using AzureDashboard.Models;
  using Microsoft.Practices.Unity;

  /// <summary>
  ///   The backup dashboard controller.
  /// </summary>
  public class BackupDashboardController : Controller
  {
    private IDashbordRepository repository;

    public BackupDashboardController(IDashbordRepository repository)
    {
      this.repository = repository;
    }

    #region Constants

    /// <summary>
    ///   The default report period key.
    /// </summary>
    private const string DefaultReportPeriodKey = "dashboard:DefaultReportPeriod";

    /// <summary>
    ///   The report period key.
    /// </summary>
    private const string ReportPeriodKey = "dashboard:reporting_period";

    /// <summary>
    ///   The default report period.
    /// </summary>
    private const int defaultReportPeriod = 3;

    #endregion

    #region Public properties

    /// <summary>
    ///   Gets or sets the reporting period.
    ///   It stores data into Temp data to share it across requests so we are ready to implement reporting period switcher on
    ///   client side.
    /// </summary>
    public int ReportingPeriod
    {
      get
      {
        int result;

        if (this.TempData[ReportPeriodKey] is int)
        {
          return (int)this.TempData[ReportPeriodKey];
        }

        if (int.TryParse(ConfigurationManager.AppSettings[DefaultReportPeriodKey], out result))
        {
          this.TempData[ReportPeriodKey] = result;
          this.TempData.Keep(ReportPeriodKey);
          return result;
        }

        return defaultReportPeriod;
      }

      set
      {
        this.TempData[ReportPeriodKey] = value;
        this.TempData.Keep(ReportPeriodKey);
      }
    }

    #endregion

    #region Public methods

    /// <summary>
    /// The get data as JSON value on UI you can use this controller method.
    /// </summary>
    /// <param name="periodInHours">
    /// The period in hours.
    /// </param>
    /// <returns>
    /// The JsonResult with JSON representation of report data<see cref="JsonResult"/>.
    /// </returns>
    [HttpPost]
    public JsonResult GetReportData(int periodInHours)
    {
      return this.Json(this.repository.FormReport(periodInHours));
    }

    /// <summary>
    ///   Index rendering.
    /// </summary>
    /// <returns>
    ///   The action result instance <see cref="ActionResult" />.
    /// </returns>
    public ActionResult Index()
    {
      AvailabilityData data = this.repository.FormReport(this.ReportingPeriod);

      this.ViewBag.ReportData = new JavaScriptSerializer().Serialize(data);

      AvailabilityData dailyData = this.repository.FormReport(24 * 7);

      this.ViewBag.DailyReportData = new JavaScriptSerializer().Serialize(dailyData);

      this.ViewBag.ReportPeriodInfo = string.Format("LAST {0} {1} ", data.Statistics.Length, data.PeriodType == AvailabilityData.PeriodTypeEnum.Day ? "DAYS" : "HOURS");

      return this.View();
    }

    /// <summary>
    /// The set report period.
    /// </summary>
    /// <param name="periodInHours">
    /// The period in hours.
    /// </param>
    [HttpPost]
    public void SetReportPeriod(int periodInHours)
    {
      this.ReportingPeriod = periodInHours;
    }

    #endregion
  }
}