namespace Bug_Tracking
{
    partial class Home
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bugLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.bugLogsToolStripMenuItem,
            this.addNewProductToolStripMenuItem,
            this.addNewBugToolStripMenuItem,
            this.requestReportToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.homeToolStripMenuItem.Text = "Login";
            this.homeToolStripMenuItem.Click += new System.EventHandler(this.homeToolStripMenuItem_Click);
            // 
            // bugLogsToolStripMenuItem
            // 
            this.bugLogsToolStripMenuItem.Name = "bugLogsToolStripMenuItem";
            this.bugLogsToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.bugLogsToolStripMenuItem.Text = "Bug logs";
            this.bugLogsToolStripMenuItem.Click += new System.EventHandler(this.bugLogsToolStripMenuItem_Click_1);
            // 
            // addNewProductToolStripMenuItem
            // 
            this.addNewProductToolStripMenuItem.Name = "addNewProductToolStripMenuItem";
            this.addNewProductToolStripMenuItem.Size = new System.Drawing.Size(111, 20);
            this.addNewProductToolStripMenuItem.Text = "Add new product";
            this.addNewProductToolStripMenuItem.Click += new System.EventHandler(this.addNewProductToolStripMenuItem_Click_1);
            // 
            // addNewBugToolStripMenuItem
            // 
            this.addNewBugToolStripMenuItem.Name = "addNewBugToolStripMenuItem";
            this.addNewBugToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.addNewBugToolStripMenuItem.Text = "Add new bug";
            this.addNewBugToolStripMenuItem.Click += new System.EventHandler(this.addNewBugToolStripMenuItem_Click_1);
            // 
            // requestReportToolStripMenuItem
            // 
            this.requestReportToolStripMenuItem.Name = "requestReportToolStripMenuItem";
            this.requestReportToolStripMenuItem.Size = new System.Drawing.Size(96, 20);
            this.requestReportToolStripMenuItem.Text = "Request report";
            this.requestReportToolStripMenuItem.Click += new System.EventHandler(this.requestReportToolStripMenuItem_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "Home";
            this.Text = "Home";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem homeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bugLogsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewProductToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addNewBugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem requestReportToolStripMenuItem;
    }
}

