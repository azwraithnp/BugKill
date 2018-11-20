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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.homeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bugLogsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewProductToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addNewBugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.requestReportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openVCSToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.analyticsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.logoutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label4 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.homeToolStripMenuItem,
            this.bugLogsToolStripMenuItem,
            this.addNewProductToolStripMenuItem,
            this.addNewBugToolStripMenuItem,
            this.requestReportToolStripMenuItem,
            this.openVCSToolStripMenuItem,
            this.analyticsToolStripMenuItem,
            this.logoutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // homeToolStripMenuItem
            // 
            this.homeToolStripMenuItem.Name = "homeToolStripMenuItem";
            this.homeToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.homeToolStripMenuItem.Text = "Login/Join";
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
            this.requestReportToolStripMenuItem.Size = new System.Drawing.Size(125, 20);
            this.requestReportToolStripMenuItem.Text = "Request/Search Bug";
            this.requestReportToolStripMenuItem.Click += new System.EventHandler(this.requestReportToolStripMenuItem_Click);
            // 
            // openVCSToolStripMenuItem
            // 
            this.openVCSToolStripMenuItem.Name = "openVCSToolStripMenuItem";
            this.openVCSToolStripMenuItem.Size = new System.Drawing.Size(72, 20);
            this.openVCSToolStripMenuItem.Text = "Open VCS";
            this.openVCSToolStripMenuItem.Click += new System.EventHandler(this.openVCSToolStripMenuItem_Click);
            // 
            // analyticsToolStripMenuItem
            // 
            this.analyticsToolStripMenuItem.Name = "analyticsToolStripMenuItem";
            this.analyticsToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.analyticsToolStripMenuItem.Text = "Analytics";
            this.analyticsToolStripMenuItem.Click += new System.EventHandler(this.analyticsToolStripMenuItem_Click);
            // 
            // logoutToolStripMenuItem
            // 
            this.logoutToolStripMenuItem.Name = "logoutToolStripMenuItem";
            this.logoutToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.logoutToolStripMenuItem.Text = "Logout";
            this.logoutToolStripMenuItem.Click += new System.EventHandler(this.logoutToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pictureBox4);
            this.panel1.Controls.Add(this.pictureBox3);
            this.panel1.Controls.Add(this.pictureBox2);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.linkLabel1);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(12, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 599);
            this.panel1.TabIndex = 10;
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(598, 419);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(127, 127);
            this.pictureBox4.TabIndex = 22;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(270, 419);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(222, 127);
            this.pictureBox3.TabIndex = 21;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(40, 419);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(127, 127);
            this.pictureBox2.TabIndex = 20;
            this.pictureBox2.TabStop = false;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Location = new System.Drawing.Point(-1, 437);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(774, 2);
            this.label7.TabIndex = 19;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(56, 324);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(408, 18);
            this.label6.TabIndex = 18;
            this.label6.Text = "- Ability to search specific bug(s) according to their properties";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(56, 274);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(441, 18);
            this.label5.TabIndex = 17;
            this.label5.Text = "- Database integration for better management and security of bugs";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(56, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(388, 18);
            this.label3.TabIndex = 16;
            this.label3.Text = "- Interactive colorized syntax for code preview to the bugs ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(56, 173);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(436, 18);
            this.label2.TabIndex = 15;
            this.label2.Text = "- Display a detailed listview for all the bugs recorded in the system";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(18, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 18);
            this.label1.TabIndex = 14;
            this.label1.Text = "Recent changes and additions";
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(18, 76);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(201, 18);
            this.linkLabel1.TabIndex = 13;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Login/Join now to get started!";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(523, 143);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(202, 199);
            this.pictureBox1.TabIndex = 12;
            this.pictureBox1.TabStop = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(743, 54);
            this.label4.TabIndex = 11;
            this.label4.Text = "Welcome to BugKill. An interactive platform where u can manage and deal with thos" +
    "e annoying bugs you face in your software or development process. ";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 657);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.Name = "Home";
            this.Text = "Home";
            this.Resize += new System.EventHandler(this.form_resized);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.ToolStripMenuItem logoutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openVCSToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem analyticsToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}

