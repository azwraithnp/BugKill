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

namespace Bug_Tracking
{
    public partial class ProPro : Form
    {

        MySqlConnection dbConn;

        public ProPro()
        {
            InitializeComponent();

            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

            string stm = "SELECT * FROM bugs_solutions";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            List<string> namesList = new List<string>();

            while (rdr.Read())
            {
                string name = rdr.GetString(3);
                namesList.Add(name);
            }

            List<string> distinctNamesList = namesList.Distinct().ToList();

            Dictionary<string, int> solveCount = new Dictionary<string, int>();

            for (int i=0;i<distinctNamesList.Count;i++)
            {
                int count = 0;
                for (int j = 0; j < namesList.Count; j++)
                {
                    if (namesList[j].Equals(distinctNamesList[i])) count++;
                }
                solveCount.Add(distinctNamesList[i], count);
            }

            foreach (KeyValuePair<string, int> pair in solveCount)
            {
                Console.WriteLine(pair.Key + " " + pair.Value);
                chart1.Series["Bugs solved"].Points.AddXY(pair.Key, pair.Value);
            }

            chart1.Series["Bugs solved"].Label = "#VALY";
            chart1.ChartAreas[0].AxisY.Interval = 1;
        }
    }
}
