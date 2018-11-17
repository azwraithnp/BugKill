using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Bug_Tracking
{
    public partial class FixedUnfixed : Form
    {
        MySqlConnection dbConn;
        int fixedcount=0, unfixedcount=0;
        public FixedUnfixed()
        {
            InitializeComponent();
            Connections conn = new Connections();
            dbConn = conn.initializeConn();  
        }

        private void FixedUnfixed_Load(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            chart1.Legends.Clear();

            dbConn.Open();

            string stm = "SELECT * FROM bugs";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                string fixedstatus = rdr["fixed"].ToString();
                if(fixedstatus.Equals("yes"))
                {
                    fixedcount++;
                }
                else
                {
                    unfixedcount++;
                }
            }

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

            //Add some datapoints so the series. in this case you can pass the values to this method
            if(fixedcount > 0)      chart1.Series[seriesname].Points.AddXY("Fixed", fixedcount);
            if(unfixedcount > 0)    chart1.Series[seriesname].Points.AddXY("Not fixed", unfixedcount);
            chart1.Series[seriesname].IsValueShownAsLabel = true;
        }
    }
}
