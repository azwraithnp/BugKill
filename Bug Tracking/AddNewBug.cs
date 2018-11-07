using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracking
{

    public partial class AddNewBug : Form
    {


        string sourcecode = "";
        MySqlConnection dbConn;

        


        public AddNewBug()
        {
            InitializeComponent();
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

            string stm = "SELECT * FROM products";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            comboBox1.Items.Insert(0, "Select a product");
            comboBox1.SelectedIndex = 0;

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);

                comboBox1.Items.Add(name);
            }
            dbConn.Close();
        }



    

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string line = "";
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.ShowDialog();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                StreamReader sr = new StreamReader(openFileDialog1.FileName);
                while(line !=null)
                {
                    line = sr.ReadLine();
                    if(line != null)
                    {

                        sourcecode += line + "\n";

                    }


                }
                    
                    
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void AddNewBug_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dbConn.Open();
            Console.WriteLine("MySQL version : {0}", dbConn.ServerVersion);
            string reporter = textBox2.Text.ToString();
            string version = textBox3.Text.ToString();
            string severity = textBox4.Text.ToString();
            string platform = textBox5.Text.ToString();
            string product = comboBox1.SelectedItem.ToString();
            string deadline = dateTimePicker1.Value.ToString();
            string summary = textBox1.Text.ToString();
            string description = textBox6.Text.ToString();
           

            try
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.Connection = dbConn;
                cmd.CommandText = "INSERT INTO bugs(reporter, version, severity, platform, product, deadline, summary, description, source) VALUES(@reporter, @version, @severity, @platform, @product, @deadline, @summary, @description, @source)";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@reporter", reporter);
                cmd.Parameters.AddWithValue("@version", version);
                cmd.Parameters.AddWithValue("@severity", severity);
                cmd.Parameters.AddWithValue("@platform", platform);
                cmd.Parameters.AddWithValue("@product", product);
                cmd.Parameters.AddWithValue("@deadline", deadline);
                cmd.Parameters.AddWithValue("@summary", summary);
                cmd.Parameters.AddWithValue("@description", description);
                cmd.Parameters.AddWithValue("@source", sourcecode);

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
                    string message = "You have successfully submitted a bug!";
                    string title = "Bug submitted";
                    MessageBox.Show(message, title);
                    dbConn.Close();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
