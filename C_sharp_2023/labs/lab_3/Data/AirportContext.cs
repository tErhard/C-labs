using Microsoft.EntityFrameworkCore;

namespace lab_1_pro.Models
{
    public class AirportContext : DbContext
    {
        public AirportContext(DbContextOptions<AirportContext> options) : base(options) { }

        public DbSet<Airport> Airport { get; set; }
    }
}