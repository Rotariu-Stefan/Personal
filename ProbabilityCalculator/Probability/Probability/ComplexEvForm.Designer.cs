namespace WindowsFormsApp1
{
    partial class ComplexEvForm
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
            this.button_execute = new System.Windows.Forms.Button();
            this.textBox_output = new System.Windows.Forms.TextBox();
            this.groupBox_thisComplexEv = new System.Windows.Forms.GroupBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.checkBox_defTries = new System.Windows.Forms.CheckBox();
            this.textBox_tries = new System.Windows.Forms.TextBox();
            this.label_tries = new System.Windows.Forms.Label();
            this.button_closeForm = new System.Windows.Forms.Button();
            this.pan_complex = new System.Windows.Forms.FlowLayoutPanel();
            this.button_addComplexEv = new System.Windows.Forms.Button();
            this.pan_check = new System.Windows.Forms.FlowLayoutPanel();
            this.button_addCheck = new System.Windows.Forms.Button();
            this.button_rename = new System.Windows.Forms.Button();
            this.pan_simple = new System.Windows.Forms.FlowLayoutPanel();
            this.button_addSimpleEv = new System.Windows.Forms.Button();
            this.groupBox_thisComplexEv.SuspendLayout();
            this.pan_complex.SuspendLayout();
            this.pan_check.SuspendLayout();
            this.pan_simple.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_execute
            // 
            this.button_execute.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button_execute.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_execute.ForeColor = System.Drawing.Color.DarkRed;
            this.button_execute.Location = new System.Drawing.Point(382, 456);
            this.button_execute.Name = "button_execute";
            this.button_execute.Size = new System.Drawing.Size(203, 37);
            this.button_execute.TabIndex = 0;
            this.button_execute.Text = "Execute";
            this.button_execute.UseVisualStyleBackColor = false;
            this.button_execute.Click += new System.EventHandler(this.button_execute_Click);
            // 
            // textBox_output
            // 
            this.textBox_output.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox_output.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_output.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_output.Location = new System.Drawing.Point(12, 511);
            this.textBox_output.Multiline = true;
            this.textBox_output.Name = "textBox_output";
            this.textBox_output.ReadOnly = true;
            this.textBox_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_output.Size = new System.Drawing.Size(975, 161);
            this.textBox_output.TabIndex = 1;
            this.textBox_output.Text = "Output Area...";
            // 
            // groupBox_thisComplexEv
            // 
            this.groupBox_thisComplexEv.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox_thisComplexEv.BackColor = System.Drawing.SystemColors.Info;
            this.groupBox_thisComplexEv.Controls.Add(this.textBox_name);
            this.groupBox_thisComplexEv.Controls.Add(this.checkBox_defTries);
            this.groupBox_thisComplexEv.Controls.Add(this.textBox_tries);
            this.groupBox_thisComplexEv.Controls.Add(this.label_tries);
            this.groupBox_thisComplexEv.Controls.Add(this.button_closeForm);
            this.groupBox_thisComplexEv.Controls.Add(this.pan_complex);
            this.groupBox_thisComplexEv.Controls.Add(this.pan_check);
            this.groupBox_thisComplexEv.Controls.Add(this.button_execute);
            this.groupBox_thisComplexEv.Controls.Add(this.button_rename);
            this.groupBox_thisComplexEv.Controls.Add(this.pan_simple);
            this.groupBox_thisComplexEv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox_thisComplexEv.Location = new System.Drawing.Point(12, 12);
            this.groupBox_thisComplexEv.Name = "groupBox_thisComplexEv";
            this.groupBox_thisComplexEv.Size = new System.Drawing.Size(975, 500);
            this.groupBox_thisComplexEv.TabIndex = 3;
            this.groupBox_thisComplexEv.TabStop = false;
            this.groupBox_thisComplexEv.Text = "ComplexEvRunner";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(6, 19);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(125, 20);
            this.textBox_name.TabIndex = 29;
            this.textBox_name.Text = "ComplexName";
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_name_TextChanged);
            // 
            // checkBox_defTries
            // 
            this.checkBox_defTries.AutoSize = true;
            this.checkBox_defTries.Checked = true;
            this.checkBox_defTries.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_defTries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_defTries.Location = new System.Drawing.Point(241, 466);
            this.checkBox_defTries.Name = "checkBox_defTries";
            this.checkBox_defTries.Size = new System.Drawing.Size(79, 21);
            this.checkBox_defTries.TabIndex = 12;
            this.checkBox_defTries.Text = "Default";
            this.checkBox_defTries.UseVisualStyleBackColor = true;
            this.checkBox_defTries.CheckedChanged += new System.EventHandler(this.checkBox_defTries_CheckedChanged);
            // 
            // textBox_tries
            // 
            this.textBox_tries.Enabled = false;
            this.textBox_tries.Location = new System.Drawing.Point(146, 466);
            this.textBox_tries.Name = "textBox_tries";
            this.textBox_tries.Size = new System.Drawing.Size(79, 20);
            this.textBox_tries.TabIndex = 11;
            this.textBox_tries.Text = "1000000";
            this.textBox_tries.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_tries_KeyPress);
            // 
            // label_tries
            // 
            this.label_tries.AutoSize = true;
            this.label_tries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tries.Location = new System.Drawing.Point(10, 467);
            this.label_tries.Name = "label_tries";
            this.label_tries.Size = new System.Drawing.Size(130, 17);
            this.label_tries.TabIndex = 10;
            this.label_tries.Text = "Number of Tries:";
            // 
            // button_closeForm
            // 
            this.button_closeForm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button_closeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_closeForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_closeForm.Location = new System.Drawing.Point(823, 456);
            this.button_closeForm.Name = "button_closeForm";
            this.button_closeForm.Size = new System.Drawing.Size(146, 37);
            this.button_closeForm.TabIndex = 9;
            this.button_closeForm.Text = "Close";
            this.button_closeForm.UseVisualStyleBackColor = false;
            this.button_closeForm.Click += new System.EventHandler(this.button_closeForm_Click);
            // 
            // pan_complex
            // 
            this.pan_complex.AutoScroll = true;
            this.pan_complex.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pan_complex.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pan_complex.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_complex.Controls.Add(this.button_addComplexEv);
            this.pan_complex.Location = new System.Drawing.Point(6, 236);
            this.pan_complex.Name = "pan_complex";
            this.pan_complex.Size = new System.Drawing.Size(963, 214);
            this.pan_complex.TabIndex = 8;
            // 
            // button_addComplexEv
            // 
            this.button_addComplexEv.BackColor = System.Drawing.SystemColors.Info;
            this.button_addComplexEv.Location = new System.Drawing.Point(3, 3);
            this.button_addComplexEv.Name = "button_addComplexEv";
            this.button_addComplexEv.Size = new System.Drawing.Size(63, 66);
            this.button_addComplexEv.TabIndex = 5;
            this.button_addComplexEv.Text = "+complex";
            this.button_addComplexEv.UseVisualStyleBackColor = false;
            this.button_addComplexEv.Click += new System.EventHandler(this.button_addComplexEv_Click);
            // 
            // pan_check
            // 
            this.pan_check.AutoScroll = true;
            this.pan_check.BackColor = System.Drawing.SystemColors.Control;
            this.pan_check.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_check.Controls.Add(this.button_addCheck);
            this.pan_check.Location = new System.Drawing.Point(200, 18);
            this.pan_check.Name = "pan_check";
            this.pan_check.Size = new System.Drawing.Size(769, 30);
            this.pan_check.TabIndex = 7;
            // 
            // button_addCheck
            // 
            this.button_addCheck.BackColor = System.Drawing.Color.LavenderBlush;
            this.button_addCheck.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addCheck.Location = new System.Drawing.Point(3, 3);
            this.button_addCheck.Name = "button_addCheck";
            this.button_addCheck.Size = new System.Drawing.Size(98, 21);
            this.button_addCheck.TabIndex = 5;
            this.button_addCheck.Text = "+check";
            this.button_addCheck.UseVisualStyleBackColor = false;
            this.button_addCheck.Click += new System.EventHandler(this.button_addCheck_Click);
            // 
            // button_rename
            // 
            this.button_rename.Enabled = false;
            this.button_rename.Location = new System.Drawing.Point(137, 18);
            this.button_rename.Name = "button_rename";
            this.button_rename.Size = new System.Drawing.Size(57, 23);
            this.button_rename.TabIndex = 6;
            this.button_rename.Text = "Rename";
            this.button_rename.UseVisualStyleBackColor = true;
            this.button_rename.Click += new System.EventHandler(this.button_rename_Click);
            // 
            // pan_simple
            // 
            this.pan_simple.AutoScroll = true;
            this.pan_simple.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pan_simple.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pan_simple.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_simple.Controls.Add(this.button_addSimpleEv);
            this.pan_simple.Location = new System.Drawing.Point(6, 54);
            this.pan_simple.Name = "pan_simple";
            this.pan_simple.Size = new System.Drawing.Size(963, 176);
            this.pan_simple.TabIndex = 4;
            // 
            // button_addSimpleEv
            // 
            this.button_addSimpleEv.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.button_addSimpleEv.Location = new System.Drawing.Point(3, 3);
            this.button_addSimpleEv.Name = "button_addSimpleEv";
            this.button_addSimpleEv.Size = new System.Drawing.Size(50, 48);
            this.button_addSimpleEv.TabIndex = 2;
            this.button_addSimpleEv.Text = "+simple";
            this.button_addSimpleEv.UseVisualStyleBackColor = false;
            this.button_addSimpleEv.Click += new System.EventHandler(this.button_addSimpleEv_Click);
            // 
            // ComplexEvForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(999, 685);
            this.Controls.Add(this.groupBox_thisComplexEv);
            this.Controls.Add(this.textBox_output);
            this.Name = "ComplexEvForm";
            this.Text = "Form1";
            this.groupBox_thisComplexEv.ResumeLayout(false);
            this.groupBox_thisComplexEv.PerformLayout();
            this.pan_complex.ResumeLayout(false);
            this.pan_check.ResumeLayout(false);
            this.pan_simple.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_execute;
        private System.Windows.Forms.TextBox textBox_output;
        private System.Windows.Forms.GroupBox groupBox_thisComplexEv;
        private System.Windows.Forms.FlowLayoutPanel pan_simple;
        private System.Windows.Forms.FlowLayoutPanel pan_check;
        private System.Windows.Forms.Button button_rename;
        private System.Windows.Forms.Button button_addSimpleEv;
        private System.Windows.Forms.FlowLayoutPanel pan_complex;
        private System.Windows.Forms.Button button_addComplexEv;
        private System.Windows.Forms.Button button_closeForm;
        private System.Windows.Forms.Button button_addCheck;
        private System.Windows.Forms.CheckBox checkBox_defTries;
        private System.Windows.Forms.TextBox textBox_tries;
        private System.Windows.Forms.Label label_tries;
        private System.Windows.Forms.TextBox textBox_name;
    }
}

