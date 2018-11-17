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
    public partial class Analytics : Form
    {
        public Analytics()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form numBugs = new NumBugs();
            numBugs.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form fixedNums = new FixedUnfixed();
            fixedNums.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form propro = new ProPro();
            propro.Show();
        }
    }
}
