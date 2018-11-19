using ICSharpCode.TextEditor.Document;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace Bug_Tracking
{


    /// <summary>
    /// Creates a form that allows user or programmer to provide a solution to the bug
    /// </summary>
    public partial class ProvideSolution : Form
    {
        //Creates a boolean variable to check whether solution for the bug exists or not
        Boolean solutionExists = false;

        //Creates a connection object for mysql client
        MySqlConnection dbConn;

        public ProvideSolution()
        {
            InitializeComponent();

            //Creates a FileSyntaxModeProvider object to provide binary for the color syntaxing
            FileSyntaxModeProvider fsmp;

            //Provide directory path for fsmp object
            string dirc = Application.StartupPath;

            //Checks if the provided directory path exists
            if (Directory.Exists(dirc))
            {
                //Initialize the fsmp object with the provided directory path
                fsmp = new FileSyntaxModeProvider(dirc);

                /*Pass the fsmp object created as argument for the sytanxmodefileprovider 
                 * of highlightingmanager of the texteditor */
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
            }

            //Set syntax highlighting mode to be C#
            textEditorControl1.SetHighlighting("C#");

            //Set texteditor text to inform user to enter their solution code here
            textEditorControl1.Text = "//enter your code here";

            //Checks whether solution exists for this bug in Session
            if (Session.solutionExists.Equals("yes"))
            {
                //Sets value of solutionExists to true if solution exists
                solutionExists = true;

                //If solution exists, change the submit button text to update
                button1.Text = "Update";
            }

            //Creates a connections object to initialize the mysql connection
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

            //Creates a mysqlcommand and executes it to retrieve all data from bug solutions table
            string stm = "SELECT * FROM bugs_solutions";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);                   //Creates a variable to store the bugid
                string summary = rdr.GetString(1);          //Creates a variable to store the solution summary
                string code = rdr.GetString(2);             //Creates a variable to store the solution code
                int bugid = (int)Single.Parse(Session.id);  //Parses the string value of bugid to int


                //If id of the current active bug equals to current index of bug id
                if (bugid == id)
                {
                    textBox2.Text = summary;                //Sets the summary textbox text to summary
                    textEditorControl1.Text = code;         //Sets the texteditorcontrol text to source code
                }
            }
            dbConn.Close();                                 //Finally closes the connection

            
            
        }

        /** Creates a method for submit button,
         *  retrieves all data entered in the textboxes,
         *  if solution for this bug exists, updates the current solution with the new values,
         *  if solution doesn't exist, adds a new solution for this bug,
         *  closes the connection when done */
        private void button1_Click(object sender, EventArgs e)
        {
            string summary = textBox2.Text;                 //Creates a variable to store the solution summary                 
            string solutioncode = textEditorControl1.Text;  //Creates a variable to store the solution code
            dbConn.Open();
            if (solutionExists)
            {
                //Creates a mysqlcommand and executes it to update the current solution with new values
                try
                {
                    MySqlCommand cmd = new MySqlCommand();  
                    cmd.Connection = dbConn;
                    cmd.CommandText = "UPDATE bugs_solutions SET solution_summary=@summary, solution_code=@code, solution_provided_by=@user WHERE bugid = @bugid";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@bugid", Session.id);
                    cmd.Parameters.AddWithValue("@summary", summary);
                    cmd.Parameters.AddWithValue("@code", solutioncode);
                    cmd.Parameters.AddWithValue("@user", Session.session_name);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                }
                finally
                {
                    //Displays an appropriate messagebox to the user if bug was updated successfully
                    if (dbConn != null)
                    {
                        string message = "You have successfully updated the solution to this bug!";
                        string title = "Solution updated";
                        MessageBox.Show(message, title);
                        dbConn.Close();
                    }
                }
            }
            else
            {
                //Creates a mysqlcommand and executes it to add the current solution in database
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = dbConn;
                    cmd.CommandText = "INSERT INTO bugs_solutions(bugid, solution_summary, solution_code, solution_provided_by) VALUES(@bugid, @summary, @code, @user)";
                    cmd.Prepare();

                    cmd.Parameters.AddWithValue("@bugid", Session.id);
                    cmd.Parameters.AddWithValue("@summary", summary);
                    cmd.Parameters.AddWithValue("@code", solutioncode);
                    cmd.Parameters.AddWithValue("@user", Session.session_name);
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());
                }
                finally
                {
                    //Displays an appropriate messagebox to the user if solution was added sucessfully
                    if (dbConn != null)
                    {
                        string message = "You have successfully submitted a solution to this bug!";
                        string title = "Solution submitted";
                        MessageBox.Show(message, title);
                        dbConn.Close();
                    }
                }
            }
        }
    }
}
