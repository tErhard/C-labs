using System.Web.Http;

namespace Rhombus
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Мапування маршрутів WebAPI
            config.MapHttpAttributeRoutes();

            // Налаштування форматування відповіді у форматі JSON
            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
        }
    }
}