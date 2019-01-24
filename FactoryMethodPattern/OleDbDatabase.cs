using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    public class OleDbDatabase : IDatabase
    {
        private DbCommand _Command = null;
        private DbConnection _Connection = null;

        public IDbCommand Command
        {
            get
            {
                if (_Command == null)
                {
                    // Case IDbConnection to OleDbCOnnection
                    _Command.Connection = (OleDbConnection)Connection;
                    _Command = new OleDbCommand();
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
                    string connectionString = ConfigurationManager.ConnectionStrings["OleDBConnectionString"].ConnectionString;
                    _Connection = new OleDbConnection(connectionString);
                }
                return _Connection;
            }
        }
    }
}
