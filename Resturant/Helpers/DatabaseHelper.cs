using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resturant.Helpers
{
    public static class DatabaseHelper
    { 
       

        private static string connectionString = @"data source=.\SQLEXPRESS; initial catalog=ResturantDB; Integrated Security=True";

        public static void CreateRecord(string tableName, Dictionary<string, object> values)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"INSERT INTO {tableName} ({string.Join(",", values.Keys)}) VALUES ({string.Join(",", values.Values)})";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static DataTable ReadRecords(string tableName)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"SELECT * FROM {tableName}";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable table = new DataTable();
                adapter.Fill(table);

                return table;
            }
        }

        public static void UpdateRecord(string tableName, int recordId, Dictionary<string, object> values)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                List<string> valuePairs = new List<string>();
                foreach (var item in values)
                {
                    valuePairs.Add($"{item.Key}={item.Value}");
                }

                string sql = $"UPDATE {tableName} SET {string.Join(",", valuePairs)} WHERE ID={recordId}";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteRecord(string tableName, int recordId)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sql = $"DELETE FROM {tableName} WHERE ID={recordId}";
                SqlCommand command = new SqlCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

    }
}
