using Microsoft.EntityFrameworkCore;
using PriceCalculator.API.Entities;

namespace PriceCalculator.API.Data
{
    public class VoyageDbContext : DbContext
    {
        public VoyageDbContext(DbContextOptions<VoyageDbContext> options): base(options) { }

        public DbSet<Voyage> Voyages { get; set; }        
    }
}
