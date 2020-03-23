namespace Playa
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
            this.components = new System.ComponentModel.Container();
            this.lsname = new System.Windows.Forms.Label();
            this.bplay = new System.Windows.Forms.Button();
            this.bstop = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tvolume = new System.Windows.Forms.TrackBar();
            this.lvol = new System.Windows.Forms.Label();
            this.bopen = new System.Windows.Forms.Button();
            this.ofDialog = new System.Windows.Forms.OpenFileDialog();
            this.chrepeat = new System.Windows.Forms.CheckBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ltime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tvolume)).BeginInit();
            this.SuspendLayout();
            // 
            // lsname
            // 
            this.lsname.AutoSize = true;
            this.lsname.ForeColor = System.Drawing.Color.Red;
            this.lsname.Location = new System.Drawing.Point(12, 11);
            this.lsname.Name = "lsname";
            this.lsname.Size = new System.Drawing.Size(100, 18);
            this.lsname.TabIndex = 0;
            this.lsname.Text = "l song name";
            // 
            // bplay
            // 
            this.bplay.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bplay.Location = new System.Drawing.Point(12, 82);
            this.bplay.Name = "bplay";
            this.bplay.Size = new System.Drawing.Size(88, 35);
            this.bplay.TabIndex = 1;
            this.bplay.Text = "play";
            this.bplay.UseVisualStyleBackColor = false;
            this.bplay.Click += new System.EventHandler(this.bplay_Click);
            // 
            // bstop
            // 
            this.bstop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bstop.Location = new System.Drawing.Point(117, 82);
            this.bstop.Name = "bstop";
            this.bstop.Size = new System.Drawing.Size(88, 35);
            this.bstop.TabIndex = 3;
            this.bstop.Text = "stop";
            this.bstop.UseVisualStyleBackColor = false;
            this.bstop.Click += new System.EventHandler(this.bstop_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.ForeColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(12, 41);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(440, 23);
            this.progressBar1.TabIndex = 4;
            this.progressBar1.Value = 10;
            this.progressBar1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.progressBar1_MouseClick);
            // 
            // tvolume
            // 
            this.tvolume.Location = new System.Drawing.Point(356, 82);
            this.tvolume.Name = "tvolume";
            this.tvolume.Size = new System.Drawing.Size(89, 42);
            this.tvolume.TabIndex = 6;
            this.tvolume.Value = 10;
            this.tvolume.ValueChanged += new System.EventHandler(this.trackBar1_ValueChanged);
            // 
            // lvol
            // 
            this.lvol.AutoSize = true;
            this.lvol.Location = new System.Drawing.Point(286, 90);
            this.lvol.Name = "lvol";
            this.lvol.Size = new System.Drawing.Size(64, 18);
            this.lvol.TabIndex = 7;
            this.lvol.Text = "Volume";
            // 
            // bopen
            // 
            this.bopen.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bopen.Location = new System.Drawing.Point(470, 82);
            this.bopen.Name = "bopen";
            this.bopen.Size = new System.Drawing.Size(88, 35);
            this.bopen.TabIndex = 8;
            this.bopen.Text = "open";
            this.bopen.UseVisualStyleBackColor = false;
            this.bopen.Click += new System.EventHandler(this.bopen_Click);
            // 
            // ofDialog
            // 
            this.ofDialog.FileName = "Most Emotional OSTs Ever_ The Father\'s Heart.mp3";
            this.ofDialog.Filter = "Mp3 files|*.mp3";
            this.ofDialog.InitialDirectory = "C:\\Users\\StravoS\\Music";
            // 
            // chrepeat
            // 
            this.chrepeat.AutoSize = true;
            this.chrepeat.Location = new System.Drawing.Point(470, 41);
            this.chrepeat.Name = "chrepeat";
            this.chrepeat.Size = new System.Drawing.Size(74, 22);
            this.chrepeat.TabIndex = 9;
            this.chrepeat.Text = "repeat";
            this.chrepeat.UseVisualStyleBackColor = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ltime
            // 
            this.ltime.AutoSize = true;
            this.ltime.ForeColor = System.Drawing.Color.Red;
            this.ltime.Location = new System.Drawing.Point(403, 11);
            this.ltime.Name = "ltime";
            this.ltime.Size = new System.Drawing.Size(49, 18);
            this.ltime.TabIndex = 10;
            this.ltime.Text = "00:00";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(570, 127);
            this.Controls.Add(this.ltime);
            this.Controls.Add(this.chrepeat);
            this.Controls.Add(this.bopen);
            this.Controls.Add(this.lvol);
            this.Controls.Add(this.tvolume);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.bstop);
            this.Controls.Add(this.bplay);
            this.Controls.Add(this.lsname);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Red;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tvolume)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lsname;
        private System.Windows.Forms.Button bplay;
        private System.Windows.Forms.Button bstop;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TrackBar tvolume;
        private System.Windows.Forms.Label lvol;
        private System.Windows.Forms.Button bopen;
        private System.Windows.Forms.OpenFileDialog ofDialog;
        private System.Windows.Forms.CheckBox chrepeat;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label ltime;
    }
}

