using ICSharpCode.TextEditor.Document;
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
    /// Creates a form that allows user or programmer to provide a solution to the bug
    /// </summary>
    public partial class ProvideSolution : Form
    {
        Boolean solutionExists = false;
        MySqlConnection dbConn;

        public ProvideSolution()
        {
            InitializeComponent();

            FileSyntaxModeProvider fsmp;
            string dirc = Application.StartupPath;

            if (Directory.Exists(dirc))
            {
                fsmp = new FileSyntaxModeProvider(dirc);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
            }
            textEditorControl1.SetHighlighting("C#");
            textEditorControl1.Text = "//enter your code here";


            if (Session.solutionExists.Equals("yes"))
            {
                solutionExists = true;
                button1.Text = "Update";
            }
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            dbConn.Open();

            string stm = "SELECT * FROM bugs_solutions";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(stm, dbConn);
            MySql.Data.MySqlClient.MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string summary = rdr.GetString(1);
                string code = rdr.GetString(2);
                int bugid = (int)Single.Parse(Session.id);
                if (bugid == id)
                {
                    textBox2.Text = summary;
                    textEditorControl1.Text = code;
                }
            }
            dbConn.Close();

            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string summary = textBox2.Text;
            string solutioncode = textEditorControl1.Text;
            dbConn.Open();
            if (solutionExists)
            {
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

        private void ProvideSolution_Load(object sender, EventArgs e)
        {

        }
    }
}
