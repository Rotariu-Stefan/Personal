namespace Probability
{
    partial class Pan_SimpleEv
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_removeSimpleEv = new System.Windows.Forms.Button();
            this.button_showSimpleEv = new System.Windows.Forms.Button();
            this.label_repeat = new System.Windows.Forms.Label();
            this.numeric_repeat = new System.Windows.Forms.NumericUpDown();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_repeat)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.panel1.Controls.Add(this.numeric_repeat);
            this.panel1.Controls.Add(this.label_repeat);
            this.panel1.Controls.Add(this.button_removeSimpleEv);
            this.panel1.Controls.Add(this.button_showSimpleEv);
            this.panel1.Location = new System.Drawing.Point(3, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(116, 72);
            this.panel1.TabIndex = 2;
            // 
            // button_removeSimpleEv
            // 
            this.button_removeSimpleEv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_removeSimpleEv.ForeColor = System.Drawing.Color.DarkRed;
            this.button_removeSimpleEv.Location = new System.Drawing.Point(99, -1);
            this.button_removeSimpleEv.Name = "button_removeSimpleEv";
            this.button_removeSimpleEv.Size = new System.Drawing.Size(17, 23);
            this.button_removeSimpleEv.TabIndex = 1;
            this.button_removeSimpleEv.Text = "X";
            this.button_removeSimpleEv.UseVisualStyleBackColor = true;
            this.button_removeSimpleEv.Click += new System.EventHandler(this.button_removeSimpleEv_Click);
            // 
            // button_showSimpleEv
            // 
            this.button_showSimpleEv.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_showSimpleEv.Location = new System.Drawing.Point(0, 0);
            this.button_showSimpleEv.Name = "button_showSimpleEv";
            this.button_showSimpleEv.Size = new System.Drawing.Size(93, 50);
            this.button_showSimpleEv.TabIndex = 0;
            this.button_showSimpleEv.Text = "SimpleEv1";
            this.button_showSimpleEv.UseVisualStyleBackColor = false;
            this.button_showSimpleEv.Click += new System.EventHandler(this.button_showSimpleEv_Click);
            // 
            // label_repeat
            // 
            this.label_repeat.AutoSize = true;
            this.label_repeat.Location = new System.Drawing.Point(16, 53);
            this.label_repeat.Name = "label_repeat";
            this.label_repeat.Size = new System.Drawing.Size(45, 13);
            this.label_repeat.TabIndex = 2;
            this.label_repeat.Text = "Repeat:";
            // 
            // numeric_repeat
            // 
            this.numeric_repeat.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.numeric_repeat.Location = new System.Drawing.Point(67, 51);
            this.numeric_repeat.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_repeat.Name = "numeric_repeat";
            this.numeric_repeat.Size = new System.Drawing.Size(46, 20);
            this.numeric_repeat.TabIndex = 3;
            this.numeric_repeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_repeat.ValueChanged += new System.EventHandler(this.numeric_repeat_ValueChanged);
            // 
            // Pan_SimpleEv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Pan_SimpleEv";
            this.Size = new System.Drawing.Size(122, 76);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_repeat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_removeSimpleEv;
        private System.Windows.Forms.Button button_showSimpleEv;
        private System.Windows.Forms.NumericUpDown numeric_repeat;
        private System.Windows.Forms.Label label_repeat;
    }
}
