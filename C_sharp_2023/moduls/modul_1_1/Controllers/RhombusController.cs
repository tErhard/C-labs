using System;
using System.Web.Http;
using Rhombus.Models;

namespace Rhombus.Controllers
{
    public class RhombusController : ApiController
    {
        // Ендпоінт для обчислення площі ромба
        [HttpGet]
        public IHttpActionResult GetArea(double side_length, double angle)
        {
            // Обчислення площі ромба
            double area = side_length * side_length * Math.Sin(angle * Math.PI / 180);

            // Повернення результату у форматі JSON
            return Json(new { area });
        }

        // Ендпоінт для обчислення периметру ромба
        [HttpGet]
        public IHttpActionResult GetPerimeter(double side_length, double angle)
        {
            // Обчислення периметру ромба
            double perimeter = 4 * side_length;

            // Повернення результату у форматі JSON
            return Json(new { perimeter });
        }
    }
}