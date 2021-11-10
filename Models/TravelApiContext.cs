using Microsoft.EntityFrameworkCore;

namespace TravelApi.Models
{
    public class TravelApiContext : DbContext
    {
        public TravelApiContext(DbContextOptions<TravelApiContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Review>()
            .HasData(
                new Review { ReviewId = 1, Author = "James", Title = "Best city ", Description = "lorem ipsum afdfadsfdsf", Country = "Thailand", City = "Bangkok", Rating = 3},
                new Review {ReviewId = 2,Author = "Mike",Title = "Worst city",Description = "Lorem ipsum jklf;dajfl;adjfkl;djfklads;jf",Country = "France",City = "Paris",Rating = 1},
                new Review {ReviewId = 4,Author = "Shaun", Title = "A city", Description = "dklfajskfl;ajdk kdfal; jfk kl;adj fka;", Country = "Japan", City = "Tokyo", Rating = 4}
                );
        }
        public DbSet<Review> Review { get; set; }
    }
}