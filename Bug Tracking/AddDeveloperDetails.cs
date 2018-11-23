using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Bug_Tracking
{
    /// <summary>
    /// Form that allows user or programmer to enter technical or developer details for the bug
    /// </summary>
    public partial class AddDeveloperDetails : Form
    {
        // Creates a class variable for mysqlconnection
        MySqlConnection dbConn;
        // Creates a variable to check whether developer details are present for this bug
        Boolean recordExists = false;
        // Creates an integer variable to store value for the id retrieved from Session
        int id;

        //Default constructor
        public AddDeveloperDetails()
        {
            //Creates, initializes and provides value for the designer components and their properties
            InitializeComponent();

            //Stores the integer parse value to the class variable retrieved from Session
            id = (int)Single.Parse(Session.id);

            /* Creates a connection object, 
             * initializes it then opens the connection */
            Connections conn = new Connections();

            dbConn = conn.initializeConn();
            dbConn.Open();
            
            //Creates a string variable to store SQL command to retrieve data from developer details table 
            string stm = "SELECT * FROM bugs_xdetails";
            
            //Creates a sql command object then executes it and stores it to a mysqlreader variable
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            //Creates a loop for the mysqlreader object to retrieve table data
            while (rdr.Read())
            {
                int bugid = rdr.GetInt32(0);            //Creates a variable to store the bug id
                string author = rdr.GetString(1);       //Creates a variable to store the code author name
                string classname = rdr.GetString(2);    //Creates a variable to store the code class name
                string method = rdr.GetString(3);       //Creates a variable to store the code method name
                string codeblock = rdr.GetString(4);    //Creates a variable to store the code codeblock 
                string linenumber = rdr.GetString(5);   //Creates a variable to store the code line numbers

                /** If the current viewing bug id equals to the id in the loop,
                 *  sets the developer details of the bug to the respective textboxes,
                 *  sets the boolean value of recordExists to true and exits the loop */
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
            
            //Closes the connection after processing is done
            dbConn.Close();

    }
         /** Creates a method for the hyper of click code,
         * if code exists for the current bug, opens up a form that preview the code,
         * if code doesn't exist displays an informative messagebox to the user */
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
        
        /** 
         * Creates a method for the button to submit the developer details,
         * stores the data entered in the textbox by the user to local variables,
         * opens the data connection for mysql,
         * if developer details aleady exists, updates the data otherwise inserts it into the table
         * closes the connection after everything is done */
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
                    cmd.Prepare();  //Prepares the mysql command before executing it

                    //Adds the command parameters to insert into the command
                    cmd.Parameters.AddWithValue("@bugid", id);  
                    cmd.Parameters.AddWithValue("@author", author);
                    cmd.Parameters.AddWithValue("@classname", classname);
                    cmd.Parameters.AddWithValue("@method", method);
                    cmd.Parameters.AddWithValue("@codeblock", codeblock);
                    cmd.Parameters.AddWithValue("@linenumber", linenumber);

                    cmd.ExecuteNonQuery();
                }
         
                //Catches the mysql exception if there is and then displays the error in the console
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                }
                finally
                {
                
                    //Displays success messagebox to the user if the data is saved successfully
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
        
        /** Creates a method for the provide solution button,
         * If the bug is already fixed, opens up a form that previews the solution
         * if the bug isn't already fixed, opens up a form to provide the solution */
        private void button2_Click(object sender, EventArgs e)
        {
            if (Session.fixedstatus.Equals("yes"))
            {
                Form viewSolution = new ViewSolution();
                viewSolution.Show();
            }
            else
            {
                if (Session.session_name != null && Session.session_type.Equals("Programmer/Developer"))
                {
                    Form provideSolution = new ProvideSolution();
                    provideSolution.Show();
                }
                else
                {
                    MessageBox.Show("Sorry, you need to login as a programmer or a developer to provide a solution.", "Not allowed");
                    Form login = new Login();
                    login.Show();
                }
            }
        }
    }
}
