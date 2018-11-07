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

    
    public partial class Login : Form
    {
        MySql.Data.MySqlClient.MySqlConnection dbConn;
        String username, password;

        public Login()
        {
            InitializeComponent();
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form3 = new CreateAccount();
            form3.Show();
        }

        private void addNewProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addProd = new AddProduct();
            addProd.Show();
        }

        private void addNewBugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form addnewbug = new AddNewBug();
            addnewbug.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("MySQL version : {0}", dbConn.ServerVersion);
            username = textBox1.Text.ToString();
            password = textBox2.Text.ToString();
            Console.WriteLine(username + password);

            string stm = "SELECT * FROM users";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string user = rdr.GetString(1);
                string pass = rdr.GetString(2);
                string type = rdr.GetString(3);

                if (user.Equals(username) && pass.Equals(password))
                {
                    Console.WriteLine("Logged In!");
                    string message = "You have logged in as " + type + "!";
                    string title = "Login Successful";
                    MessageBox.Show(message, title);
                    break;
                }
                }
            }
        }
    }

