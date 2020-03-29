namespace Probability
{
    partial class Pan_ComplexEv
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
            this.panel_complexEv = new System.Windows.Forms.Panel();
            this.button_removeComplexEv = new System.Windows.Forms.Button();
            this.button_showComplexEv = new System.Windows.Forms.Button();
            this.numeric_repeat = new System.Windows.Forms.NumericUpDown();
            this.label_repeat = new System.Windows.Forms.Label();
            this.panel_complexEv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_repeat)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_complexEv
            // 
            this.panel_complexEv.BackColor = System.Drawing.SystemColors.Info;
            this.panel_complexEv.Controls.Add(this.numeric_repeat);
            this.panel_complexEv.Controls.Add(this.label_repeat);
            this.panel_complexEv.Controls.Add(this.button_removeComplexEv);
            this.panel_complexEv.Controls.Add(this.button_showComplexEv);
            this.panel_complexEv.Location = new System.Drawing.Point(0, 3);
            this.panel_complexEv.Name = "panel_complexEv";
            this.panel_complexEv.Size = new System.Drawing.Size(228, 87);
            this.panel_complexEv.TabIndex = 5;
            // 
            // button_removeComplexEv
            // 
            this.button_removeComplexEv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_removeComplexEv.ForeColor = System.Drawing.Color.DarkRed;
            this.button_removeComplexEv.Location = new System.Drawing.Point(211, 0);
            this.button_removeComplexEv.Name = "button_removeComplexEv";
            this.button_removeComplexEv.Size = new System.Drawing.Size(17, 23);
            this.button_removeComplexEv.TabIndex = 2;
            this.button_removeComplexEv.Text = "X";
            this.button_removeComplexEv.UseVisualStyleBackColor = true;
            this.button_removeComplexEv.Click += new System.EventHandler(this.button_removeComplexEv_Click);
            // 
            // button_showComplexEv
            // 
            this.button_showComplexEv.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_showComplexEv.Location = new System.Drawing.Point(0, 0);
            this.button_showComplexEv.Name = "button_showComplexEv";
            this.button_showComplexEv.Size = new System.Drawing.Size(205, 62);
            this.button_showComplexEv.TabIndex = 3;
            this.button_showComplexEv.Text = "ComplexEv1";
            this.button_showComplexEv.UseVisualStyleBackColor = false;
            this.button_showComplexEv.Click += new System.EventHandler(this.button_showComplexEv_Click);
            // 
            // numeric_repeat
            // 
            this.numeric_repeat.BackColor = System.Drawing.SystemColors.Info;
            this.numeric_repeat.Location = new System.Drawing.Point(179, 63);
            this.numeric_repeat.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numeric_repeat.Name = "numeric_repeat";
            this.numeric_repeat.Size = new System.Drawing.Size(46, 20);
            this.numeric_repeat.TabIndex = 5;
            this.numeric_repeat.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numeric_repeat.ValueChanged += new System.EventHandler(this.numeric_repeat_ValueChanged);
            // 
            // label_repeat
            // 
            this.label_repeat.AutoSize = true;
            this.label_repeat.Location = new System.Drawing.Point(128, 65);
            this.label_repeat.Name = "label_repeat";
            this.label_repeat.Size = new System.Drawing.Size(45, 13);
            this.label_repeat.TabIndex = 4;
            this.label_repeat.Text = "Repeat:";
            // 
            // Pan_ComplexEv
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel_complexEv);
            this.Name = "Pan_ComplexEv";
            this.Size = new System.Drawing.Size(229, 93);
            this.panel_complexEv.ResumeLayout(false);
            this.panel_complexEv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numeric_repeat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_complexEv;
        private System.Windows.Forms.Button button_removeComplexEv;
        private System.Windows.Forms.Button button_showComplexEv;
        private System.Windows.Forms.NumericUpDown numeric_repeat;
        private System.Windows.Forms.Label label_repeat;
    }
}
