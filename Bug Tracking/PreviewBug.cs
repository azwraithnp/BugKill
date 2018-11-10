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
        int bugid = 0;
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
                string fixedstatus = rdr.GetString(10);

                if (id == idn)
                {
                    if(fixedstatus.Equals("yes"))
                    {
                        checkBox1.Checked = true;
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                    bugid = id;
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
            dbConn.Close();
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            dbConn.Open();
                try
                {
                    string fixedstatus = "";
                    if(checkBox1.Checked)
                    {
                        fixedstatus = "yes";
                    }
                    else
                    {
                        fixedstatus = "no";
                    }
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = dbConn;
                    cmd.CommandText = "UPDATE bugs SET fixed = @fixed WHERE bugid = @bugid";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@fixed", fixedstatus);
                    cmd.Parameters.AddWithValue("@bugid", bugid);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());

                }
                finally
                {
                    if (dbConn != null)
                    {
                        string message = "Bug fixed status was updated succesfully!";
                        string title = "Bug updated";
                        MessageBox.Show(message, title);
                        dbConn.Close();
                    }
                }

            }

        
    }
}
