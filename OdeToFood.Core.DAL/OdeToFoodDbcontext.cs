using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OdeToFood.Core.DAL
{
   public class OdeToFoodDbcontext : DbContext
    {
        public OdeToFoodDbcontext(DbContextOptions<OdeToFoodDbcontext> options): base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}
