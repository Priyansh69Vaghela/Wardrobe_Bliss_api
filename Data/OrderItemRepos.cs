using Microsoft.Data.SqlClient;
using Wardrobe_Bliss_api.Models;

namespace Wardrobe_Bliss_api.Data
{
    public class OrderItemRepos
    {
        private string ConnectionString;

        public OrderItemRepos(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("connectionString");
        }

        public IEnumerable<OrderItemsModel> GetAllOrderItems()
        {

            var orderItems = new List<OrderItemsModel>();
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "[dbo].[GetAllOrderItems]";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orderItems.Add(new OrderItemsModel
                    {
                        order_item_id = Convert.ToInt32(reader["order_item_id"]),
                        order_id = Convert.ToInt32(reader["order_id"]),
                        product_id = Convert.ToInt32(reader["product_id"]),
                        quantity = Convert.ToInt32(reader["quantity"]),
                        price = Convert.ToDouble(reader["price"]),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("gundi avi gy" + ex);
            }
            return orderItems;
        }
        public OrderItemsModel GetByOrderItemID(int id)
        {
            OrderItemsModel orderItem = new OrderItemsModel();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[GetOrderItemsByOrderID]";
            cmd.Parameters.AddWithValue("@order_id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                orderItem.order_item_id = Convert.ToInt32(reader["order_item_id"]);
                orderItem.order_id = Convert.ToInt32(reader["order_id"]);
                orderItem.product_id = Convert.ToInt32(reader["product_id"]);
                orderItem.quantity = Convert.ToInt32(reader["quantity"]);
                orderItem.price = Convert.ToDouble(reader["price"]);
            }
            return orderItem;
        }
        public bool DeleteOrderItemByID(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[DeleteOrderItem]";
            cmd.Parameters.AddWithValue("@order_item_id", id);
            int deleteRows = cmd.ExecuteNonQuery();
            return deleteRows > 0;
        }
        public bool InsertOrderItem(OrderItemsModel orderItem)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[InsertOrderItem]";
            cmd.Parameters.AddWithValue("@order_id", orderItem.order_id);
            cmd.Parameters.AddWithValue("@product_id", orderItem.product_id);
            cmd.Parameters.AddWithValue("@quantity", orderItem.quantity);
            cmd.Parameters.AddWithValue("@price", orderItem.price);
            int insertRows = cmd.ExecuteNonQuery();
            return insertRows > 0;
        }
        public bool UpdateOrderItem(int id, OrderItemsModel orderItem)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[UpdateOrderItem]";
            cmd.Parameters.AddWithValue("@order_item_id", id);
            cmd.Parameters.AddWithValue("@quantity", orderItem.quantity);
            cmd.Parameters.AddWithValue("@price", orderItem.price);
            int updaterows = cmd.ExecuteNonQuery();
            return updaterows > 0;
        }
    }
}
