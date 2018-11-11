using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracking
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }
        

        private void bugLogsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Session.session_name != null)
            {
                Form showBugs = new ViewBugs();
                showBugs.Show();
            }
            else
            {
                MessageBox.Show("Please login first.", "Login required");
                Form login = new Login();
                login.Show();
            }
        }

        private void addNewProductToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Session.session_name != null)
            {
                Form addProd = new AddProduct();
                addProd.Show();
            }
            else
            {
                MessageBox.Show("Please login first.", "Login required");
                Form login = new Login();
                login.Show();
            }
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.session_name != null)
            {
                MessageBox.Show("You are already logged in.", "Logged in");
            }
            else
            {
                Form login = new Login();
                login.Show();
            }
        }

        private void addNewBugToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (Session.session_name != null)
            {
                Form addnewbug = new AddNewBug();
                addnewbug.Show();
            }
            else
            {
                MessageBox.Show("Please login first.", "Login required");
                Form login = new Login();
                login.Show();
            }

        }

        private void requestReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.session_name != null)
            {
                Form searchBug = new SearchBug();
                searchBug.Show();
            }
            else
            {
                MessageBox.Show("Please login first.", "Login required");
                Form login = new Login();
                login.Show();
            }
        }

        private void Home_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form login = new Login();
            login.Show();
        }

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.session_name == null)
            {
                MessageBox.Show("You are not logged in currently.", "Not logged in");
            }
            else
            {
                Session.session_name = null;
                MessageBox.Show("You have successfully logged out of the system!", "Logout successfully");
            }
        }
    }
}
