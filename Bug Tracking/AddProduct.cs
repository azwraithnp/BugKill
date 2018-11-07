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
    public partial class AddProduct : Form
    {
        MySql.Data.MySqlClient.MySqlConnection dbConn;

        public AddProduct()
        {
            InitializeComponent();
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("MySQL version : {0}", dbConn.ServerVersion);
            string name = textBox1.Text.ToString();
            string desc = textBox2.Text.ToString();
            string platform = textBox3.Text.ToString();
            string coemail = textBox4.Text.ToString();
            string url = textBox5.Text.ToString();

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = dbConn;
                cmd.CommandText = "INSERT INTO products(name, description, platform, coemail, url) VALUES(@name, @desc, @platform, @email, @url)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@desc", desc);
                cmd.Parameters.AddWithValue("@platform", platform);
                cmd.Parameters.AddWithValue("@email", coemail);
                cmd.Parameters.AddWithValue("@url", url);
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
                    string message = "You have successfully registered your product!";
                    string title = "Add product successful";
                    MessageBox.Show(message, title);
                    dbConn.Close();
                }
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
