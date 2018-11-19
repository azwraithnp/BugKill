using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Bug_Tracking
{

    /// <summary>
    /// Creates a form that allows user to add new bug to the system
    /// </summary>
    public partial class CreateAccount : Form
    {
        MySql.Data.MySqlClient.MySqlConnection dbConn;

        public CreateAccount()
        {
            InitializeComponent();
            //Creates a conection for mysql client to open it 
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

            //Inserts the default value for the combobox and sets its index to 0
            comboBox1.Items.Insert(0, "Select an account type");
            comboBox1.SelectedIndex = 0;

            //Adds the list of user types to the combobox for the user to select
            comboBox1.Items.Add("Client/General consumer");
            comboBox1.Items.Add("Black box Tester");
            comboBox1.Items.Add("White box Tester");
            comboBox1.Items.Add("Programmer/Developer");
        }

        /** Creates a method for the submit button,
         *  validates whether the user has filled the fields properly or not,
         *  creates a myslcommand and exectutes it to save the data in the database,
         *  closes the connection when done */
        private void button1_Click(object sender, EventArgs e)
        {
            //If user has not selected an account type, provide an error for the combobox
            if (comboBox1.SelectedIndex == 0)
            {
                errorProvider.SetError(comboBox1, "Please select an account type!");
            }
            //If user has selected an account type but username field is empty, provide an error for username textbox
            else if(textBox1.Text.ToString().Length == 0)
            {
                errorProvider.SetError(comboBox1, null);
                errorProvider.SetError(textBox1, "Username cannot be empty!");
            }
            //If user has done rest but not provided a password, provide an error for password textbox
            else if(textBox2.Text.ToString().Length == 0)
            {
                errorProvider.SetError(textBox1, null);
                errorProvider.SetError(textBox2, "Password cannot be empty!");
            }
            else
            {
                //Removes the error after validation is complete and proceeds to saving data in database
                errorProvider.SetError(textBox2, null);

                string username = textBox1.Text.ToString();         //Creates a variable to store the username
                string password = textBox2.Text.ToString();         //Creates a variable to store the password
                string usertype = comboBox1.SelectedItem.ToString();//Creates a variable to store the account type
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
                    //Displays a messagebox to the user if account was created successfully
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

        //Opens up a form to login on clicking the link label to login
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form login = new Login();
            login.Show();
        }
    }
}
