using System;
using System.Data;
using System.Data.Common;

namespace AbstractFactoryPattern
{
    public abstract class Database
    {
        public virtual DbConnection Connection { get; set; }
        public virtual DbCommand Command { get; set; }
    }
}
