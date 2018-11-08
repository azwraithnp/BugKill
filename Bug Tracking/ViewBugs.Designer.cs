namespace Bug_Tracking
{
    partial class ViewBugs
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
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.chid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chproduct = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chreporter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chversion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chseverity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chplatform = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chdeadline = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.chfixed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 26.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 61);
            this.label1.TabIndex = 1;
            this.label1.Text = "View bugs";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(776, 48);
            this.label4.TabIndex = 6;
            this.label4.Text = "Below are the basic details of the bugs recorded in our system by black-box teste" +
    "rs. If you are a programmer or developer please preview the bug to provide detai" +
    "led description of the bug.";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chid,
            this.chproduct,
            this.chreporter,
            this.chversion,
            this.chseverity,
            this.chplatform,
            this.chdeadline,
            this.chfixed});
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(12, 164);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(772, 301);
            this.listView1.TabIndex = 7;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // chid
            // 
            this.chid.Text = "ID";
            this.chid.Width = 29;
            // 
            // chproduct
            // 
            this.chproduct.Text = "Product";
            this.chproduct.Width = 129;
            // 
            // chreporter
            // 
            this.chreporter.Text = "Reporter";
            this.chreporter.Width = 128;
            // 
            // chversion
            // 
            this.chversion.Text = "Version";
            this.chversion.Width = 54;
            // 
            // chseverity
            // 
            this.chseverity.Text = "Severity";
            this.chseverity.Width = 121;
            // 
            // chplatform
            // 
            this.chplatform.Text = "Platform";
            this.chplatform.Width = 120;
            // 
            // chdeadline
            // 
            this.chdeadline.Text = "Deadline";
            this.chdeadline.Width = 121;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DarkBlue;
            this.label2.Location = new System.Drawing.Point(12, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(776, 27);
            this.label2.TabIndex = 8;
            this.label2.Text = "TIP: To view a bug in detail click on its ID number";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // chfixed
            // 
            this.chfixed.Text = "Fixed";
            this.chfixed.Width = 70;
            // 
            // ViewBugs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 504);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "ViewBugs";
            this.Text = "View Bugs";
            this.Load += new System.EventHandler(this.ViewBugs_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader chid;
        private System.Windows.Forms.ColumnHeader chproduct;
        private System.Windows.Forms.ColumnHeader chreporter;
        private System.Windows.Forms.ColumnHeader chversion;
        private System.Windows.Forms.ColumnHeader chseverity;
        private System.Windows.Forms.ColumnHeader chplatform;
        private System.Windows.Forms.ColumnHeader chdeadline;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader chfixed;
    }
}