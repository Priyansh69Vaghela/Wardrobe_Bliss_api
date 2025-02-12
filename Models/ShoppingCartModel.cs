namespace Wardrobe_Bliss_api.Models
{
    public class ShoppingCartModel
    {
        public int cart_id { get; set; }
        public int user_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public DateTime created_at { get; set; }
    }
}
