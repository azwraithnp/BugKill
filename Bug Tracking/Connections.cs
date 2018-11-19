using System;

namespace Bug_Tracking
{
    public class Connections
    {
        //Stores the password value to login in the VCS
        public static string pass = "<?Babu?>321";

        public Connections()
        {

        }

        //Creates a method that creates a connection to the mysql database
        public MySql.Data.MySqlClient.MySqlConnection initializeConn()
        {
            //Connection string that stores the parameter for the mysql connection
            String connStr;
            connStr = "server=localhost;database=bugkill;user id=admin;password=admin;";

            //Creates a connection with the connection string as its argument and returns the connection object
            MySql.Data.MySqlClient.MySqlConnection dbConn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            return dbConn;
        }


    }
}
