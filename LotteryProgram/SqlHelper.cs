using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace LotteryProgram
{
    public static class SqlHelper
    {
        private static readonly string constr = ConfigurationManager.ConnectionStrings["constr"].ConnectionString;

        public static int ExecuteNonquery(string sql, params SqlParameter[] sqlParameters)
        {
            using (SqlConnection connection = new SqlConnection(constr))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddRange(sqlParameters);
                        return command.ExecuteNonQuery();
                    }
                }
                catch (Exception)
                {
                    return 0;
                }
            }
        }

        public static DataTable Query(string sql, params SqlParameter[] sqlParameters)
        {
            var result = new DataTable();
            using (SqlConnection connection = new SqlConnection(constr))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.Parameters.AddRange(sqlParameters);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(result);
                }
            }
            return result;
        }
    }
}
