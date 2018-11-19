using ICSharpCode.TextEditor.Document;
using System;
using System.IO;
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
            //Creates a FileSyntaxModeProvider object to provide binary for the color syntaxing
            FileSyntaxModeProvider fsmp;

            //Provide directory path for fsmp object
            string dirc = Application.StartupPath;

            //Checks if the provided directory path exists
            if (Directory.Exists(dirc))
            {
                //Initialize the fsmp object with the provided directory path
                fsmp = new FileSyntaxModeProvider(dirc);

                /*Pass the fsmp object created as argument for the sytanxmodefileprovider 
                 * of highlightingmanager of the texteditor */
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
            }

            //Set syntax highlighting mode to be C#
            textEditorControl1.SetHighlighting("C#");

            //Disable editing for the preview code texteditor
            textEditorControl1.Text = "//enter your code here";

        }

        //Saves the written code to written code variable in Session on clicking submit button
        private void button1_Click(object sender, EventArgs e)
        {
            Session.writtencode = textEditorControl1.Text;
        }
    }
}
