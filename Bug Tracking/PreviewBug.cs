using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Bug_Tracking
{

    /// <summary>
    /// Creates a form that allows the user to preview the details of the bug
    /// </summary>
    public partial class PreviewBug : Form
    {
        //Creates a connection object for mysql client
        MySqlConnection dbConn;

        //Creates a variable to store the bug id
        string id="";

        //Creates a variable to store the int parse value of the bug id
        int bugid = 0;

        //Creates a variable to store whether the code for the bug exists or not
        public static Boolean codeExists = false;

        /* Creates variables to store whether developer details,
         * screenshot for the bug,
         * and solution for the bug exists or not */
        Boolean recordExists = false, imageExists = false, solutionExists = false;

        public PreviewBug()
        {
            InitializeComponent();

            //Creates a connections object to initialize mysql connection
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

            //Retrieves the bugid from Session
            id = Session.id;

            //Parses the string bugid into int and saves it into integer variable idn
            int idn = (int)Single.Parse(id);

            //Creates a sqlcommand object and executes it to retrieve all data from bugs table
            string stm = "SELECT * FROM bugs";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);               //Creates a variable to store the bug id
                string summarytxt = rdr.GetString(7);   //Creates a variable to store the bug summary
                string desc = rdr.GetString(8);         //Creates a variable to store the bug description
                try
                {
                    //Retrieves image binary from database if it exists
                    byte[] imageBytes = (byte[])rdr["image"];

                    //Saves the retrieved image binary to Session
                    Session.imageData = imageBytes;

                    //Sets the boolean value of imageExists to true if try was successful
                    imageExists = true;                        
                }
                catch(Exception e)
                {
                    //Sets the boolean value of imageExists to false if image was not found in database
                    imageExists = false;                       
                }
                try
                {
                    //Retrieves source code from database if it exists
                    string source = rdr.GetString(10);

                    //Sets the boolean value of codeExists to true if try was successful
                    codeExists = true;

                    //Saves the retrieved source code to Session
                    Session.code = source;                     
                }
                catch(Exception e)
                {
                    //Sets the boolean value of codeExists to false if source code was not found in database
                    codeExists = false;                         
                }

                string fixedstatus = rdr.GetString(11);         //Get the fixed status of the bug 

                //Checks if the current active bug id is equal to current index of the bug
                if (id == idn)
                {
                    if(fixedstatus.Equals("yes"))               
                    {
                        //If the bug is fixed, set value of checkbox to checked
                        checkBox1.Checked = true;

                        //Sets the fixedstatus value in Session
                        Session.fixedstatus = "yes";            
                    }
                    else
                    {
                        //If the bug is not fixed, set value of checkbox to unchecked
                        checkBox1.Checked = false;

                        //Sets the fixedstatus value in Session
                        Session.fixedstatus = "no";             
                    }

                    //Set bugid to the current bug id
                    bugid = id;

                    //Set summary text to summary textbox
                    textBox2.Text = summarytxt;

                    //Set description text to description textbox
                    textBox1.Text = desc;

                    //Exits the loop when the current bug is found
                    break;                                      
                }
            }
            //Finally closes the connection
            dbConn.Close();                                     


        }

        private void PreviewBug_Load(object sender, EventArgs e)
        {
            //Opens the database connection
            dbConn.Open();

            //Creates sqlcommand and executes it to retrieve all data from bug solutions table
            string stm = "SELECT * FROM bugs_solutions";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while(rdr.Read())
            {
                int id = rdr.GetInt32(0);               //Creates a variable to store the bugid

                //Checks whether id of the current active bug is equal to the current bug index 
                if (bugid == id)
                {
                    Session.solutionExists = "yes";     //If match, sets value of solution exists in Session to yes
                    solutionExists = true;              //If match, sets boolean value of solutionExists to true
                }
            }
            dbConn.Close();                             
        }
        
        /** Creates a method for preview code button,
         *  checks whether the bug contains source code,
         *  if code exists opens up a form that previews code,
         *  if code doesn't exist, displays an appropriate messagebox */
        private void button1_Click(object sender, EventArgs e)
        {
            if(codeExists)
            {
                Form previewCode = new PreviewCode();
                previewCode.Show();
            }
            else
            {
                MessageBox.Show("Sorry, code was not submitted with this bug.", "Code not available");
            }

        }
        
        /** Creates a method for checkbox click,
         *  retrieves the checked or not value from the checkbox,
         *  updates the fixed status of the bug in the database,
         *  closes connection when done */
        private void checkBox1_Click(object sender, EventArgs e)
        {
            dbConn.Open();
                try
                {
                    string fixedstatus = "";        //Creates a variabe to store the fixed status of the bug

                    //Checks if checkbox is checked or not
                    if (checkBox1.Checked)
                    {
                        fixedstatus = "yes";        //Sets value of fixedstatus to true if checked
                    }
                    else
                    {
                        fixedstatus = "no";         //Sets value of fixedstatus to false if unchecked
                    }
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = dbConn;
                    cmd.CommandText = "UPDATE bugs SET fixed = @fixed WHERE bugid = @bugid";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@fixed", fixedstatus);
                    cmd.Parameters.AddWithValue("@bugid", bugid);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());

                }
                finally
                {
                    //On successful, displays an appropriate messagebox to the user 
                    if (dbConn != null)
                    {
                        string message = "Bug fixed status was updated succesfully!";
                        string title = "Bug updated";
                        MessageBox.Show(message, title);
                        dbConn.Close();
                    }
                }

            }

        //Opens up a form for adding developer details of the bug
        private void button2_Click(object sender, EventArgs e)
        {
            Form addDev = new AddDeveloperDetails();
            addDev.Show();
        }

        //If solution for the bug exists, opens up a form that previews the solution for the bug
        private void button5_Click(object sender, EventArgs e)
        {
            if(solutionExists)
            {
                Form viewSolution = new ViewSolution();
                viewSolution.Show();
            }
            else
            {
                MessageBox.Show("Sorry, solution is not provided for this bug yet.", "Solution not available");
            }
        }

        //If bug screenshot exists, opens up a form that previews the screenshot of the bug
        private void button4_Click(object sender, EventArgs e)
        {
            if (imageExists)
            {
                Form viewScreenshot = new ViewScreenshot();
                viewScreenshot.Show();
            }
            else
            {
                MessageBox.Show("Sorry, bug screenshot was not submitted with this bug.", "Snapshot not available");
            }
        }

        /** Creates a method for view developer detais button,
         *  retrieves all data from bug_xdetails table,
         *  checks whether the record of the current active bug exists in the table,
         *  opens up a form to view developer details if record exists,
         *  closes the connection when done */
        private void button3_Click(object sender, EventArgs e)
        {
            dbConn.Open();
            string stm = "SELECT * FROM bugs_xdetails";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int bugid = rdr.GetInt32(0);            //Creates a variable to store bugid

                if (this.bugid == bugid)
                {
                    recordExists = true;                //Sets boolean value of recordExists to true if match was found
                    break;                              //Exits loop if match was found
                }   
            }
            dbConn.Close();                                     

            //Opens up ViewDeveloperDetails form if record was found
            if (recordExists)
            {
                Form viewDetails = new ViewDeveloperDetails();
                viewDetails.Show();
            }
            else
            {
                MessageBox.Show("Sorry, developer details are not yet added to this bug.", "Tech details not available");
            }
        }
    }
}
