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
    /// Creates a form that allows the user to preview the details of the bug
    /// </summary>
    public partial class PreviewBug : Form
    {

        MySqlConnection dbConn;
        string id="";
        int bugid = 0;
        public static Boolean codeExists = false;
        Boolean recordExists = false, imageExists = false, solutionExists = false;

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
                try
                {
                    byte[] imageBytes = (byte[])rdr["image"];
                   
                    Session.imageData = imageBytes;
                    imageExists = true;
                }
                catch(Exception e)
                {
                    imageExists = false;
                }
                try
                {
                    string source = rdr.GetString(9);
                    codeExists = true;
                    Session.code = source;
                }
                catch(Exception e)
                {
                    codeExists = false;
                }
                string fixedstatus = rdr.GetString(11);

                if (id == idn)
                {
                    if(fixedstatus.Equals("yes"))
                    {
                        checkBox1.Checked = true;
                        Session.fixedstatus = "yes"; 
                    }
                    else
                    {
                        checkBox1.Checked = false;
                    }
                    bugid = id;
                    textBox2.Text = summarytxt;
                    textBox1.Text = desc;
                    
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
            dbConn.Open();
            string stm = "SELECT * FROM bugs_solutions";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);
                if(bugid == id)
                {
                    Session.solutionExists = "yes";
                    solutionExists = true;
                }
            }
            dbConn.Close();
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

        private void button2_Click(object sender, EventArgs e)
        {
            Form addDev = new AddDeveloperDetails();
            addDev.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if(solutionExists)
            {
                Form viewSolution = new ViewSolution();
                viewSolution.Show();
            }
            else
            {
                MessageBox.Show("Sorry, solution is not provided for this bug yet.", "Solution not available");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (imageExists)
            {
               
                Form viewScreenshot = new ViewScreenshot();
                viewScreenshot.Show();
            }
            else
            {
                MessageBox.Show("Sorry, bug screenshot was not submitted with this bug.", "Snapshot not available");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
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

                if (this.bugid == bugid)
                {
                    recordExists = true;
                    break;
                }
            }
            dbConn.Close();

            if (recordExists)
            {
                Form viewDetails = new ViewDeveloperDetails();
                viewDetails.Show();
            }
            else
            {
                MessageBox.Show("Sorry, developer details are not yet added to this bug.", "Tech details not available");
            }
        }
    }
}
