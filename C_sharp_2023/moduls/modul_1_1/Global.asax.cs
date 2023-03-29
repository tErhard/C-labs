using System.Web.Http;

namespace Rhombus
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            // Реєстрація WebAPI
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
