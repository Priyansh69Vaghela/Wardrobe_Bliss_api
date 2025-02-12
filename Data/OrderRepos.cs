using Microsoft.Data.SqlClient;
using Wardrobe_Bliss_api.Models;

namespace Wardrobe_Bliss_api.Data
{
    public class OrderRepos
    {
        private string ConnectionString;

        public OrderRepos(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("connectionString");
        }

        public IEnumerable<OrderModel> GetAllOrders()
        {

            var orders = new List<OrderModel>();
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetAllOrders";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(new OrderModel
                    {
                        order_id = Convert.ToInt32(reader["order_id"]),
                        payment_method = (reader["payment_method"]).ToString(),
                        payment_status = (reader["payment_status"]).ToString(),
                        user_id = Convert.ToInt32(reader["user_id"]),
                        order_status = (reader["order_status"]).ToString(),
                        total_amount = Convert.ToDouble(reader["total_amount"]),
                        shipping_address = (reader["shipping_address"]).ToString(),
                        billing_address = (reader["billing_address"]).ToString(),
                        created_at = Convert.ToDateTime(reader["created_at"]),
                        updated_at = Convert.ToDateTime(reader["updated_at"]),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("gundi avi gy" + ex);
            }
            return orders;
        }

        public OrderModel GetByOrderID(int id)
        {
            OrderModel order = new OrderModel();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetOrderByID";
            cmd.Parameters.AddWithValue("@order_id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                order.order_id = Convert.ToInt32(reader["order_id"]);
                order.payment_method = (reader["payment_method"]).ToString();
                order.payment_status = (reader["payment_status"]).ToString();
                order.user_id = Convert.ToInt32(reader["user_id"]);
                order.order_status = (reader["order_status"]).ToString();
                order.total_amount = Convert.ToDouble(reader["total_amount"]);
                order.shipping_address = (reader["shipping_address"]).ToString();
                order.billing_address = (reader["billing_address"]).ToString();
                order.created_at = Convert.ToDateTime(reader["created_at"]);
                order.updated_at = Convert.ToDateTime(reader["updated_at"]);
            }
            return order;
        }

        public bool DeleteOrderByID(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DeleteOrder";
            cmd.Parameters.AddWithValue("@order_id", id);
            int deleteRows = cmd.ExecuteNonQuery();
            return deleteRows > 0;
        }

        public bool InsertOrder(OrderModel order)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertOrder";
            cmd.Parameters.AddWithValue("@payment_method", order.payment_method);
            cmd.Parameters.AddWithValue("@payment_status", order.payment_status);
            cmd.Parameters.AddWithValue("@user_id", order.user_id);
            cmd.Parameters.AddWithValue("@order_status", order.order_status);
            cmd.Parameters.AddWithValue("@total_amount", order.total_amount);
            cmd.Parameters.AddWithValue("@shipping_address", order.shipping_address);
            cmd.Parameters.AddWithValue("@billing_address", order.billing_address);
            int insertRows = cmd.ExecuteNonQuery();
            return insertRows > 0;
        }
        public bool UpdateOrder(int id, OrderModel order)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "UpdateOrder";
            cmd.Parameters.AddWithValue("@order_id", id);
            cmd.Parameters.AddWithValue("@payment_status", order.payment_status);
            cmd.Parameters.AddWithValue("@order_status", order.order_status);
            int updaterows = cmd.ExecuteNonQuery();
            return updaterows > 0;
        }
    }
}
