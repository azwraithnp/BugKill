namespace Bug_Tracking
{
    partial class PreviewCode
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 61);
            this.label1.TabIndex = 3;
            this.label1.Text = "Code Preview";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.IsReadOnly = false;
            this.textEditorControl1.Location = new System.Drawing.Point(12, 87);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.Size = new System.Drawing.Size(776, 470);
            this.textEditorControl1.TabIndex = 4;
            this.textEditorControl1.Text = "textEditorControl1";
            this.textEditorControl1.Load += new System.EventHandler(this.textEditorControl1_Load);
            // 
            // PreviewCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 569);
            this.Controls.Add(this.textEditorControl1);
            this.Controls.Add(this.label1);
            this.Name = "PreviewCode";
            this.Text = "PreviewCode";
            this.Load += new System.EventHandler(this.PreviewCode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
    }
}