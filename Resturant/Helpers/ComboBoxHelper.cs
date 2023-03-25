using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Resturant.Helpers
{
    public static  class ComboBoxHelper
    {
        public static void FillComboBox(ComboBox comboBox, string query, string valueMember, string displayMember)
        {
            string connectionString = @"data source=.\SQLEXPRESS; initial catalog=ResturantDB; Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    object value = reader[valueMember];
                    object display = reader[displayMember];

                    comboBox.Items.Add(new KeyValuePair<object, object>(value, display));
                }
            }
        }
    }
}
