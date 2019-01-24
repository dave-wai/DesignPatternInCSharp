using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace FactoryMethodPattern
{
    public interface IDatabase
    {
        IDbConnection Connection { get; }
        IDbCommand Command { get; }
    }
}
