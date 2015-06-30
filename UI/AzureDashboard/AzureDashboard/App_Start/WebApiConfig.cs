namespace AzureDashboard
{
  using System.Web.Http;

  /// <summary>
  ///   The web api config.
  /// </summary>
  public static class WebApiConfig
  {
    #region Public methods

    /// <summary>
    /// The register.
    /// </summary>
    /// <param name="config">
    /// The config.
    /// </param>
    public static void Register(HttpConfiguration config)
    {
      config.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{id}", new
      {
        id = RouteParameter.Optional
      });
    }

    #endregion
  }
}