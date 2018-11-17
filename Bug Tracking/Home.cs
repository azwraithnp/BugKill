using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Bug_Tracking
{

    /// <summary>
    /// Creates an MDI form that serves as the entry point in the application
    /// </summary>
    public partial class Home : Form
    {
        MySqlConnection dbConn;

        public Home()
        {
            InitializeComponent();
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            try
            {
                dbConn.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Warning: mySQL database is not connected. Functional database is required to use this application properly. Please open it before continuing otherwise the app may crash!\n\nError message: " + ex, "Database not connected");
            }
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

        private void openVCSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.session_name != null)
            {
                ChromeDriver cd = new ChromeDriver();
                cd.Url = "https://github.com/login";

                cd.FindElement(By.Id("login_field")).SendKeys("avimshra@gmail.com");
                cd.FindElement(By.Id("password")).SendKeys("babumishra1" + OpenQA.Selenium.Keys.Enter);

                cd.Url = "https://github.com/azwraithnp/BugKill";
                cd.Manage().Window.Maximize();
            }
            else
            {
                MessageBox.Show("Please login first.", "Login required");
                Form login = new Login();
                login.Show();
            }
            
        }

        private void analyticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.session_name != null)
            {
                Form analytics = new Analytics();
                analytics.Show();
            }
            else
            {
                MessageBox.Show("Please login first.", "Login required");
                Form login = new Login();
                login.Show();
            }
        }
    }
}
