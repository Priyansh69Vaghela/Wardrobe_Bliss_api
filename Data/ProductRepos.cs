using Microsoft.Data.SqlClient;
using Wardrobe_Bliss_api.Models;

namespace Wardrobe_Bliss_api.Data
{
    public class ProductRepos
    {
        private string ConnectionString;

        public ProductRepos(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("connectionString");
        }

        public IEnumerable<ProductModel> GetAllProducts()
        {

            var products = new List<ProductModel>();
            try
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetAllProducts";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new ProductModel
                    {
                        product_id = Convert.ToInt32(reader["product_id"]),
                        name = (reader["name"]).ToString(),
                        description = (reader["description"]).ToString(),
                        price = Convert.ToDouble(reader["price"]),
                        stock_quantity = Convert.ToInt32(reader["stock_quantity"]),
                        category_id = Convert.ToInt32(reader["category_id"]),
                        image_url = (reader["image_url"]).ToString(),
                        created_at = Convert.ToDateTime(reader["created_at"]),
                        updated_at = Convert.ToDateTime(reader["updated_at"]),
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("gundi avi gy"+ ex);
            }
            return products;
        }
         
        public ProductModel GetByProductID(int id)
        {
            ProductModel product = new ProductModel();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "GetProductByID";
            cmd.Parameters.AddWithValue("@product_id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                product.product_id = Convert.ToInt32(reader["product_id"]);
                product.name = (reader["name"]).ToString();
                product.description = (reader["description"]).ToString();
                product.price = Convert.ToDouble(reader["price"]);
                product.stock_quantity = Convert.ToInt32(reader["stock_quantity"]);
                product.category_id = Convert.ToInt32(reader["category_id"]);
                product.image_url = (reader["image_url"]).ToString();
                product.updated_at = Convert.ToDateTime(reader["updated_at"]);
                product.created_at = Convert.ToDateTime(reader["created_at"]);
            }
            return product;
        }

        public bool DeleteProductByID(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "DeleteProduct";
            cmd.Parameters.AddWithValue("@product_id",id);
            int deleteRows = cmd.ExecuteNonQuery();
            return deleteRows > 0;
        }

        public bool InsertProduct(ProductModel product)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "InsertProduct";
            cmd.Parameters.AddWithValue("@name", product.name);
            cmd.Parameters.AddWithValue("@description", product.description);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@stock_quantity", product.stock_quantity);
            cmd.Parameters.AddWithValue("@category_id", product.category_id);
            cmd.Parameters.AddWithValue("@image_url", product.image_url);
            int insertRows = cmd.ExecuteNonQuery();
            return insertRows > 0;
        }
        public bool UpdateProduct(int id,ProductModel product)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "UpdateProduct";
            cmd.Parameters.AddWithValue("@product_id", id);
            cmd.Parameters.AddWithValue("@name", product.name);
            cmd.Parameters.AddWithValue("@description", product.description);
            cmd.Parameters.AddWithValue("@price", product.price);
            cmd.Parameters.AddWithValue("@stock_quantity", product.stock_quantity);
            cmd.Parameters.AddWithValue("@category_id", product.category_id);
            cmd.Parameters.AddWithValue("@image_url", product.image_url);
            int updaterows = cmd.ExecuteNonQuery();
            return updaterows > 0;
        }
    }
}