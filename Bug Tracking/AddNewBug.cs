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

    /// <summary>
    /// Creates a form that allows user to add new bug to the system
    /// </summary>
    public partial class AddNewBug : Form
    {
        //Creates a class variable that stores the source code of the bug if provided
        string sourcecode = "";

        //Creates a class variable to store the mysqlconnection
        MySqlConnection dbConn;

        //Creates a class variable to store the image data retrieved from the database
        byte[] imageData;
        
        //Default constructor
        public AddNewBug()
        {
            //Creates, initializes and provides value for the designer components and their properties
            InitializeComponent();

            //Stores the current active username to the user textbox
            textBox2.Text = Session.session_name;

            /* Creates a connection object, 
             * initializes it then opens the connection */
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

            //Creates a string variable to store SQL command to retrieve data from products table
            string stm = "SELECT * FROM products";

            //Creates a sql command object then executes it and stores it to a mysqlreader variable
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            //Inserts a default value of select a product to combobox and sets its position to 0 so that user can see it first
            comboBox1.Items.Insert(0, "Select a product");
            comboBox1.SelectedIndex = 0;

            //Creates a loop for the mysqlreader object to retrieve table data
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);           //Creates a variable to store the bug id
                string name = rdr.GetString(1);     //Creates a variable to store the product name

                comboBox1.Items.Add(name);          //Inserts the product list items to the combobox
            }
            dbConn.Close();
        }


        /** Creates a method for attach a picture choose button,
         *  opens a file choosing dialog with image files as filter,
         *  converts the image to byte and stores it in the image data variable,
         *  closes the filestream and binaryreader objects when the process is completed */
        private void button2_Click(object sender, EventArgs e)
        {
            //Creates a filestream object to read the picture file
            FileStream fs;

            //Creates a binaryreader object to read binary content from the picture file
            BinaryReader br;

            //Opens a file choosing dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            //Sets image files as filter 
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.tif;"; 
           
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Creates and stores the filename to a local string variable
                string fileName = openFileDialog1.FileName;

                //Opens and reads the file content using filestream object
                fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);

                //Reads the binary data from the file using binaryreader object
                br = new BinaryReader(fs);

                //Stores the binary image data to the class variable
                imageData = br.ReadBytes((int)fs.Length);


                br.Close();
                fs.Close();
                
            }
        }
        
        /** Creates a method for the submit bug button,
         *  checks whether a product is selected then proceeds,
         *  retrieves the bug data from the textboxes provided by the user,
         *  stores the information in the database and closes the connection when done */
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {

                errorProvider.SetError(comboBox1, "Please select a product!");

            }
            else
            {
                DateTime dateTime = DateTime.Today;
                errorProvider.SetError(comboBox1, null);
            
                dbConn.Open();
                Console.WriteLine("MySQL version : {0}", dbConn.ServerVersion);
                string reporter = textBox2.Text.ToString();         //Creates a variable to store the reporter name
                string version = textBox3.Text.ToString();          //Creates a variable to store the reporter name
                string severity = textBox4.Text.ToString();         //Creates a variable to store the reporter name
                string platform = textBox5.Text.ToString();         //Creates a variable to store the reporter name
                string product = comboBox1.SelectedItem.ToString();
                string daterecorded = dateTime.ToString("d");
                string deadline = dateTimePicker1.Value.Date.ToString("d");
                string summary = textBox1.Text.ToString();
                string description = textBox6.Text.ToString();


                try
                {
                    sourcecode = Session.writtencode;
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = dbConn;
                    cmd.CommandText = "INSERT INTO bugs(reporter, version, severity, platform, product, date_recorded, deadline, summary, description, source, image) VALUES(@reporter, @version, @severity, @platform, @product, @daterec, @deadline, @summary, @description, @source, @image)";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@reporter", reporter);
                    cmd.Parameters.AddWithValue("@version", version);
                    cmd.Parameters.AddWithValue("@severity", severity);
                    cmd.Parameters.AddWithValue("@platform", platform);
                    cmd.Parameters.AddWithValue("@product", product);
                    cmd.Parameters.AddWithValue("@daterec", daterecorded);
                    cmd.Parameters.AddWithValue("@deadline", deadline);
                    cmd.Parameters.AddWithValue("@summary", summary);
                    cmd.Parameters.AddWithValue("@description", description);
                    cmd.Parameters.AddWithValue("@source", sourcecode);
                    cmd.Parameters.AddWithValue("@image", imageData);

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
        }
        
        
        private void button3_Click(object sender, EventArgs e)
        {
            Form writeCode = new WriteCode();
            writeCode.Show();
        }
    }
}
