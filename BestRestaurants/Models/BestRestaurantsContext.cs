using Microsoft.EntityFrameworkCore;

namespace BestRestaurants.Models
{
  public class BestRestaurantsContext : DbContext
  {
    public virtual DbSet<Cousine> CousineGroup { get; set; }
    public DbSet<Restaurant> RestaurantGroup { get; set; }

    public BestRestaurantsContext(DbContextOptions options) : base(options) { }
  }
}
