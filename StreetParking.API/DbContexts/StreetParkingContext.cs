using StreetParking.API.Entities;
using StreetParking.API.Models;
using Microsoft.EntityFrameworkCore;

namespace StreetParking.API.DbContexts
{
    public class StreetParkingContext : DbContext
    {

        public DbSet<City> Cities { get; set; } = null!;

        public StreetParkingContext(DbContextOptions<StreetParkingContext> options):base(options) { }
    }
}
