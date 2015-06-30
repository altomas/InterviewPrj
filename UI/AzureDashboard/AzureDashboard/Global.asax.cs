namespace AzureDashboard
{
  using System.Web;
  using System.Web.Http;
  using System.Web.Mvc;
  using System.Web.Routing;
  using AzureDashboard.App_Start;
  using AzureDashboard.Models;
  using Microsoft.Practices.Unity;

  // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801
  /// <summary>
  /// The mvc application.
  /// </summary>
  public class MvcApplication : HttpApplication
  {
    #region Protected methods

    /// <summary>
    /// The application_ start.
    /// </summary>
    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      WebApiConfig.Register(GlobalConfiguration.Configuration);
      FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
      RouteConfig.RegisterRoutes(RouteTable.Routes);
      UnityWebActivator.Start();
    }

    #endregion
  }
}