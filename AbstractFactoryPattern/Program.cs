using System;
using System.Data;
using System.Data.Common;

namespace AbstractFactoryPattern
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            string dbUse = "SQL";
            Database database;
            if (dbUse == "SQL")
                database = new SqlServerDatabase();
            else
                database = new OleDbDatabase();


            // The following code are generic and non of 
            // these call know about the technique use behind
            // the database class.
            // Isolate the DB technology

            DbCommand command = database.Command;

            // Now, we can do something lik:
            command.CommandType = CommandType.Text;
            command.CommandText = "Select * FROM customers";
            command.Connection.Open();
            DbDataReader reader = command.ExecuteReader();

            reader.Close();
            command.Connection.Close();



        }
    }
}
