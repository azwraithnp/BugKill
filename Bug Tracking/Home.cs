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
            Form login = new Login();
            login.Show();
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

        }
    }
}
