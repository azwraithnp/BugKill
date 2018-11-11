using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bug_Tracking
{
    public partial class ViewScreenshot : Form
    {
        public ViewScreenshot()
        {
            InitializeComponent();
            MemoryStream ms = new MemoryStream(Session.imageData);
            Image returnImage = Image.FromStream(ms);
            pictureBox1.Image = returnImage;
        }
        
    }
}
