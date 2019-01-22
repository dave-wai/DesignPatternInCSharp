using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class SqlServerDatabaseBuilder : IDatabaseBuilder
    {
        private Database _Database;

        public SqlServerDatabaseBuilder()
        {
            _Database = new SqlServerDatabase();
        }

        public Database Database
        {
            get { return _Database; }
        }

        // Steps MUST BE Invoked sequentially 
        // 1st method to be called - BuildConnection()
        // 2nd method to be called - BuildCommand()
        // 3rd method to be called - SetSettings()
        public void BuildConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["SQLServerConnectionString"].ConnectionString;
            _Database.Connection = new SqlConnection(connectionString);
        }

        public void BuildCommand()
        {
            _Database.Command = new SqlCommand();
            _Database.Command.Connection = _Database.Connection;
        }

        public void SetSettings()
        {
            _Database.Command.CommandTimeout = 360;
            _Database.Command.CommandType = CommandType.Text;
        }
    }
}
