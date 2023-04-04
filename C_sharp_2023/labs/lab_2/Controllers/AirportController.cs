using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace lab_1_pro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly AirportContext _context;

        public AirportController(AirportContext context)
        {
            this._context = context;
        }

        // Read
        [HttpGet]
        public async Task<ActionResult<List<Airport>>> Get()
        {
            return Ok(await _context.Airport.ToListAsync());
        }

        // Read one
        [HttpGet("{id}")]
        public async Task<ActionResult<Airport>> Get(int id)
        {
            var airport = await _context.Airport.FindAsync(id);
            if (airport == null)
            {
                return BadRequest(404);
            }
            else
            {
                return Ok(airport);
            }
        }

        // Add
        [HttpPost]
        public async Task<ActionResult<List<Airport>>> Add(Airport airport)
        {
            _context.Add(airport);
            await _context.SaveChangesAsync();
            return Ok(await _context.Airport.ToListAsync());
        }

        // Update
        [HttpPut]
        public async Task<ActionResult<List<Airport>>> Update(Airport request)
        {
            var airport = await _context.airport.FindAsync(request.Id);
            if (airport == null)
            {
                return BadRequest(404);
            }
            else
            {
                airport.Number = request.Number;
                airport.City = request.City;
                airport.Seats = request.Seats;
                airport.Time = request.Time;
                airport.Price = request.Price;

                await _context.SaveChangesAsync();

                return Ok(airport);
            }
        }

        [HttpDelete]
        public async Task<ActionResult<List<Airport>>> Delete(int id)
        {
            var airport = await _context.Airport.FindAsync(id);
            if (airport == null)
            {
                return BadRequest(404);
            }
            else
            {
                _context.Airport.Remove(airport);

                await _context.SaveChangesAsync();

                return Ok(airport);
            }
        }
        
         [HttpGet("orderBy")]
        public async Task<ActionResult<List<Airport>>> Get(string order, string column)
        {
            if (order == "asc")
            {   

                var airports = await _context.Airport.OrderBy(
                    airport => airport.GetType().GetProperty(column).GetValue(airport)

                ).ToListAsync();
                return Ok(airports);
            }
            else
            {
                var airports = await _context.Airport.OrderByDescending(

                    airport => airport.Name
                ).ToListAsync();
                return Ok(airports);
            }
        }

        [HttpGet("filterBy")]
        public async Task<ActionResult<List<Airport>>> Get(string department)
        {
            var airports = await _context.Airport.Where(
                airport => airport.Department == department
            ).ToListAsync();
            return Ok(airports);
        }

        [HttpGet("pages")]
        public async Task<ActionResult<List<Airport>>> Get(float pageItems, int page)
        {

            var pageCount = Math.Ceiling(_context.Airport.Count() / pageItems);

            var airports = await _context.Airport
                .Skip((page - 1) * (int)pageItems)
                .Take((int)pageItems)
                .ToListAsync();

            return Ok(airports);
        }
    }
}
