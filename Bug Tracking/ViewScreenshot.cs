using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Bug_Tracking
{

    /// <summary>
    /// Creates a form that displays screenshot of the bug provided by the reporter
    /// </summary>
    public partial class ViewScreenshot : Form
    {
        //Displays the screenshot provided with the bug
        public ViewScreenshot()
        {
            InitializeComponent();

            //Creates a MemoryStream object to read the contents of the image data
            MemoryStream ms = new MemoryStream(Session.imageData);

            //Creates an Image object with the binary data read from ms object created above
            Image returnImage = Image.FromStream(ms);

            //Sets the picturebox image to be the one created above
            pictureBox1.Image = returnImage;
        }
        
    }
}
