using Microsoft.Data.SqlClient;
using Wardrobe_Bliss_api.Models;

namespace Wardrobe_Bliss_api.Data
{
    public class ShoppingCartRepos
    {
        private string ConnectionString;

        public ShoppingCartRepos(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("connectionString");
        }

        public IEnumerable<ShoppingCartModel> GetAllCartItems()
        {

            var CartItems = new List<ShoppingCartModel>();
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[GetAllCartItems]";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    CartItems.Add(new ShoppingCartModel
                    {
                        cart_id = Convert.ToInt32(reader["cart_id"]),
                        user_id = Convert.ToInt32(reader["user_id"]),
                        product_id = Convert.ToInt32(reader["product_id"]),
                        quantity = Convert.ToInt32(reader["quantity"]),
                        created_at = Convert.ToDateTime(reader["created_at"]),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("gundi avi gy" + ex);
            }
            return CartItems;
        }

        public ShoppingCartModel GetCartByID(int id)
        {
            var Cart = new ShoppingCartModel();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[GetShoppingCartByUserID]";
            cmd.Parameters.AddWithValue("@user_id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Cart.cart_id = Convert.ToInt32(reader["cart_id"]);
                Cart.user_id = Convert.ToInt32(reader["user_id"]);
                Cart.product_id = Convert.ToInt32(reader["product_id"]);
                Cart.quantity = Convert.ToInt32(reader["quantity"]);
                Cart.created_at = Convert.ToDateTime(reader["created_at"]);
            }
            return Cart;
        }

        public bool DeleteCart(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[DeleteShoppingCartItem]";
            cmd.Parameters.AddWithValue("@cart_id", id);
            return (cmd.ExecuteNonQuery()) > 0;
        }

        public bool InsertCartItem(ShoppingCartModel CartItem)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[InsertCartItem]";
            cmd.Parameters.AddWithValue("@user_id", CartItem.user_id);
            cmd.Parameters.AddWithValue("@product_id", CartItem.product_id);
            cmd.Parameters.AddWithValue("@quantity", CartItem.quantity);
            int insertRows = cmd.ExecuteNonQuery();
            return insertRows > 0;
        }
        public bool UpdateCart(int id, ShoppingCartModel cart)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[UpdateShoppingCartItem]";
            cmd.Parameters.AddWithValue("@cart_id", id);
            cmd.Parameters.AddWithValue("@quantity", cart.quantity);
            return (cmd.ExecuteNonQuery()) > 0;
        }
    }
}
