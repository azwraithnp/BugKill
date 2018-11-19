using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Bug_Tracking
{

    /// <summary>
    /// Creates an MDI form that serves as the entry point in the application
    /// </summary>
    public partial class Home : Form
    {
        //Creates a connection object for mysql client
        MySqlConnection dbConn;

        public Home()
        {
            InitializeComponent();

            //Creates a connections object to initialize mysql connection
            Connections conn = new Connections();
            dbConn = conn.initializeConn();
            try
            {
                dbConn.Open();
            }
            //If sql database is not running, display a warning messagebox to the user
            catch (Exception ex)
            {
                MessageBox.Show("Warning: mySQL database is not connected. Functional database is required to use this application properly. Please open it before continuing otherwise the app may crash!\n\nError message: " + ex, "Database not connected");
            }
        }
        
        //Checks if user is logged in then opens a form to view bugs
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

        //Checks if user is logged in then opens a form to add product
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

        //Checks if user is logged in then opens a form to login
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

        //Checks if user is logged in then opens a form to add new bug
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

        //Checks if user is logged in then opens a form to search bugs
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
        
        //Opens a form to login or create account when link label is clicked
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form login = new Login();
            login.Show();
        }

        //Opens a form to logout the session
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

        //Checks if user is logged in then opens the version control system
        private void openVCSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Session.session_name != null)
            {
                //Creates a ChromeOptions object to set the webdriver properties
                ChromeOptions opt = new ChromeOptions();

                /* Sets the page load strategy to none so that,
                 * the web driver doesn't wait the page to be fully loaded
                 * to carry on the following tasks */
                opt.PageLoadStrategy = PageLoadStrategy.None;

                //Creates a new webdriver for Chrome using the options object
                ChromeDriver cd = new ChromeDriver(opt);

                //Sets the url to load for the webdriver to be login page of github.com
                cd.Url = "https://github.com/login";
                
                //Finds the login and password field then enters the credentials to login
                cd.FindElement(By.Id("login_field")).SendKeys("avimshra@gmail.com");
                cd.FindElement(By.Id("password")).SendKeys(Connections.pass + OpenQA.Selenium.Keys.Enter);
                
                //After logged in to github, displays the repository for this project
                cd.Url = "https://github.com/azwraithnp/BugKill";

                //Maximizes the repository page window for better preview
                cd.Manage().Window.Maximize();

            }
            else
            {
                MessageBox.Show("Please login first.", "Login required");
                Form login = new Login();
                login.Show();
            }
            
        }

        //Checks if the user is logged in then displays the analytics form
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
