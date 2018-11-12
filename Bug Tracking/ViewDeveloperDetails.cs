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

    /// <summary>
    /// Creates a form that displays developer or technical details of the bug
    /// </summary>
    public partial class ViewDeveloperDetails : Form
    {
        MySqlConnection dbConn;

        public ViewDeveloperDetails()
        {
            InitializeComponent();
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Session.code != null)
            {
                Form previewCode = new PreviewCode();
                previewCode.Show();
            }
            else
            {
                MessageBox.Show("Sorry, code was not submitted with this bug.", "Code not available");
            }
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form addDetails = new AddDeveloperDetails();
            addDetails.Show();
        }

        private void ViewDeveloperDetails_Load(object sender, EventArgs e)
        {

            int id = (int)Single.Parse(Session.id);
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();
            string stm = "SELECT * FROM bugs_xdetails";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int bugid = rdr.GetInt32(0);
                string author = rdr.GetString(1);
                string classname = rdr.GetString(2);
                string method = rdr.GetString(3);
                string codeblock = rdr.GetString(4);
                string linenumber = rdr.GetString(5);

                if (id == bugid)
                {
                    label10.Text = author;
                    label11.Text = classname;
                    label12.Text = method;
                    label13.Text = codeblock;
                    label14.Text = linenumber;
                    break;
                }
            }
            dbConn.Close();

        }
    }
}
