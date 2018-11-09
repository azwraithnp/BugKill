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
    public partial class PreviewBug : Form
    {

        MySqlConnection dbConn;
        string id="";
        Boolean codeExists = false;

        public PreviewBug()
        {

            InitializeComponent();
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();
            id = Session.id;
            int idn = (int)Single.Parse(id);

            string stm = "SELECT * FROM bugs";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string summarytxt = rdr.GetString(7);
                string desc = rdr.GetString(8);
                string source = rdr.GetString(9);

                if (id == idn)
                {
                    textBox2.Text = summarytxt;
                    textBox1.Text = desc;
                    if(source.Equals(""))
                    {
                        codeExists = false;
                    }
                    else
                    {
                        codeExists = true;
                        Session.code = source;
                    }
                    break;
                }
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void PreviewBug_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(codeExists)
            {
                Form previewCode = new PreviewCode();
                previewCode.Show();
            }
            else
            {
                MessageBox.Show("Sorry, code was not submitted with this bug.", "Code not available");
            }

        }
    }
}
