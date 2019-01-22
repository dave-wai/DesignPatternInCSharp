using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // 22/1/2019 Chapter 2 Builder Pattern 

            // ## Problem Solve ## : Need to construct complicated classes and initialize objects 
            // ## Purpose - Take a complex objects construction and hide all those implementation and details from the application code

            // Use generalized object construction interface with a builder interface / abstract clas
            // provides methods for each object construction step
            // Create builder classes that implement builder interface for each object type

            // We have builder class and director class
            // director class uses builder class to create object
            // Hides creation details from rest of application

            // Example of build class - Constuct database class with (SQL server and olddb server / create connection, command object, set command parameters)
            // we need (Database abstract factory classes, Abstract database class, SqlServerDatabase class (inherites from Database class) and OleDbDatabase class (inherites from Database class))

            // We also need IDatabaseBuilder interface (Interface is just a contract saying what methods need to implement and it doesn't have implementation)

            // Directory class (Respondible to build the object method in sequenctial order. In the Example. Need to build the DB connection first, then command then setting)
            // Build Method
            // Takes IDatabaseBuilder parameter
            // Call IDatabaseBuilder construction methods in sequence
            // Directory.Build - Return fully constrctured Database instance

            // Class Diagrame of the Database Builder Class
            // 1. Director class 2. IDatabaseBuilder interface 3. Database Abstract class with OleDBDatabase and SqlServerDatabase class implementing Database Abstract class
            // 4. SqlServerDatabaseBuilder(Implement IDatabaseBuilder)  5. OleDbDatabaseBuilder(Implement IDatabaseBuilder)


            // Dave Note 
            // In this example, build pattern use conjection with Abstract Factor Pattern to create/instantial complex object creation for Database connection (SQL/OldDB)
            // The Directory class control the Method call in IDatabaseBuilder in sequential order (Must be connection -> command -> setsetting) <just because command method depend on the object in connection method in the code >
            // The sql and oleDBBuilder classs implement IDatabaseBuilder interface and those two classes also implement all the detail implementation methods required by IDatabaseBuilder Interface
            // The Abstract factor method that created in the chapter 1 Abstract factory Pattern simple define the structure of the Abstract Database Object with the OleDbDatabase/SqlServerDatabase class
            // to fullfill and return the value {getter and setter} and also used by the SqlServerDatabaseBuilder and OleDBBuilder to define the DB type used in the application.

            // In conclusion - Director control the order of the method called in the SQL/OleDB builder object.   SQL/OleDB object return the Database Type define in the Abstract Factory class and 
            // the Sql and OldDBclass no longer set the connection string in this basic object class.  The implementation is done by SqlServerDatabaseBuilder/OleDbBuilder Class.  
            // Abstract factor Pattern provide a generalize structure of the Database Abstract class object and the concret class implement by SqlServerDatabase.cs and OleDbDatabase.cs
            
            // If we are going to implement a new Database source like MySQL DB, We need to create a new MySQLServerDatabse.cs {just getter and setter} implement Database Abstract class + MySqlDatabaseBuilder as an implementation
            // which implement IDatabaseBuilder Interface. From the Main Method, we need to instantial MySqlDatabaseBuilder() if the user select that from the radio button via UI.
            
             

            Director director = new Director();
            IDatabaseBuilder builder;
           
             // dbUser act like a radio button on UI here.  
            String dbUse = "SQL";

            if (dbUse == "SQL")
                builder = new SqlServerDatabaseBuilder();
            else
                builder = new OleDbDatabaseBuilder();

            director.Build(builder);
            Database database = builder.Database;
            DbCommand command = database.Command;

            // now, you can do something, like:
            // command.CommandText = "Select * from clients";
            // command.Connection.Open();
            // DbDataReader reader = command.ExecuteReader();

            // reader.Closer();
            // command.Connection.Close();
           
        }
    }
}
