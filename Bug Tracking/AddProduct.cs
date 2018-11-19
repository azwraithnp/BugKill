using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Bug_Tracking
{

    /// <summary>
    /// Creates a form that allows user to add new product to the system
    /// </summary>
    public partial class AddProduct : Form
    {
        //Connection object for mysql client
        MySql.Data.MySqlClient.MySqlConnection dbConn;

        public AddProduct()
        {
            InitializeComponent();

            //Create a connections object and initialize to open the database object
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();
        }
        
        /** Creates a method for submit add product button,
         *  retrieves the data provided by the user from the textboxes,
         *  creates a mysqlcommand and executes it to save the data in the database,
         *  closes the connection when done */
        private void button1_Click(object sender, EventArgs e)
        {
            //Checks if a product name is entered
            if (textBox1.Text.Length == 0)
            {
                errorProvider.SetError(textBox1, "Product name is atleast required!");
            }
            else
            {
                errorProvider.SetError(textBox1, null);
                string name = textBox1.Text.ToString();     //Creates a variable to store the product name
                string desc = textBox2.Text.ToString();     //Creates a variable to store the product description
                string platform = textBox3.Text.ToString(); //Creates a variable to store the product platform
                string coemail = textBox4.Text.ToString();  //Creates a variable to store the company email
                string url = textBox5.Text.ToString();      //Creates a variable to store the company url

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
                    //Displays a messagebox to the user if the product is registered successfully
                    if (dbConn != null)
                    {
                        string message = "You have successfully registered your product!";
                        string title = "Add product successful";
                        MessageBox.Show(message, title);
                        dbConn.Close();
                    }
                }
            }
        }
    }
}
