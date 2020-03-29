namespace Probability
{
    partial class CheckForm
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
            this.groupBox_thisCheck = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.label_checkType = new System.Windows.Forms.Label();
            this.comboBox_checkType = new System.Windows.Forms.ComboBox();
            this.textBox_param = new System.Windows.Forms.TextBox();
            this.button_closeForm = new System.Windows.Forms.Button();
            this.label_param = new System.Windows.Forms.Label();
            this.label_checkHelp = new System.Windows.Forms.Label();
            this.label_paramHelp = new System.Windows.Forms.Label();
            this.groupBox_thisCheck.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_thisCheck
            // 
            this.groupBox_thisCheck.BackColor = System.Drawing.Color.LavenderBlush;
            this.groupBox_thisCheck.Controls.Add(this.panel1);
            this.groupBox_thisCheck.Controls.Add(this.button_closeForm);
            this.groupBox_thisCheck.Location = new System.Drawing.Point(12, 12);
            this.groupBox_thisCheck.Name = "groupBox_thisCheck";
            this.groupBox_thisCheck.Size = new System.Drawing.Size(546, 197);
            this.groupBox_thisCheck.TabIndex = 1;
            this.groupBox_thisCheck.TabStop = false;
            this.groupBox_thisCheck.Text = "AND(1)";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label_paramHelp);
            this.panel1.Controls.Add(this.label_checkHelp);
            this.panel1.Controls.Add(this.label_param);
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Controls.Add(this.label_checkType);
            this.panel1.Controls.Add(this.comboBox_checkType);
            this.panel1.Controls.Add(this.textBox_param);
            this.panel1.Location = new System.Drawing.Point(6, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(534, 129);
            this.panel1.TabIndex = 27;
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button_cancel.Enabled = false;
            this.button_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_cancel.Location = new System.Drawing.Point(317, 94);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(99, 26);
            this.button_cancel.TabIndex = 29;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = false;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // button_save
            // 
            this.button_save.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button_save.Enabled = false;
            this.button_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_save.ForeColor = System.Drawing.Color.DarkRed;
            this.button_save.Location = new System.Drawing.Point(104, 94);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(99, 26);
            this.button_save.TabIndex = 28;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label_checkType
            // 
            this.label_checkType.AutoSize = true;
            this.label_checkType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_checkType.Location = new System.Drawing.Point(3, 18);
            this.label_checkType.Name = "label_checkType";
            this.label_checkType.Size = new System.Drawing.Size(98, 17);
            this.label_checkType.TabIndex = 19;
            this.label_checkType.Text = "Check Type:";
            // 
            // comboBox_checkType
            // 
            this.comboBox_checkType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_checkType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_checkType.FormattingEnabled = true;
            this.comboBox_checkType.Items.AddRange(new object[] {
            "AND",
            "OR",
            "SMIN",
            "FMIN",
            "SMAX",
            "FMAX"});
            this.comboBox_checkType.Location = new System.Drawing.Point(104, 17);
            this.comboBox_checkType.Name = "comboBox_checkType";
            this.comboBox_checkType.Size = new System.Drawing.Size(74, 21);
            this.comboBox_checkType.TabIndex = 18;
            this.comboBox_checkType.SelectedIndexChanged += new System.EventHandler(this.comboBox_checkType_SelectedIndexChanged);
            // 
            // textBox_param
            // 
            this.textBox_param.Location = new System.Drawing.Point(104, 54);
            this.textBox_param.Name = "textBox_param";
            this.textBox_param.Size = new System.Drawing.Size(55, 20);
            this.textBox_param.TabIndex = 22;
            this.textBox_param.Text = "1";
            this.textBox_param.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_param_KeyPress);
            // 
            // button_closeForm
            // 
            this.button_closeForm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button_closeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_closeForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_closeForm.Location = new System.Drawing.Point(394, 154);
            this.button_closeForm.Name = "button_closeForm";
            this.button_closeForm.Size = new System.Drawing.Size(146, 37);
            this.button_closeForm.TabIndex = 17;
            this.button_closeForm.Text = "Close";
            this.button_closeForm.UseVisualStyleBackColor = false;
            this.button_closeForm.Click += new System.EventHandler(this.button_closeForm_Click);
            // 
            // label_param
            // 
            this.label_param.AutoSize = true;
            this.label_param.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_param.Location = new System.Drawing.Point(3, 55);
            this.label_param.Name = "label_param";
            this.label_param.Size = new System.Drawing.Size(88, 17);
            this.label_param.TabIndex = 30;
            this.label_param.Text = "Parameter:";
            // 
            // label_checkHelp
            // 
            this.label_checkHelp.AutoSize = true;
            this.label_checkHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_checkHelp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_checkHelp.Location = new System.Drawing.Point(200, 20);
            this.label_checkHelp.Name = "label_checkHelp";
            this.label_checkHelp.Size = new System.Drawing.Size(324, 13);
            this.label_checkHelp.TabIndex = 31;
            this.label_checkHelp.Text = "(?) Tests if At LEAST X number of events were Success";
            // 
            // label_paramHelp
            // 
            this.label_paramHelp.AutoSize = true;
            this.label_paramHelp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_paramHelp.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label_paramHelp.Location = new System.Drawing.Point(200, 57);
            this.label_paramHelp.Name = "label_paramHelp";
            this.label_paramHelp.Size = new System.Drawing.Size(324, 13);
            this.label_paramHelp.TabIndex = 32;
            this.label_paramHelp.Text = "(?) Tests if At LEAST X number of events were Success";
            // 
            // CheckForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 216);
            this.Controls.Add(this.groupBox_thisCheck);
            this.Name = "CheckForm";
            this.Text = "CheckForm";
            this.groupBox_thisCheck.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_thisCheck;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.Label label_checkType;
        private System.Windows.Forms.ComboBox comboBox_checkType;
        private System.Windows.Forms.TextBox textBox_param;
        private System.Windows.Forms.Button button_closeForm;
        private System.Windows.Forms.Label label_param;
        private System.Windows.Forms.Label label_checkHelp;
        private System.Windows.Forms.Label label_paramHelp;
    }
}