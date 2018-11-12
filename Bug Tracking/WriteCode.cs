using ICSharpCode.TextEditor.Document;
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

    /// <summary>
    /// Creates a form that allows user or programmer to write code for the bug to be submitted
    /// </summary>
    public partial class WriteCode : Form
    {
        public WriteCode()
        {
            InitializeComponent();
            
            
        }

        private void WriteCode_Load(object sender, EventArgs e)
        {
            FileSyntaxModeProvider fsmp;
            string dirc = Application.StartupPath;

            if (Directory.Exists(dirc))
            {
                fsmp = new FileSyntaxModeProvider(dirc);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
            }
            textEditorControl1.SetHighlighting("C#");
            textEditorControl1.Text = "//enter your code here";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Session.writtencode = textEditorControl1.Text;
        }
    }
}
