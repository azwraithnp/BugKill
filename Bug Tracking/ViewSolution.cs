using ICSharpCode.TextEditor.Document;
using MySql.Data.MySqlClient;
using System;
using System.IO;
using System.Windows.Forms;

namespace Bug_Tracking
{

    /// <summary>
    /// Creates a form that displays solution for the bug if it exists
    /// </summary>
    public partial class ViewSolution : Form
    {
        //Creates a connection object for mysql client
        MySqlConnection dbConn;

        public ViewSolution()
        {
            InitializeComponent();

            //Creates a connections object to initialize mysql connection
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

            //Creates a mysql command object and executes it to retrieve all data from bug solutions table
            string stm = "SELECT * FROM bugs_solutions";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);                   //Creates a variable to store the bug id
                string summary = rdr.GetString(1);          //Creates a variable to store the solution summary
                string code = rdr.GetString(2);             //Creates a variable to store the solution code
                string user = rdr.GetString(3);             //Creates a variable to store the username providing the solution
                int bugid = (int)Single.Parse(Session.id);  //Parses string bug id into int 

                //Checks whether the bugid of the current active bug equals to the current bug in index
                if (bugid == id)
                {
                    label10.Text = user;                    //Sets the user name text to username label
                    textBox2.Text = summary;                //Sets the summary text to summary textbox
                    textEditorControl1.Text = code;         //Sets the code to texteditorcontrol 
                }
            }
            dbConn.Close();

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

            //Disable editing for the preview code texteditor
            textEditorControl1.IsReadOnly = true;
        }
    }
}
