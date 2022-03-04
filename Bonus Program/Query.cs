using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace Bonus_Program
{
    public static class Query
    {
        public static DataTable Show(string query)
        {
            DataTable data = new DataTable();
            using (SqlConnection connection = new SqlConnection(LoginForm.ConStr))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(query, connection);
                using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                {
                    adapter.Fill(data);
                }
            }
            return data;
        }
    }
}