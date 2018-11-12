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
    /// Form that allows user or programmer to enter technical or developer details for the bug
    /// </summary>
    public partial class AddDeveloperDetails : Form
    {
        MySqlConnection dbConn;
        Boolean recordExists = false;
        int id;

        public AddDeveloperDetails()
        {
            InitializeComponent();
            id = (int)Single.Parse(Session.id);
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
                    textBox3.Text = author;
                    textBox1.Text = classname;
                    textBox2.Text = method;
                    textBox4.Text = codeblock;
                    textBox5.Text = linenumber;
                    button1.Text = "Update";
                    recordExists = true;
                    break;
                }
            }
            dbConn.Close();

    }

        private void label4_Click(object sender, EventArgs e)
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

        private void label2_Click(object sender, EventArgs e)
        {
            

            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            string author = textBox3.Text;
            string classname = textBox1.Text;
            string method = textBox2.Text;
            string codeblock = textBox4.Text;
            string linenumber = textBox5.Text;

            dbConn.Open();

            if(!recordExists)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = dbConn;
                    cmd.CommandText = "INSERT INTO bugs_xdetails(bugid, author, classname, method, codeblock, linenumber) VALUES(@bugid, @author, @classname, @method, @codeblock, @linenumber)";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@bugid", id);
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@classname", classname);
                    cmd.Parameters.AddWithValue("@method", method);
                    cmd.Parameters.AddWithValue("@codeblock", codeblock);
                    cmd.Parameters.AddWithValue("@linenumber", linenumber);

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
                        string message = "You have successfully added developer details to the bug!";
                        string title = "Details added";
                        MessageBox.Show(message, title);
                        dbConn.Close();
                    }
                }
            }
            else
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = dbConn;
                    cmd.CommandText = "UPDATE bugs_xdetails SET author = @author, classname = @classname, method = @method, codeblock = @codeblock, linenumber = @linenumber WHERE bugid = @bugid";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@bugid", id);
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@classname", classname);
                    cmd.Parameters.AddWithValue("@method", method);
                    cmd.Parameters.AddWithValue("@codeblock", codeblock);
                    cmd.Parameters.AddWithValue("@linenumber", linenumber);

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
                        string message = "You have successfully updated developer details to the bug!";
                        string title = "Details updated";
                        MessageBox.Show(message, title);
                        dbConn.Close();
                    }
                }

            }
            

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddDeveloperDetails_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Session.fixedstatus.Equals("yes"))
            {

            }
            else
            {
                Form provideSolution = new ProvideSolution();
                provideSolution.Show();
            }
        }
    }
}
