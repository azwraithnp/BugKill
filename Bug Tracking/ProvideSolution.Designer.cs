namespace Bug_Tracking
{
    partial class ProvideSolution
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
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.summary = new System.Windows.Forms.Label();
            this.textEditorControl1 = new ICSharpCode.TextEditor.TextEditorControl();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 61);
            this.label1.TabIndex = 4;
            this.label1.Text = "Provide a solution";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(95, 90);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox2.Size = new System.Drawing.Size(693, 59);
            this.textBox2.TabIndex = 15;
            // 
            // summary
            // 
            this.summary.AutoSize = true;
            this.summary.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.summary.Location = new System.Drawing.Point(17, 90);
            this.summary.Name = "summary";
            this.summary.Size = new System.Drawing.Size(72, 18);
            this.summary.TabIndex = 14;
            this.summary.Text = "Summary";
            // 
            // textEditorControl1
            // 
            this.textEditorControl1.IsReadOnly = false;
            this.textEditorControl1.Location = new System.Drawing.Point(12, 227);
            this.textEditorControl1.Name = "textEditorControl1";
            this.textEditorControl1.Size = new System.Drawing.Size(776, 327);
            this.textEditorControl1.TabIndex = 16;
            this.textEditorControl1.Text = "textEditorControl1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(20, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(529, 18);
            this.label2.TabIndex = 17;
            this.label2.Text = "Enter your code below and click on \'Done\' below when you are ready to submit.";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(642, 582);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(137, 64);
            this.button1.TabIndex = 18;
            this.button1.Text = "Done";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ProvideSolution
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 669);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textEditorControl1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.summary);
            this.Controls.Add(this.label1);
            this.Name = "ProvideSolution";
            this.Text = "Provide solution";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label summary;
        private ICSharpCode.TextEditor.TextEditorControl textEditorControl1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}