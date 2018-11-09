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
    public partial class ViewBugs : Form
    {
        MySqlConnection dbConn; 

        public ViewBugs()
        {
            InitializeComponent();
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ViewBugs_Load(object sender, EventArgs e)
        {

            string stm = "SELECT * FROM bugs";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            ImageList imageList = new ImageList();
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string reporter = rdr.GetString(1);
                string version = rdr.GetString(2);
                string severity = rdr.GetString(3);
                string platform = rdr.GetString(4);
                string product = rdr.GetString(5);
                string deadline = rdr.GetString(6);
                string fixeds = rdr.GetString(10);
                
                //imageList.Images.Add(Image.FromFile(@"../../forward.png"));
                //listView1.LargeImageList = imageList;
                //listView1.SmallImageList = imageList;

                var collection = new string[] {id + "", reporter, version, severity, platform, product, deadline, fixeds };
                var lvl = new ListViewItem(collection);

                
                listView1.Items.Add(lvl);

                
            }
            
            dbConn.Close();

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var selectedItem = listView1.SelectedItems[0].Text;
            Session.id = selectedItem;
            Form previewBugs = new PreviewBug();
            previewBugs.Show();
            this.Close();
            

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
