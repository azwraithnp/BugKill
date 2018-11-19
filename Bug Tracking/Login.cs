using System;
using System.Windows.Forms;

namespace Bug_Tracking
{

    /// <summary>
    /// Creates a login for users to ente the system and use its featues
    /// </summary>
    public partial class Login : Form
    {
        //Creates a variable to store whether user could login or not
        Boolean userExists = false;

        //Creates a connections object for mysql client
        MySql.Data.MySqlClient.MySqlConnection dbConn;

        //Creates variables to store username and password
        String username, password;

        public Login()
        {
            InitializeComponent();
            //Creates a connection object to initialize mysql connection
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
        }
        
        //Opens up form to create account
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form form3 = new CreateAccount();
            form3.Show();
        }

        /** Creates a method for submit button,
         *  validates the fields in the form,
         *  after validation, compares the data with the data retrieved the database,
         *  if the credentials match, the user is logged in,
         *  closes the connection after everything is done */
        private void button1_Click(object sender, EventArgs e)
        {
            //Opens the connection object
            dbConn.Open();

            //If the username is not entered, provides an error for the username textbox
            if (textBox1.Text.ToString().Length == 0)
            {
                errorProvider.SetError(textBox1, "Username cannot be empty!");
            }
            //If the password is not entered, provides an error for the password textbox
            else if (textBox2.Text.ToString().Length == 0)
            {
                errorProvider.SetError(textBox1, null);
                errorProvider.SetError(textBox2, "Password cannot be empty!");
            }
            //If data is entered properly, removes the error and retrieves the data from the textboxes
            else
            {
                errorProvider.SetError(textBox2, null);
                username = textBox1.Text.ToString();    //Creates a variable to store the username 
                password = textBox2.Text.ToString();    //Creates a variable to store the password
                
                //Creates a mysql command and executes to retrieve all data from users table
                string stm = "SELECT * FROM users";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
                MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int id = rdr.GetInt32(0);           //Creates a variable to store the id
                    string user = rdr.GetString(1);     //Creates a variable to store the retrieved username
                    string pass = rdr.GetString(2);     //Creates a variable to store the retrieved password
                    string type = rdr.GetString(3);     //Creates a variable to store the account type

                    //If username and password in the current index matches the entered username and password
                    if (user.Equals(username) && pass.Equals(password))
                    {
                        //Sets the session username to be the current username
                        Session.session_name = user;

                        //Displays a messagebox to the user that they have successfully logged in
                        string message = "You have logged in as " + type + "!";
                        string title = "Login Successful";
                        MessageBox.Show(message, title);

                        //Sets the boolean value of the user exits variable to true
                        userExists = true;

                        //Closes the connection finally
                        dbConn.Close();

                        //Closes the form after credentials are matched
                        this.Close();

                        //Ends the loop after credentials are matched
                        break;
                    }
                }

                //If credentials didn't match, shows a messagebox with message invalid credentials
                if(!userExists)
                {
                    MessageBox.Show("Invalid credentials", "Login Error");
                    dbConn.Close();
                }
                
            }
        }
    }
}

