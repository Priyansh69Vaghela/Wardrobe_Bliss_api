using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Wardrobe_Bliss_api.Models;

namespace Wardrobe_Bliss_api.Data
{
    public class CategoryRepos
    {
        private string ConnectionString;
        public CategoryRepos(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("connectionString");
        }

        public IEnumerable<CategoryModel> GetAllCategories()
        {
            var categories = new List<CategoryModel>();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[GetAllCategories]";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                categories.Add(new CategoryModel
                {
                    category_id = Convert.ToInt32(reader["category_id"]),
                    name = reader["name"].ToString(),
                });
                
            }
            return categories;
        }

        public CategoryModel GetCategoryByID(int id)
        {
            var category = new CategoryModel();
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[GetCategoryByID]";
            cmd.Parameters.AddWithValue("@category_id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                category.category_id = Convert.ToInt32(reader["category_id"]);
                category.name = reader["name"].ToString();
            }
            return category;
        }

        public bool DeleteCategory(int id)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText= "[dbo].[DeleteCategory]";
            cmd.Parameters.AddWithValue("@category_id", id);
            return (cmd.ExecuteNonQuery()) > 0;
        }

        public bool InsertCategory(CategoryModel category)
        {
           SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[InsertCategory]";
            cmd.Parameters.AddWithValue("@name", category.name);
            return (cmd.ExecuteNonQuery()) > 0;
        }

        public bool UpdateCategory(int id,CategoryModel category)
        {
            SqlConnection conn = new SqlConnection(ConnectionString);
            conn.Open();
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[dbo].[UpdateCategory]";
            cmd.Parameters.AddWithValue("@category_id", id);
            cmd.Parameters.AddWithValue("@name", category.name);
            return (cmd.ExecuteNonQuery()) > 0;
        }
    }
}
