using System;
using System.Windows.Forms;

namespace Bug_Tracking
{

    /// <summary>
    /// Creates a form that allows user to search for specific bugs in the system
    /// </summary>
    public partial class SearchBug : Form
    {
        public SearchBug()
        {
            InitializeComponent();
        }

        private void SearchBug_Load(object sender, EventArgs e)
        {
            //Add search terms to select into combobox
            comboBox1.Items.Add("bugid");
            comboBox1.Items.Add("reporter");
            comboBox1.Items.Add("date_recorded");
            comboBox1.Items.Add("deadline");
            comboBox1.Items.Add("version");
            comboBox1.Items.Add("severity");
            comboBox1.Items.Add("platform");
            comboBox1.Items.Add("product");

            //Set first index of the combobox to be select a search by keyword
            comboBox1.Items.Insert(0, "Select a search by keyword");
            comboBox1.SelectedIndex = 0;
        }
        
        /** Creates a method for submit method,
         *  checks whether a keyword is selected from the combobox,
         *  checks whether the search term is empty,
         *  if data is entered properly, opens up the viewbugs form by passing search terms in Session */
        private void button1_Click(object sender, EventArgs e)
        {
            if(comboBox1.SelectedIndex == 0)
            {
                errorProvider.SetError(comboBox1, "Please select a search by keyword!");

            }
            else if(textBox3.Text.Length == 0)
            {
                errorProvider.SetError(comboBox1, null);
                errorProvider.SetError(textBox3, "Search term cannot be empty!");
            }
            else
            {
                errorProvider.SetError(textBox3, null);
                //Saves the entered search keyword and term in Session to be used later 
                Session.searchBy = comboBox1.SelectedItem.ToString();
                Session.searchTerm = textBox3.Text;
                Form viewBugs = new ViewBugs();
                viewBugs.Show();
            }
        }
    }
}
