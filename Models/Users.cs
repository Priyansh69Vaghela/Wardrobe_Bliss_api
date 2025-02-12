using static System.Net.Mime.MediaTypeNames;
using System;

namespace Wardrobe_Bliss_api.Models
{
    public class Users
    {
        public  int user_id { get; set;}
        public  string first_name { get; set;}
        public string last_name{ get; set; }
        public  string email { get; set; }
        public  string password { get; set; }
        public  string phone_number { get; set; }
        public  string shipping_address { get; set; }
        public  string billing_address { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
    }
}
