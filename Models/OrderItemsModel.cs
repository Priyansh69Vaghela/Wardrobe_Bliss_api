namespace Wardrobe_Bliss_api.Models
{
    public class OrderItemsModel
    {
        public int order_item_id { get; set; }
        public int order_id { get; set; }
        public int product_id { get; set; }
        public int quantity { get; set; }
        public double price { get; set; }
    }
}
