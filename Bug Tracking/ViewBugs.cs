using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

namespace Bug_Tracking
{

    /// <summary>
    /// Creates a form that displays list of all bugs in the system
    /// </summary>
    public partial class ViewBugs : Form
    {
        //Creates a connection object for mysql client
        MySqlConnection dbConn; 

        public ViewBugs()
        {
            InitializeComponent();

            //Creates a connections object to initialize mysql connection
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

        }

        /** Creates a method for when the form loads,
         *  compares the searchterm provided by the user,
         *  retrieves data from the database according to the search term,
         *  creates a listitem with the data retrieved for the bug and populates it in the listview,
         *  closes the connection when done */
        private void ViewBugs_Load(object sender, EventArgs e)
        {
            if (Session.searchBy != null)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand();
                    cmd.Connection = dbConn;

                    if(Session.searchBy.Equals("bugid"))
                    {
                        cmd.CommandText = "SELECT * FROM bugs WHERE bugid = @selectTerm";
                    }
                    else if(Session.searchBy.Equals("reporter"))
                    {
                        cmd.CommandText = "SELECT * FROM bugs WHERE reporter = @selectTerm";
                    }
                    else if(Session.searchBy.Equals("version"))
                    {
                        cmd.CommandText = "SELECT * FROM bugs WHERE version = @selectTerm";
                    }
                    else if(Session.searchBy.Equals("severity"))
                    {
                        cmd.CommandText = "SELECT * FROM bugs WHERE severity = @selectTerm";
                    }
                    else if(Session.searchBy.Equals("platform"))
                    {
                        cmd.CommandText = "SELECT * FROM bugs WHERE platform = @selectTerm";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM bugs WHERE product = @selectTerm";
                    }
                    cmd.Prepare();
                    
                    cmd.Parameters.AddWithValue("@selectTerm", Session.searchTerm);
                    MySqlDataReader rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        int id = rdr.GetInt32(0);
                        string reporter = rdr.GetString(1);
                        string version = rdr.GetString(2);
                        string severity = rdr.GetString(3);
                        string platform = rdr.GetString(4);
                        string product = rdr.GetString(5);
                        string daterec = rdr.GetString(6);
                        string deadline = rdr.GetString(7);
                        string fixeds = rdr.GetString(11);

                        //Creates a  string array with the above retrieved data for the bug
                        var collection = new string[] { id + "", product, reporter, version, severity, platform, daterec, deadline, fixeds };
                        
                        //Creates a listviewitem with the string array created above
                        var lvl = new ListViewItem(collection);

                        //Populates the listview with the listviewitem created above
                        listView1.Items.Add(lvl);
                    }

                }

                catch (MySqlException ex)
                {
                    Console.WriteLine("Error: " + ex.ToString());

                }
            }
            else
            {
                string stm = "SELECT * FROM bugs";
                MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
                MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    int id = rdr.GetInt32(0);
                    string reporter = rdr.GetString(1);
                    string version = rdr.GetString(2);
                    string severity = rdr.GetString(3);
                    string platform = rdr.GetString(4);
                    string product = rdr.GetString(5);
                    string daterec = rdr.GetString(6);
                    string deadline = rdr.GetString(7);
                    string fixeds = rdr.GetString(11);

                    var collection = new string[] { id + "", product, reporter, version, severity, platform, daterec, deadline, fixeds };
                    var lvl = new ListViewItem(collection);


                    listView1.Items.Add(lvl);


                }

                dbConn.Close();
            }
        }

        /** Creates a method for listview item clicked
         *  gets the selected item text at position 0, in this case for id,
         *  opens up the form to preview the bug for the selected bug id,
         *  closes this form when done */
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            var selectedItem = listView1.SelectedItems[0].Text;
            Session.id = selectedItem;
            Form previewBugs = new PreviewBug();
            previewBugs.Show();
            this.Close();
        }
    }
}
