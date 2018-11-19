using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Bug_Tracking
{
    public partial class NumBugs : Form
    {
        //Creates a connection object for mysql client
        MySqlConnection dbConn;

        public NumBugs()
        {
            InitializeComponent();

            //Creates a connections object to initialize mysql connection
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

            //Creates a mysqlcommand object and executes it to retrieve all data from bugs table
            string stm = "SELECT * FROM bugs";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            //Creates variables to store the max and min year for chart's x-axis
            int maxyear=0, minyear = 2999;

            //Creates a list object to store the years in which the bugs were recorded
            List<int> yearsList = new List<int>();

            while (rdr.Read())
            {
                string daterec = rdr.GetString(6);     //Creates a variable to store the date of the bug
                string[] parts = daterec.Split('/');   //Splits the date string to retrieve the year
                int year = int.Parse(parts[2]);        //Creates a variable to store the year after split

                //If the year in the current bug index is greater than max year, set max year to this bug's year
                if (year > maxyear) maxyear = year;

                //If the year in the current bug index is smaller than min year, set max year to this bug's year
                if (year < minyear) minyear = year;

                //Add the year of the current bug in the index to the years list object
                yearsList.Add(year);
            }

            //Sort the years in the list
            yearsList.Sort();

            //Set the minimum xaxis value to minimum year
            chart1.ChartAreas[0].AxisX.Minimum = minyear;

            //Set the maximum xaxis value to maximum year
            chart1.ChartAreas[0].AxisX.Maximum = maxyear;

            //Creates a dictionary object to store both the year of the bug and its count as key and value
            Dictionary<int, int> yearsCount = new Dictionary<int, int>();

            //Creates a loop ranging from minimum year to maximum year
            for (int index = minyear; index <= maxyear; index++)
            {
                //Creates a counter variable to store the number of bugs in that year
                int count = 0;

                //Creates a loop to go through all the items in the yearsList object
                for(int j=0;j<yearsList.Count;j++)
                {
                    //Adds the number of repetitive years as count of the number of bugs in that year
                    if (yearsList[j] == index) count++;    
                }

                //Adds the year value and its count to the dictionary object
                yearsCount.Add(index, count);
            }

           //Creates a foreach loop to go through the dictionary items and retrieve its key and values
           foreach (KeyValuePair<int, int> pair in yearsCount)
            {
                //Sets the pair values as series points to display in the chart
                chart1.Series["Number of bugs"].Points.AddXY(pair.Key, pair.Value);
            }
           
            //Display the count as value in the label
            chart1.Series["Number of bugs"].Label = "#VALY";


        }
    }
}
