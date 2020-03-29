namespace Probability
{
    partial class Pan_Check
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
            this.button_removeCheck = new System.Windows.Forms.Button();
            this.button_showCheck = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_removeCheck);
            this.panel1.Controls.Add(this.button_showCheck);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(142, 21);
            this.panel1.TabIndex = 7;
            // 
            // button_removeCheck
            // 
            this.button_removeCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_removeCheck.ForeColor = System.Drawing.Color.DarkRed;
            this.button_removeCheck.Location = new System.Drawing.Point(124, -1);
            this.button_removeCheck.Name = "button_removeCheck";
            this.button_removeCheck.Size = new System.Drawing.Size(17, 21);
            this.button_removeCheck.TabIndex = 2;
            this.button_removeCheck.Text = "X";
            this.button_removeCheck.UseVisualStyleBackColor = true;
            this.button_removeCheck.Click += new System.EventHandler(this.button_removeCheck_Click);
            // 
            // button_showCheck
            // 
            this.button_showCheck.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.button_showCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_showCheck.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_showCheck.Location = new System.Drawing.Point(-1, -1);
            this.button_showCheck.Name = "button_showCheck";
            this.button_showCheck.Size = new System.Drawing.Size(119, 21);
            this.button_showCheck.TabIndex = 4;
            this.button_showCheck.Text = "CheckType1";
            this.button_showCheck.UseVisualStyleBackColor = false;
            this.button_showCheck.Click += new System.EventHandler(this.button_showCheck_Click);
            // 
            // Pan_Check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel1);
            this.Name = "Pan_Check";
            this.Size = new System.Drawing.Size(144, 21);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_removeCheck;
        private System.Windows.Forms.Button button_showCheck;
    }
}
