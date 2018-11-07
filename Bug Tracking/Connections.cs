using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracking
{
    public class Connections
    {
        public Connections()
        {

        }

        public MySql.Data.MySqlClient.MySqlConnection initializeConn()
        {
            String connStr;
            connStr = "server=localhost;database=bugkill;user id=admin;password=admin;";

            MySql.Data.MySqlClient.MySqlConnection dbConn = new MySql.Data.MySqlClient.MySqlConnection(connStr);
            return dbConn;
        }


    }
}
