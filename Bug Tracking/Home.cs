using System;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Bug_Tracking
{

    /// <summary>
    /// Creates an MDI form that serves as the entry point in the application
    /// </summary>
    public partial class Home : Form
    {
        //Creates a connection object for mysql client
        MySqlConnection dbConn;

        private System.Windows.Forms.ContextMenu contextMenu1;
        private System.Windows.Forms.MenuItem exitItem;
        private System.Windows.Forms.MenuItem viewBugs;
        private System.Windows.Forms.MenuItem addnewBug;
        private System.Windows.Forms.MenuItem openVCS;
        private System.Windows.Forms.MenuItem logout;

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

                WebDriverWait wait = new WebDriverWait(cd, TimeSpan.FromSeconds(4));

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

        /** Creates a method for when the form is resized,
         *  initializes the notifyIcon object and specifies its properties,
         *  adds a context menu to the notifyIcon so that user can carry on the basic functions right from here,
         *  adds functions for doubleclicking the notifyIcon */
        private void form_resized(object sender, EventArgs e)
        {
            //Sets the balloon tooltip title for the notifyIcon
            notifyIcon1.BalloonTipTitle = "Bugkill";

            //Sets the balloon tooltip text for the notifyIcon
            notifyIcon1.BalloonTipText = "Application is still running here.";

            //Sets the icon for the notifyIcon itself
            notifyIcon1.Icon = new System.Drawing.Icon("logo.ico");

            //Sets the text for notifyIcon to display when hovering over it
            notifyIcon1.Text = "Bugkill";

            //Initializes the context menu as a windows form component
            this.contextMenu1 = new System.Windows.Forms.ContextMenu();

            //Initializes the exit menu item as a windows form component
            this.exitItem = new System.Windows.Forms.MenuItem();

            //Initializes the view bugs menu item as a windows form component
            this.viewBugs = new System.Windows.Forms.MenuItem();

            //Initializes the add new bug menu item as a windows form component
            this.addnewBug = new System.Windows.Forms.MenuItem();

            //Initializes the open VCS menu item as a windows form component
            this.openVCS = new System.Windows.Forms.MenuItem();

            //Initializes the logout menu item as a windows form component
            this.logout = new System.Windows.Forms.MenuItem();

            // Initialize contextMenu1
            this.contextMenu1.MenuItems.AddRange(
            new System.Windows.Forms.MenuItem[] { this.exitItem, this.viewBugs, this.addnewBug, this.openVCS, this.logout });

            // Initialize view bugs menu item
            this.viewBugs.Index = 0;
            this.viewBugs.Text = "View bugs";
            this.viewBugs.Click += new System.EventHandler(this.bugLogsToolStripMenuItem_Click_1);

            // Initialize add new bug menu item
            this.addnewBug.Index = 1;
            this.addnewBug.Text = "Add new bug";
            this.addnewBug.Click += new System.EventHandler(this.addNewBugToolStripMenuItem_Click_1);

            // Initialize open vcs menu item
            this.openVCS.Index = 2;
            this.openVCS.Text = "Open VCS";
            this.openVCS.Click += new System.EventHandler(this.openVCSToolStripMenuItem_Click);

            // Initialize logout menu item
            this.logout.Index = 3;
            this.logout.Text = "Logout";
            this.logout.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);

            // Initialize exit menu item
            this.exitItem.Index = 4;
            this.exitItem.Text = "Exit";
            this.exitItem.Click += new System.EventHandler(this.menuItem1_Click);

            //Sets the notifyIcon context menu to be the menu created above
            notifyIcon1.ContextMenu = this.contextMenu1;
            
            //Checks whether this form's window state is minimized
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;         //Sets the notifyIcon visibility to true
                notifyIcon1.ShowBalloonTip(400);    //Displays the balloon tip in the taskbar for 400 ms
                this.Hide();                        //Hides this form 
            }
            //Checks whether this form's window state has become normal
            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;        //Hides the notifyIcon
            }
        }

        //Closes this form when exit is clicked on the context menu of notifyIcon
        private void menuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //Shows this form and returns its windowstate to normal when notifyIcon is double-clicked
        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }
    }
}
