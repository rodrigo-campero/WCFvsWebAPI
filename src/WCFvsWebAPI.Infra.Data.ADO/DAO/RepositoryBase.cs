using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WCFvsWebAPI.Infra.Data.Common;

namespace WCFvsWebAPI.Infra.Data.ADO.DAO
{
    public class RepositoryBase : Connection
    {
        protected void ExecuteNonQuery(string commandText, List<SqlParameter> parameters)
        {
            using (SqlConnection connection = DefaultConnection)
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                    command.ExecuteNonQuery();
                }
            }
        }

        protected int ExecuteScalar(string commandText, List<SqlParameter> parameters)
        {
            int newId;
            using (SqlConnection connection = DefaultConnection)
            {
                connection.Open();
                using (SqlCommand command = connection.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = commandText;
                    foreach (SqlParameter parameter in parameters)
                    {
                        command.Parameters.Add(parameter);
                    }
                    newId = Convert.ToInt32(command.ExecuteScalar());
                }
            }
            return newId;
        }
    }
}
