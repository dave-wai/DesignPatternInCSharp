using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class SqlServerDatabase : IDatabase
    {
        private SqlConnection _Connection = null;
        private SqlCommand _Command = null;

        public IDbCommand Command
        {
            get
            {
                if (_Command == null)
                {
                    // Case IDbConnection to SqlConnection
                    _Command.Connection = (SqlConnection)Connection;
                    _Command = new SqlCommand();
                }
                return _Command;
            }

        }

        public IDbConnection Connection
        {
            get
            {
                if (_Connection == null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["SQLServerConnectionString"].ConnectionString;
                    _Connection = new SqlConnection(connectionString);
                }
                return _Connection;
            }
        
        }
    }
}
