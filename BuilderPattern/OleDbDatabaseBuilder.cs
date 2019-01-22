using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class OleDbDatabaseBuilder : IDatabaseBuilder
    {
        private Database _Database;

        public OleDbDatabaseBuilder()
        {
            _Database = new OleDbDatabase();
        }

        public Database Database
        {
            get { return _Database; }
        }

        public void BuildConnection()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnectionString"].ConnectionString;
            _Database.Connection = new OleDbConnection(connectionString);
        }

        public void BuildCommand()
        {
            _Database.Command = new OleDbCommand();
            _Database.Command.Connection = _Database.Connection;
        }

        public void SetSettings()
        {
            _Database.Command.CommandTimeout = 360;
            _Database.Command.CommandType = CommandType.Text;
        }
    }
}
