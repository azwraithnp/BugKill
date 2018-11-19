using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Bug_Tracking
{
    public partial class ProPro : Form
    {
        //Creates a connection object for mysql client
        MySqlConnection dbConn;

        public ProPro()
        {
            InitializeComponent();

            //Creates a connections object to initialize mysql connection
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

            //Creates a sqlcommand and executes it to retrieve all data from bug solutions table
            string stm = "SELECT * FROM bugs_solutions";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            //Creates a list object to store the names of the users or programmers who provided a solution
            List<string> namesList = new List<string>();

            while (rdr.Read())
            {
                string name = rdr.GetString(3);     //Creates a variable to store the programmer name
                namesList.Add(name);                //Adds the name to the name list object
            }

            //Creates a list of names distinctly, i.e. no duplicates
            List<string> distinctNamesList = namesList.Distinct().ToList();

            //Creates a dictionary object to store both the names and the number of bugs they solved as key and value
            Dictionary<string, int> solveCount = new Dictionary<string, int>();

            //Creates a loop that goes through the distinct names list
            for (int i=0;i<distinctNamesList.Count;i++)
            {
                //Creates a counter variable to store the number of bugs solved 
                int count = 0;

                //Creates a loop that goes through the non-distinct names list
                for (int j = 0; j < namesList.Count; j++)
                {
                    //If distinct name matches the name in the list, increase the count
                    if (namesList[j].Equals(distinctNamesList[i])) count++;
                }
                //Adds the name and its count to the dictionary
                solveCount.Add(distinctNamesList[i], count);
            }

            //Creates a foreach loop that goes through the dictionary items
            foreach (KeyValuePair<string, int> pair in solveCount)
            {
                //Sets the pair values as series points to display in the chart
                chart1.Series["Bugs solved"].Points.AddXY(pair.Key, pair.Value);
            }

            //Display the count as value in the label
            chart1.Series["Bugs solved"].Label = "#VALY";

            //Sets the value interval in the yxaxis to be 1
            chart1.ChartAreas[0].AxisY.Interval = 1;
        }
    }
}
