using System;
using System.Configuration;
using System.Data.Common;
using System.Data.OleDb;

namespace AbstractFactoryPattern
{
    public class OleDbDatabase : Database
    {

        private DbConnection _Connection = null;
        private DbCommand _Command = null;

        public override DbConnection Connection
        {
            get
            {
                if (_Connection == null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["OleDbConnectionString"].ConnectionString;
                }
                return _Connection;
            }
            set
            {
                _Connection = value;
            }
        }

        public override DbCommand Command
        {
            get
            {
                if (_Command == null)
                {
                    _Command = new OleDbCommand();
                    _Command.Connection = Connection;
                }
                return _Command;
            }
            set
            {
                _Command = value;
            }
        }
    }
}
