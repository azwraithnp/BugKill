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
    public partial class ViewSolution : Form
    {
        MySqlConnection dbConn;

        public ViewSolution()
        {
            InitializeComponent();

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
                string user = rdr.GetString(3);
                int bugid = (int)Single.Parse(Session.id);
                if (bugid == id)
                {
                    label10.Text = user;
                    textBox2.Text = summary;
                    textEditorControl1.Text = code;
                }
            }
            dbConn.Close();


            FileSyntaxModeProvider fsmp;
            string dirc = Application.StartupPath;



            if (Directory.Exists(dirc))
            {
                fsmp = new FileSyntaxModeProvider(dirc);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
            }

            textEditorControl1.SetHighlighting("C#");
            textEditorControl1.IsReadOnly = true;
        }
    }
}
