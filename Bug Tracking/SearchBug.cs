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
    public partial class SearchBug : Form
    {
        public SearchBug()
        {
            InitializeComponent();
        }

        private void SearchBug_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("bugid");
            comboBox1.Items.Add("reporter");
            comboBox1.Items.Add("version");
            comboBox1.Items.Add("severity");
            comboBox1.Items.Add("platform");
            comboBox1.Items.Add("product");

            comboBox1.Items.Insert(0, "Select a search by keyword");
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

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
                Session.searchBy = comboBox1.SelectedItem.ToString();
                Session.searchTerm = textBox3.Text;
                Form viewBugs = new ViewBugs();
                viewBugs.Show();
            }
        }
    }
}
