using Microsoft.AspNetCore.Mvc;
using OdeToFood.Core;
using OdeToFood.Core.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OdeToFood.RazorWeb.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantsController : ControllerBase
    {
        private readonly OdeToFoodDbcontext dbcontext;

        public RestaurantsController(OdeToFoodDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }
        // GET: api/<RestaurantsController>
        [HttpGet("{id?}")]
        public IEnumerable<Restaurant> Get(string id)
        {
            return dbcontext.Restaurants.Where(r=> string.IsNullOrEmpty(id) || r.Name.StartsWith(id)).OrderByDescending(r => r.Id);
        }

        // GET api/<RestaurantsController>/5
        [HttpGet("{id:int}")]
        public Restaurant Get(int id)
        {
            return dbcontext.Restaurants.FirstOrDefault(r => r.Id == id);
        }

        // POST api/<RestaurantsController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Restaurant restaurant)
        {
            dbcontext.Restaurants.Add(restaurant);
            await dbcontext.SaveChangesAsync();
            return CreatedAtAction("Get",new {id=restaurant.Id });
        }

        // PUT api/<RestaurantsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromRoute] int id, [FromBody] Restaurant restaurant)
        {
            if (id != restaurant.Id)
            {
                return BadRequest();
            }

            if (Get(id) == null)
            {
                return NotFound();
            }
            var entity= dbcontext.Restaurants.Attach(restaurant);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await dbcontext.SaveChangesAsync();

            return Ok(restaurant);
        }

        // DELETE api/<RestaurantsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
          var restaurant=  Get(id);
            if (restaurant == null)
            {
                return NotFound();
            }
            dbcontext.Remove(restaurant);
            await dbcontext.SaveChangesAsync();

            return Ok(restaurant);
        }
    }
}
