using System;
using System.Windows.Forms;

namespace Bug_Tracking
{
    public partial class Analytics : Form
    {
        public Analytics()
        {
            InitializeComponent();
        }

        //Displays the form for showing chart for number of bugs in a year
        private void button1_Click(object sender, EventArgs e)
        {
            Form numBugs = new NumBugs();
            numBugs.Show();
        }

        //Displays the form for showing chart for number of fixed and unfixed bugs in a year
        private void button2_Click(object sender, EventArgs e)
        {
            Form fixedNums = new FixedUnfixed();
            fixedNums.Show();
        }

        //Displays the form for showing the most successful programmers solving the bugs
        private void button3_Click(object sender, EventArgs e)
        {
            Form propro = new ProPro();
            propro.Show();
        }
    }
}
