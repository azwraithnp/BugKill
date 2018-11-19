using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Bug_Tracking
{

    /// <summary>
    /// Creates a form that displays developer or technical details of the bug
    /// </summary>
    public partial class ViewDeveloperDetails : Form
    {
        //Creates a connection object for mysql client
        MySqlConnection dbConn;

        public ViewDeveloperDetails()
        {
            InitializeComponent();

            //Creates a connections object to initialize mysql connection
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();
        }
        
        //Checks if code is provided for this bug then opens up form to show code for this bug
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

        //Opens up form to add developer details for this bug
        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form addDetails = new AddDeveloperDetails();
            addDetails.Show();
        }

        /** Creates a method for when the form loads,
         *  retrieves all data from bug_xdetails table,
         *  populates the retrieved data in the labels,
         *  closes the connection when done */
        private void ViewDeveloperDetails_Load(object sender, EventArgs e)
        {

            int id = (int)Single.Parse(Session.id);
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();
            string stm = "SELECT * FROM bugs_xdetails";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int bugid = rdr.GetInt32(0);            //Creates a variable to store the bugid
                string author = rdr.GetString(1);       //Creates a variable to store the code author
                string classname = rdr.GetString(2);    //Creates a variable to store the bug in code class name
                string method = rdr.GetString(3);       //Creates a variable to store the bug in code method name
                string codeblock = rdr.GetString(4);    //Creates a variable to store the bug in code codeblock
                string linenumber = rdr.GetString(5);   //Creates a variable to store the bug in code linenumber

                //Checks whether the current active bug id equals to the bug id of the current bug index
                if (id == bugid)
                {
                    label10.Text = author;              //Sets the author name to author label
                    label11.Text = classname;           //Sets the class name to class name label
                    label12.Text = method;              //Sets the method name to method name label
                    label13.Text = codeblock;           //Sets the codeblock to codeblock label
                    label14.Text = linenumber;          //Sets the line number to line number label
                    break;                              //Exits the loop when done
                }
            }
            dbConn.Close();

        }
    }
}
