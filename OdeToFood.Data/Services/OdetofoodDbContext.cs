using Microsoft.EntityFrameworkCore;
using OdeToFood.Data.Models;

namespace OdeToFood.Data.Services
{
    public class OdetofoodDbContext :DbContext
    {
        public OdetofoodDbContext(DbContextOptions<OdetofoodDbContext> options) : base(options)
        {
           
        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
