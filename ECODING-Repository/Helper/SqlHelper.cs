using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace ECODING_WebApiProject.Helper
{
    public static class SqlHelper
    {
        private static SqlConnection _connection;
        private static string _connectionString = WebConfigurationManager.ConnectionStrings["ProjectDB"].ConnectionString;

        public static void InitConnection()
        {
            _connection = new SqlConnection(_connectionString);
        }

        public static void CloseConnection()
        {
            _connection.Close();
            _connection.Dispose();
        }

        public static SqlDataReader ExecuteReader(
           String commandText,
           CommandType commandType, 
           params SqlParameter[] parameters)
        {
            InitConnection();
            using (SqlCommand cmd = new SqlCommand(commandText, _connection))
            {
                cmd.CommandType = commandType;
                if(parameters!=null)
                    cmd.Parameters.AddRange(parameters);

                _connection.Open();
                SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                return reader;
            }
        }
    }
}