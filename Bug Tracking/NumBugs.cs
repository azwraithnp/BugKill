using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracking
{
    public partial class NumBugs : Form
    {
        MySqlConnection dbConn;

        public NumBugs()
        {
            InitializeComponent();

            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

            string stm = "SELECT * FROM bugs";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            int maxyear=0, minyear = 2999;
            List<int> yearsList = new List<int>();

            while (rdr.Read())
            {
                string deadline = rdr.GetString(6);
                string[] parts = deadline.Split('/');
                int year = int.Parse(parts[2]);

                if (year > maxyear) maxyear = year;
                if (year < minyear) minyear = year;

                yearsList.Add(year);
            }

            yearsList.Sort();

            chart1.ChartAreas[0].AxisX.Minimum = minyear;
            chart1.ChartAreas[0].AxisX.Maximum = maxyear;

            
            Dictionary<int, int> yearsCount = new Dictionary<int, int>();

            for (int index = minyear; index <= maxyear; index++)
            {
                int count = 0;
                for(int j=0;j<yearsList.Count;j++)
                {
                    if (yearsList[j] == index) count++;    
                }
                yearsCount.Add(index, count);
            }

           foreach (KeyValuePair<int, int> pair in yearsCount)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
                chart1.Series["Number of bugs"].Points.AddXY(pair.Key, pair.Value);
            }
           
            chart1.Series["Number of bugs"].Label = "#VALY";


        }
    }
}
