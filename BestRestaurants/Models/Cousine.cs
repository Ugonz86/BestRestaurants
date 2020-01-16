using System.Collections.Generic;

namespace BestRestaurants.Models
{
    public class Cousine
    {
        public Cousine()
        {
            this.RestaurantGroup = new HashSet<Restaurant>();
        }

        public int CousineId { get; set; }
        public string Name { get; set; }
        // public int RestaurantId { get; set; }
        public virtual ICollection<Restaurant> RestaurantGroup { get; set; }
    }
}
