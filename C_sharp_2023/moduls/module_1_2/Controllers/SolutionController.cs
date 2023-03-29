using System;
using System.Web.Http;

namespace MySolution.Controllers
{
    public class SolutionController : ApiController
    {
        [HttpGet]
        public double Get(int n)
        {
            double solution = 1;
            for (int i = 1; i <= n; i++)
            {
                solution *= Math.Pow(Math.E, -1 * (double)i / n);
            }
            return solution;
        }
    }
}

// WebApiConfig.cs
using System.Web.Http;

namespace MySolution
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "SolutionApi",
                routeTemplate: "api/solution/{n}",
                defaults: new { controller = "Solution", action = "Get", n = RouteParameter.Optional }
            );
        }
    }
}