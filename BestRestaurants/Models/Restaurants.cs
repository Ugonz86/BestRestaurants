namespace BestRestaurants.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }
        public string Description { get; set; }

        public int CousineId { get; set; }
        public virtual Cousine Cousine { get; set; }
    }
}
