namespace FileSort
{
    partial class Form1
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
            this.lcfile = new System.Windows.Forms.Label();
            this.lstatus = new System.Windows.Forms.Label();
            this.tbdir = new System.Windows.Forms.TextBox();
            this.bbrowse = new System.Windows.Forms.Button();
            this.bsort = new System.Windows.Forms.Button();
            this.lfname = new System.Windows.Forms.Label();
            this.cimg = new System.Windows.Forms.CheckBox();
            this.cdoc = new System.Windows.Forms.CheckBox();
            this.cvid = new System.Windows.Forms.CheckBox();
            this.capp = new System.Windows.Forms.CheckBox();
            this.folderDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // lcfile
            // 
            this.lcfile.AutoSize = true;
            this.lcfile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcfile.Location = new System.Drawing.Point(23, 85);
            this.lcfile.Name = "lcfile";
            this.lcfile.Size = new System.Drawing.Size(101, 18);
            this.lcfile.TabIndex = 0;
            this.lcfile.Text = "Current File:";
            // 
            // lstatus
            // 
            this.lstatus.AutoSize = true;
            this.lstatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstatus.Location = new System.Drawing.Point(220, 24);
            this.lstatus.Name = "lstatus";
            this.lstatus.Size = new System.Drawing.Size(133, 18);
            this.lstatus.TabIndex = 1;
            this.lstatus.Text = "waiting for you...";
            // 
            // tbdir
            // 
            this.tbdir.Enabled = false;
            this.tbdir.Location = new System.Drawing.Point(173, 143);
            this.tbdir.Name = "tbdir";
            this.tbdir.Size = new System.Drawing.Size(344, 20);
            this.tbdir.TabIndex = 2;
            // 
            // bbrowse
            // 
            this.bbrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bbrowse.Location = new System.Drawing.Point(523, 140);
            this.bbrowse.Name = "bbrowse";
            this.bbrowse.Size = new System.Drawing.Size(30, 23);
            this.bbrowse.TabIndex = 3;
            this.bbrowse.Text = "...";
            this.bbrowse.UseVisualStyleBackColor = true;
            this.bbrowse.Click += new System.EventHandler(this.bbrowse_Click);
            // 
            // bsort
            // 
            this.bsort.Enabled = false;
            this.bsort.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsort.Location = new System.Drawing.Point(25, 140);
            this.bsort.Name = "bsort";
            this.bsort.Size = new System.Drawing.Size(99, 23);
            this.bsort.TabIndex = 4;
            this.bsort.Text = "Sort";
            this.bsort.UseVisualStyleBackColor = true;
            this.bsort.Click += new System.EventHandler(this.bsort_Click);
            // 
            // lfname
            // 
            this.lfname.AutoSize = true;
            this.lfname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lfname.Location = new System.Drawing.Point(170, 85);
            this.lfname.Name = "lfname";
            this.lfname.Size = new System.Drawing.Size(20, 18);
            this.lfname.TabIndex = 5;
            this.lfname.Text = "--";
            // 
            // cimg
            // 
            this.cimg.AutoSize = true;
            this.cimg.Checked = true;
            this.cimg.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cimg.Enabled = false;
            this.cimg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cimg.Location = new System.Drawing.Point(94, 214);
            this.cimg.Name = "cimg";
            this.cimg.Size = new System.Drawing.Size(78, 21);
            this.cimg.TabIndex = 6;
            this.cimg.Text = "Images";
            this.cimg.UseVisualStyleBackColor = true;
            // 
            // cdoc
            // 
            this.cdoc.AutoSize = true;
            this.cdoc.Checked = true;
            this.cdoc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cdoc.Enabled = false;
            this.cdoc.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cdoc.Location = new System.Drawing.Point(94, 261);
            this.cdoc.Name = "cdoc";
            this.cdoc.Size = new System.Drawing.Size(113, 22);
            this.cdoc.TabIndex = 7;
            this.cdoc.Text = "Documents";
            this.cdoc.UseVisualStyleBackColor = true;
            // 
            // cvid
            // 
            this.cvid.AutoSize = true;
            this.cvid.Checked = true;
            this.cvid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cvid.Enabled = false;
            this.cvid.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cvid.Location = new System.Drawing.Point(357, 214);
            this.cvid.Name = "cvid";
            this.cvid.Size = new System.Drawing.Size(78, 22);
            this.cvid.TabIndex = 8;
            this.cvid.Text = "Videos";
            this.cvid.UseVisualStyleBackColor = true;
            // 
            // capp
            // 
            this.capp.AutoSize = true;
            this.capp.Checked = true;
            this.capp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.capp.Enabled = false;
            this.capp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.capp.Location = new System.Drawing.Point(357, 261);
            this.capp.Name = "capp";
            this.capp.Size = new System.Drawing.Size(109, 22);
            this.capp.TabIndex = 9;
            this.capp.Text = "Application";
            this.capp.UseVisualStyleBackColor = true;
            // 
            // folderDialog
            // 
            this.folderDialog.RootFolder = System.Environment.SpecialFolder.UserProfile;
            this.folderDialog.SelectedPath = "D:\\";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 314);
            this.Controls.Add(this.capp);
            this.Controls.Add(this.cvid);
            this.Controls.Add(this.cdoc);
            this.Controls.Add(this.cimg);
            this.Controls.Add(this.lfname);
            this.Controls.Add(this.bsort);
            this.Controls.Add(this.bbrowse);
            this.Controls.Add(this.tbdir);
            this.Controls.Add(this.lstatus);
            this.Controls.Add(this.lcfile);
            this.Name = "Form1";
            this.Text = "Sort Folder";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lcfile;
        private System.Windows.Forms.Label lstatus;
        private System.Windows.Forms.TextBox tbdir;
        private System.Windows.Forms.Button bbrowse;
        private System.Windows.Forms.Button bsort;
        private System.Windows.Forms.Label lfname;
        private System.Windows.Forms.CheckBox cimg;
        private System.Windows.Forms.CheckBox cdoc;
        private System.Windows.Forms.CheckBox cvid;
        private System.Windows.Forms.CheckBox capp;
        private System.Windows.Forms.FolderBrowserDialog folderDialog;
    }
}

