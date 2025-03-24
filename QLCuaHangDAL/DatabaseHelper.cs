using System.Data;
using System.Data.SqlClient;

namespace QLCuaHangDAL
{
    public class DatabaseHelper
    {
        private readonly string connectionString = "Server=DESKTOP-FU7HB45\\SQLEXPRESS02;Database=YourDatabaseName;Integrated Security=True;";

        // Mở kết nối đến database
        private SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        // Thực thi câu lệnh SELECT và trả về DataTable
        public DataTable ExecuteQuery(string query, Dictionary<string, object> parameters = null)
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }
            return dt;
        }

        // Thực thi INSERT, UPDATE, DELETE (trả về số dòng bị ảnh hưởng)
        public int ExecuteNonQuery(string query, Dictionary<string, object> parameters = null)
        {
            using (SqlConnection conn = GetConnection())
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (parameters != null)
                    {
                        foreach (var param in parameters)
                        {
                            cmd.Parameters.AddWithValue(param.Key, param.Value);
                        }
                    }
                    return cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
