namespace Arb
{
    partial class ArbForm
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
            this.arbpanel = new System.Windows.Forms.Panel();
            this.singlepanel = new System.Windows.Forms.Panel();
            this.tbchange = new System.Windows.Forms.TextBox();
            this.bchange = new System.Windows.Forms.Button();
            this.tbaddAuto = new System.Windows.Forms.TextBox();
            this.tbaddSt = new System.Windows.Forms.TextBox();
            this.tbaddDr = new System.Windows.Forms.TextBox();
            this.bdel = new System.Windows.Forms.Button();
            this.baddAuto = new System.Windows.Forms.Button();
            this.baddSt = new System.Windows.Forms.Button();
            this.baddDr = new System.Windows.Forms.Button();
            this.grouppanel = new System.Windows.Forms.Panel();
            this.tbsearch = new System.Windows.Forms.TextBox();
            this.bsave = new System.Windows.Forms.Button();
            this.bload = new System.Windows.Forms.Button();
            this.bsearch = new System.Windows.Forms.Button();
            this.blevel = new System.Windows.Forms.Button();
            this.bsort = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.singlepanel.SuspendLayout();
            this.grouppanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // arbpanel
            // 
            this.arbpanel.BackColor = System.Drawing.Color.White;
            this.arbpanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.arbpanel.Location = new System.Drawing.Point(1, 1);
            this.arbpanel.Name = "arbpanel";
            this.arbpanel.Size = new System.Drawing.Size(1887, 212);
            this.arbpanel.TabIndex = 0;
            // 
            // singlepanel
            // 
            this.singlepanel.BackColor = System.Drawing.Color.Silver;
            this.singlepanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.singlepanel.Controls.Add(this.baddDr);
            this.singlepanel.Controls.Add(this.tbaddDr);
            this.singlepanel.Controls.Add(this.tbchange);
            this.singlepanel.Controls.Add(this.bchange);
            this.singlepanel.Controls.Add(this.tbaddAuto);
            this.singlepanel.Controls.Add(this.tbaddSt);
            this.singlepanel.Controls.Add(this.bdel);
            this.singlepanel.Controls.Add(this.baddAuto);
            this.singlepanel.Controls.Add(this.baddSt);
            this.singlepanel.Location = new System.Drawing.Point(0, 219);
            this.singlepanel.Name = "singlepanel";
            this.singlepanel.Size = new System.Drawing.Size(1888, 64);
            this.singlepanel.TabIndex = 1;
            // 
            // tbchange
            // 
            this.tbchange.Enabled = false;
            this.tbchange.Location = new System.Drawing.Point(362, 22);
            this.tbchange.Name = "tbchange";
            this.tbchange.Size = new System.Drawing.Size(100, 20);
            this.tbchange.TabIndex = 8;
            this.tbchange.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bchange
            // 
            this.bchange.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bchange.Enabled = false;
            this.bchange.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bchange.Location = new System.Drawing.Point(212, 13);
            this.bchange.Name = "bchange";
            this.bchange.Size = new System.Drawing.Size(144, 35);
            this.bchange.TabIndex = 7;
            this.bchange.Text = "Change Value";
            this.bchange.UseVisualStyleBackColor = false;
            this.bchange.Click += new System.EventHandler(this.bchange_Click);
            // 
            // tbaddAuto
            // 
            this.tbaddAuto.Location = new System.Drawing.Point(1365, 22);
            this.tbaddAuto.Name = "tbaddAuto";
            this.tbaddAuto.Size = new System.Drawing.Size(100, 20);
            this.tbaddAuto.TabIndex = 6;
            this.tbaddAuto.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbaddSt
            // 
            this.tbaddSt.Enabled = false;
            this.tbaddSt.Location = new System.Drawing.Point(704, 22);
            this.tbaddSt.Name = "tbaddSt";
            this.tbaddSt.Size = new System.Drawing.Size(100, 20);
            this.tbaddSt.TabIndex = 5;
            this.tbaddSt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbaddDr
            // 
            this.tbaddDr.Enabled = false;
            this.tbaddDr.Location = new System.Drawing.Point(1030, 22);
            this.tbaddDr.Name = "tbaddDr";
            this.tbaddDr.Size = new System.Drawing.Size(100, 20);
            this.tbaddDr.TabIndex = 4;
            this.tbaddDr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bdel
            // 
            this.bdel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bdel.Enabled = false;
            this.bdel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bdel.Location = new System.Drawing.Point(1561, 13);
            this.bdel.Name = "bdel";
            this.bdel.Size = new System.Drawing.Size(124, 35);
            this.bdel.TabIndex = 3;
            this.bdel.Text = "Delete";
            this.bdel.UseVisualStyleBackColor = false;
            this.bdel.Click += new System.EventHandler(this.bdel_Click);
            // 
            // baddAuto
            // 
            this.baddAuto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.baddAuto.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baddAuto.Location = new System.Drawing.Point(1235, 13);
            this.baddAuto.Name = "baddAuto";
            this.baddAuto.Size = new System.Drawing.Size(124, 35);
            this.baddAuto.TabIndex = 2;
            this.baddAuto.Text = "Add Auto";
            this.baddAuto.UseVisualStyleBackColor = false;
            this.baddAuto.Click += new System.EventHandler(this.baddAuto_Click);
            // 
            // baddSt
            // 
            this.baddSt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.baddSt.Enabled = false;
            this.baddSt.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baddSt.Location = new System.Drawing.Point(574, 13);
            this.baddSt.Name = "baddSt";
            this.baddSt.Size = new System.Drawing.Size(124, 35);
            this.baddSt.TabIndex = 1;
            this.baddSt.Text = "Add Left";
            this.baddSt.UseVisualStyleBackColor = false;
            this.baddSt.Click += new System.EventHandler(this.baddSt_Click);
            // 
            // baddDr
            // 
            this.baddDr.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.baddDr.Enabled = false;
            this.baddDr.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.baddDr.Location = new System.Drawing.Point(900, 13);
            this.baddDr.Name = "baddDr";
            this.baddDr.Size = new System.Drawing.Size(124, 35);
            this.baddDr.TabIndex = 0;
            this.baddDr.Text = "Add Right";
            this.baddDr.UseVisualStyleBackColor = false;
            this.baddDr.Click += new System.EventHandler(this.baddDr_Click);
            // 
            // grouppanel
            // 
            this.grouppanel.BackColor = System.Drawing.Color.Silver;
            this.grouppanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grouppanel.Controls.Add(this.tbsearch);
            this.grouppanel.Controls.Add(this.bsave);
            this.grouppanel.Controls.Add(this.bload);
            this.grouppanel.Controls.Add(this.bsearch);
            this.grouppanel.Controls.Add(this.blevel);
            this.grouppanel.Controls.Add(this.bsort);
            this.grouppanel.Location = new System.Drawing.Point(1, 289);
            this.grouppanel.Name = "grouppanel";
            this.grouppanel.Size = new System.Drawing.Size(1888, 64);
            this.grouppanel.TabIndex = 2;
            // 
            // tbsearch
            // 
            this.tbsearch.Location = new System.Drawing.Point(976, 22);
            this.tbsearch.Name = "tbsearch";
            this.tbsearch.Size = new System.Drawing.Size(100, 20);
            this.tbsearch.TabIndex = 7;
            this.tbsearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bsave
            // 
            this.bsave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.bsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsave.Location = new System.Drawing.Point(1459, 13);
            this.bsave.Name = "bsave";
            this.bsave.Size = new System.Drawing.Size(124, 35);
            this.bsave.TabIndex = 8;
            this.bsave.Text = "File Save";
            this.bsave.UseVisualStyleBackColor = false;
            this.bsave.Click += new System.EventHandler(this.bsave_Click);
            // 
            // bload
            // 
            this.bload.BackColor = System.Drawing.Color.Pink;
            this.bload.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bload.Location = new System.Drawing.Point(1207, 13);
            this.bload.Name = "bload";
            this.bload.Size = new System.Drawing.Size(124, 35);
            this.bload.TabIndex = 7;
            this.bload.Text = "File Load";
            this.bload.UseVisualStyleBackColor = false;
            this.bload.Click += new System.EventHandler(this.bload_Click);
            // 
            // bsearch
            // 
            this.bsearch.BackColor = System.Drawing.Color.Pink;
            this.bsearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsearch.Location = new System.Drawing.Point(846, 13);
            this.bsearch.Name = "bsearch";
            this.bsearch.Size = new System.Drawing.Size(124, 35);
            this.bsearch.TabIndex = 6;
            this.bsearch.Text = "Search";
            this.bsearch.UseVisualStyleBackColor = false;
            this.bsearch.Click += new System.EventHandler(this.bsearch_Click);
            // 
            // blevel
            // 
            this.blevel.BackColor = System.Drawing.Color.Pink;
            this.blevel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.blevel.Location = new System.Drawing.Point(586, 13);
            this.blevel.Name = "blevel";
            this.blevel.Size = new System.Drawing.Size(124, 35);
            this.blevel.TabIndex = 5;
            this.blevel.Text = "Level";
            this.blevel.UseVisualStyleBackColor = false;
            this.blevel.Click += new System.EventHandler(this.blevel_Click);
            // 
            // bsort
            // 
            this.bsort.BackColor = System.Drawing.Color.Pink;
            this.bsort.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bsort.Location = new System.Drawing.Point(331, 13);
            this.bsort.Name = "bsort";
            this.bsort.Size = new System.Drawing.Size(124, 35);
            this.bsort.TabIndex = 4;
            this.bsort.Text = "Sort";
            this.bsort.UseVisualStyleBackColor = false;
            this.bsort.Click += new System.EventHandler(this.bsort_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ArbForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1890, 360);
            this.Controls.Add(this.grouppanel);
            this.Controls.Add(this.singlepanel);
            this.Controls.Add(this.arbpanel);
            this.Name = "ArbForm";
            this.Text = "ArbForm";
            this.singlepanel.ResumeLayout(false);
            this.singlepanel.PerformLayout();
            this.grouppanel.ResumeLayout(false);
            this.grouppanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel arbpanel;
        private System.Windows.Forms.Panel singlepanel;
        private System.Windows.Forms.Panel grouppanel;
        private System.Windows.Forms.Button bdel;
        private System.Windows.Forms.Button baddAuto;
        private System.Windows.Forms.Button baddSt;
        private System.Windows.Forms.Button baddDr;
        private System.Windows.Forms.Button bsave;
        private System.Windows.Forms.Button bload;
        private System.Windows.Forms.Button bsearch;
        private System.Windows.Forms.Button blevel;
        private System.Windows.Forms.Button bsort;
        private System.Windows.Forms.TextBox tbaddAuto;
        private System.Windows.Forms.TextBox tbaddSt;
        private System.Windows.Forms.TextBox tbaddDr;
        private System.Windows.Forms.TextBox tbsearch;
        private System.Windows.Forms.TextBox tbchange;
        private System.Windows.Forms.Button bchange;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;


    }
}