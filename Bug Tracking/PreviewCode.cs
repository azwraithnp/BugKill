using ICSharpCode.TextEditor.Document;
using System.IO;
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

            //Creates a variable that stores the source code retrieved from Session
            string code = Session.code;

            //Creates a FileSyntaxModeProvider object to provide binary for the color syntaxing
            FileSyntaxModeProvider fsmp;
            
            //Provide directory path for fsmp object
            string dirc = Application.StartupPath;
            
            //Checks if the provided directory path exists
            if(Directory.Exists(dirc))
            {
                //Initialize the fsmp object with the provided directory path
                fsmp = new FileSyntaxModeProvider(dirc);
                
                /*Pass the fsmp object created as argument for the sytanxmodefileprovider 
                 * of highlightingmanager of the texteditor */
                HighlightingManager.Manager.AddSyntaxModeFileProvider(fsmp);
            }

            //Set syntax highlighting mode to be C#
            textEditorControl1.SetHighlighting("C#");

            //Set texteditor text to be the source code
            textEditorControl1.Text = code;

            //Disable editing for the preview code texteditor
            textEditorControl1.IsReadOnly = true;
        }
    }
}
