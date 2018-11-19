using MySql.Data.MySqlClient;
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bug_Tracking
{
    public partial class FixedUnfixed : Form
    {
        //Create a connection object for mysql client
        MySqlConnection dbConn;

        //Create count variables to store the number of fixed and unfixed bugs
        int fixedcount=0, unfixedcount=0;

        public FixedUnfixed()
        {
            InitializeComponent();
            //Create a connections object and initialize the mysql connection
            Connections conn = new Connections();
            dbConn = conn.initializeConn();  
        }

        private void FixedUnfixed_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();      //Clears the series components for the chart
            chart1.Legends.Clear();     //Clears the legends components for the chart

            dbConn.Open();              //Opens the mysql connection 

            //Creates a myslcommand object and executes it to retrieve all data from bugs table
            string stm = "SELECT * FROM bugs";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                //Creates a variable to store the fixed status of the bug
                string fixedstatus = rdr["fixed"].ToString();

                //If the current bug in the index is fixed, increase count of fixed bugs and vice-versa
                if(fixedstatus.Equals("yes"))
                {
                    fixedcount++;
                }
                else
                {
                    unfixedcount++;
                }
            }

            //Adds a legend box to the chart to distinguise the pie elements
            chart1.Legends.Add("FixedLegend");
            chart1.Legends[0].LegendStyle = LegendStyle.Table;
            chart1.Legends[0].Docking = Docking.Bottom;
            chart1.Legends[0].Alignment = StringAlignment.Center;
            chart1.Legends[0].BorderColor = Color.Black;

            //Add a new chart-series
            string seriesname = "FixedStatus";
            chart1.Series.Add(seriesname);

            //set the chart-type to "Pie"
            chart1.Series[seriesname].ChartType = SeriesChartType.Pie;

            //Add some datapoints so the series. in this case values are passed to the method
            if(fixedcount > 0)      chart1.Series[seriesname].Points.AddXY("Fixed", fixedcount);
            if(unfixedcount > 0)    chart1.Series[seriesname].Points.AddXY("Not fixed", unfixedcount);
            
            //Display the count for the pie elements on it as label
            chart1.Series[seriesname].IsValueShownAsLabel = true;
        }
    }
}
