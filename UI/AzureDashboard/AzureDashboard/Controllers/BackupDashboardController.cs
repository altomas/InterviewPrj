using AzureDashboard.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace AzureDashboard.Controllers
{
    public class BackupDashboardController : Controller
    {
        const string ReportPeriodKey = "dashboard:reporting_period";
        const string DefaultReportPeriodKey = "dashboard:DefaultReportPeriod"; 
        const int defaultReportPeriod = 3;

        public int ReportingPeriod 
        {
            get 
            {
                int result;

                if (TempData[ReportPeriodKey] is int)
                {
                    return (int)TempData[ReportPeriodKey];
                }

                if (int.TryParse(ConfigurationManager.AppSettings[DefaultReportPeriodKey], out result))
                {
                    TempData[ReportPeriodKey] = result;
                    TempData.Keep(ReportPeriodKey);
                    return result;
                }

                return defaultReportPeriod;
            }

            set 
            {
                TempData[ReportPeriodKey] = value;
                TempData.Keep(ReportPeriodKey);
            }
        
        }


        //
        // GET: /BackupDashboard/
        public ActionResult Index()
        {

            var data = new DashbordRepository().FormReport(this.ReportingPeriod);

            ViewBag.ReportData = new JavaScriptSerializer().Serialize(data); 

            var dailyData = new DashbordRepository().FormReport(24 * 7);

            ViewBag.DailyReportData = new JavaScriptSerializer().Serialize(dailyData); ;

            ViewBag.ReportPeriodInfo = string.Format("LAST {0} {1} ", data.Statistics.Length, data.PeriodType == AvailabilityData.PeriodTypeEnum.Day ? "DAYS" : "HOURS");

            return View();
        }



        public JsonResult GetData(int periodInHours)
        {
            return Json(new DashbordRepository().FormReport(periodInHours), JsonRequestBehavior.AllowGet);
        }

        

    }
}
