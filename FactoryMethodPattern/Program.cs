using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryMethodPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Factory Pattern - Creational Pattern (24/1/2019) 
            // Just create an extra class DatabaseFactory (with a static method "CreateDatabase" + Switch statement) 
            // to use conjunction with the Abstract factory method so we can pass the DB type.  No need to user new DatabaseFactory to create the instance. Just call DatabaseFactory.CreateDatabase
            // as an enum arguement to the Abstract/IDatabase class/interface
            // Problem trying to solve : Need to support multiple database types/data coming from multiple sources/need Create different report types
            // Can be used with Abstract factory pattern - conjunction with each other
            // Hide the Database type through the app.  If SQL command do this, if Oracle command do the other - Use IDbCommand, IDbConnection
            // How : Provides a static method to create class instances
            // Use single method for creating objects, Hides details of creating objects from the rest of app.   
            // Factory class creates an instance of a class (like SqlDatabaseType or OldDatabaseType) that inherits or implements the abstract class / Interface (IDatabase in this example)

            // Dave: Similar to what we do to abstract factor pattern.  But we just need to create a new class with a static method (such as CreateDatabase) and pass the database type in
            // Enum to hide all the code to create a new concrete class instance with the new keyword in the Program.cs or Form1.cs

            // This Example contains the following classes
            // 1. Database abstract class (with IConnection and ICommand) property using IDatabase as an interface type
            // 2. SQL server and OleDB derived classes
            // 3. Enum for database type
            // 4. Database Factory Class for database class creation (Factory return an interface rather than a class). We can also use Abstract class here also rather than interface. They 
            // are interchangable.

            // Act as a checkbox
            string dbSelected = "SQL";

            IDatabase database;

            // Default to SqlServer
            DatabaseType databaseType = DatabaseType.SqlServer;

            if (dbSelected == "OleDB")
                databaseType = DatabaseType.OleDb;

            database = DatabaseFactory.CreateDatabase(databaseType);

            // App doesn't need to know this is a SQL DB command type or OracleDbCommand Type
            IDbCommand command = database.Command;

            // now, you can do something, like:
            // command.CommandText = "Select * from clients";
            // command.Connection.Open();
            // DbDataReader reader = command.ExecuteReader();

            // reader.Closer();
            // command.Connection.Close();



        }
    }
}
