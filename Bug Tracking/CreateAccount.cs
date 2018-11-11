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
    public partial class CreateAccount : Form
    {
        MySql.Data.MySqlClient.MySqlConnection dbConn;

        public CreateAccount()
        {
            InitializeComponent();
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

            comboBox1.Items.Insert(0, "Select an account type");
            comboBox1.SelectedIndex = 0;
            comboBox1.Items.Add("Client/General consumer");
            comboBox1.Items.Add("Black box Tester");
            comboBox1.Items.Add("White box Tester");
            comboBox1.Items.Add("Programmer/Developer");
            
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {

                errorProvider.SetError(comboBox1, "Please select an account type!");

            }
            else
            {
                errorProvider.SetError(comboBox1, null);
                Console.WriteLine("MySQL version : {0}", dbConn.ServerVersion);
                string username = textBox1.Text.ToString();
                string password = textBox2.Text.ToString();
                string usertype = comboBox1.SelectedItem.ToString();

                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = dbConn;
                    cmd.CommandText = "INSERT INTO users(username, password, usertype) VALUES(@username, @pass, @type)";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@pass", password);
                    cmd.Parameters.AddWithValue("@type", usertype);
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
                        string message = "You have successfully created your account!";
                        string title = "Create account successful";
                        MessageBox.Show(message, title);
                        dbConn.Close();
                    }
                }
            }
            
        }

        private void CreateAccount_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_Validating(object sender, CancelEventArgs e)
        {
            
            
        }
    }
}
