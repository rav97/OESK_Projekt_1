using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OESK_Projekt_I.Database
{
    public abstract class ADO_BaseCommands
    {
        public static DataTable ExecuteSqlCommand(SqlConnection connection, CommandType commandType, string queryString)
        {
            DataTable table = new DataTable();

            if (connection.State == ConnectionState.Closed)
                connection.Open();

            SqlCommand command = new SqlCommand(queryString, connection);
            command.CommandType = commandType;

            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                using (da = new SqlDataAdapter(command))
                {
                    da.Fill(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Dispose();
                command = null;
                connection.Close();
            }
            return table;
        }

        public static DataTable ExecuteSqlCommand(SqlConnection connection, CommandType commandType, string queryString, params SqlParameter[] param)
        {
            DataTable table = new DataTable();

            if (connection.State == ConnectionState.Closed)
                connection.Open();

            SqlCommand command = new SqlCommand(queryString, connection);
            command.CommandType = commandType;
            command.Parameters.AddRange(param);

            try
            {
                SqlDataAdapter da = new SqlDataAdapter();
                using (da = new SqlDataAdapter(command))
                {
                    da.Fill(table);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                command.Dispose();
                command = null;
                connection.Close();
            }
            return table;
        }
    }
}
