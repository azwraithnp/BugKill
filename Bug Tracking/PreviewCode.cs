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
    public partial class PreviewCode : Form
    {
        public PreviewCode()
        {
            InitializeComponent();

            textBox1.Text = Session.code.Replace("\n", Environment.NewLine);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
