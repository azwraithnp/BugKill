using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracking
{

    

    static class Program
    {
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //MySql.Data.MySqlClient.MySqlConnection dbConn;

            //Connections conn = new Connections();
            //dbConn = conn.initializeConn();
            //dbConn.Open();

            //IWebDriver cd = new FirefoxDriver();
            //cd.Url = "https://github.com/login";

            //cd.Manage().Window.Maximize();
            //cd.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            //cd.FindElement(By.Id("login_field")).SendKeys("avimshra@gmail.com");
            //cd.FindElement(By.Id("password")).SendKeys("babumishra1" + OpenQA.Selenium.Keys.Enter);
                


            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Home());
        }
    }
}
