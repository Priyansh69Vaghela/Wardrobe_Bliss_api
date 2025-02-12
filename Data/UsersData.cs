using Microsoft.Data.SqlClient;
using System.Data;
using Wardrobe_Bliss_api.Models;

namespace Wardrobe_Bliss_api.Data
{
    public class UsersData
    {
        private string ConnectionString;
        public UsersData(IConfiguration configuration){

            ConnectionString = configuration.GetConnectionString("ConnectionString");
        }

        public IEnumerable<Users> GetAllUsers(){

            List<Users> users = new List<Users>();
            using(SqlConnection conn = new SqlConnection(ConnectionString))
            {
                conn.Open();
                SqlCommand cmd = conn.CreateCommand();
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                cmd.CommandText = "GetAllUsers";
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    users.Add(new Users{
                        user_id = Convert.ToInt32(reader["user_id"]),
                        
                        first_name = reader["first_name"].ToString(),
                        
                        last_name = reader["last_name"].ToString(),
                        
                        phone_number = reader["phone_number"].ToString(),
                        
                        email = reader["email"].ToString(),
                        
                        password = reader["password"].ToString(),
                        
                        billing_address = reader["billing_address"].ToString(),
                        
                        shipping_address = reader["shipping_address"].ToString(),
                        
                        updated_at = Convert.ToDateTime(reader["updated_at"]),
                        
                        created_at = Convert.ToDateTime(reader["created_at"]),
                    });
                }
            }

            return users;
        }
        public Users SelectByID(int id)
        {
            Users User = new Users();
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "GetUserByID";
            cmd.Parameters.AddWithValue("@user_id", id);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                User.user_id = Convert.ToInt32(reader["user_id"]);
                User.first_name = reader["first_name"].ToString();
                User.last_name = reader["last_name"].ToString();
                User.password = reader["password"].ToString();
                User.phone_number = reader["phone_number"].ToString();
                User.billing_address = reader["billing_address"].ToString();
                User.shipping_address = reader["shipping_address"].ToString();
                User.email = reader["email"].ToString();
                User.updated_at = Convert.ToDateTime(reader["updated_at"]);
                User.created_at = Convert.ToDateTime(reader["created_at"]);
            }
            return User;
        }

        public bool DeleteByID(int id)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "DeleteUser";
            cmd.Parameters.AddWithValue("@user_id", id);
            int deleteRow = cmd.ExecuteNonQuery();
            return deleteRow > 0;
        }


        #region Insert User
        public bool UserInsert(Users Users)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "InsertUser";
            cmd.Parameters.AddWithValue("@email", Users.email);
            cmd.Parameters.AddWithValue("@password", Users.password);
            cmd.Parameters.AddWithValue("@first_name", Users.first_name);
            cmd.Parameters.AddWithValue("@last_name", Users.last_name);
            cmd.Parameters.AddWithValue("@phone_number", Users.phone_number);
            cmd.Parameters.AddWithValue("@billing_address", Users.billing_address);
            cmd.Parameters.AddWithValue("@shipping_address", Users.shipping_address);
            int insertRows = cmd.ExecuteNonQuery();
            return insertRows > 0;
        }
        #endregion

        #region Update User
        public bool UserUpdate(int id, Users Users)
        {
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateUser";
            cmd.Parameters.AddWithValue("@user_id", id);
            cmd.Parameters.AddWithValue("@first_name", Users.first_name);
            cmd.Parameters.AddWithValue("@last_name", Users.last_name);
            cmd.Parameters.AddWithValue("@email", Users.email);
            cmd.Parameters.AddWithValue("@phone_number", Users.phone_number);
            cmd.Parameters.AddWithValue("@billing_address", Users.billing_address);
            cmd.Parameters.AddWithValue("@shipping_address", Users.shipping_address);
            int updateRows = cmd.ExecuteNonQuery();
            return updateRows > 0;  
        }
        #endregion

    }
}
