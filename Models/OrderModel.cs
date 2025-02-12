namespace Wardrobe_Bliss_api.Models
{
    public class OrderModel
    {
        public int order_id { get; set; }
        public string payment_method { get; set; }
        public string payment_status { get; set; }
        public int user_id { get; set; }
        public string order_status { get; set; }
        public double total_amount { get; set; }
        public string shipping_address { get; set; }
        public string billing_address { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
