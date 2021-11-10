using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using TravelApi.Models;

namespace TravelApi.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewsController : ControllerBase
  {
    private readonly TravelApiContext _db;

    public ReviewsController(TravelApiContext db)
    {
      _db = db;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Review>>> Get(string country, string city )
    {
      var query = _db.Review.AsQueryable();
      if(country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }

      if(city != null)
      {
        query = query.Where(entry => entry.City == city);
      }
      return await query.ToListAsync();
    }

    [HttpPost]
    public async Task<ActionResult<Review>> Post(Review review)
    {
      _db.Review.Add(review);
      await _db.SaveChangesAsync();
      
      return CreatedAtAction("Post", new { id = review.ReviewId }, review);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Review>> GetReview(int id)
    {
      var animal = await _db.Review.FindAsync(id);

      if (animal == null)
      {
          return NotFound();
      }

      return animal;
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Review review)
    {
      if (id != review.ReviewId)
      {
        return BadRequest();
      }

      _db.Entry(review).State = EntityState.Modified;

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ReviewExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }
    private bool ReviewExists(int id)
    {
      return _db.Review.Any(e => e.ReviewId == id);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteReview(int id)
    {
      var review = await _db.Review.FindAsync(id);
      if (review == null)
      {
        return NotFound();
      }

      _db.Review.Remove(review);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  }
}