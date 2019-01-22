using System;
using System.Data.Common;
using System.Configuration;
using System.Data.SqlClient;

namespace BuilderPattern
{
    public class SqlServerDatabase : Database
    {
        private DbConnection _Connection = null;
        private DbCommand _Command = null;

        public override DbConnection Connection
        {
            get
            {
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
                return _Command;
            }
            set
            {
                _Command = value;
            }
        }
    }
}
