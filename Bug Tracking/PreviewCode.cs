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
    /// Creates a form that allows user to preview code submittied with the bug
    /// </summary>
    public partial class PreviewCode : Form
    {
        
        public PreviewCode()
        {
            InitializeComponent();
            string code = Session.code;

            FileSyntaxModeProvider fsmp;
            string dirc = Application.StartupPath;
            
            if(Directory.Exists(dirc))
            {
                fsmp = new FileSyntaxModeProvider(dirc);
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
            }
            textEditorControl1.SetHighlighting("C#");
            textEditorControl1.Text = code;
            textEditorControl1.IsReadOnly = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void PreviewCode_Load(object sender, EventArgs e)
        {

        }

        private void textEditorControl1_Load(object sender, EventArgs e)
        {

        }
    }
}
