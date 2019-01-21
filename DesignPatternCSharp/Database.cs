using System;
using System.Data.Common;

namespace DesignPatternCSharp
{
    public abstract class Database
    {
        public virtual DbConnection Connection { get; set; }
        public virtual DbCommand Command { get; set; }
    }
}
