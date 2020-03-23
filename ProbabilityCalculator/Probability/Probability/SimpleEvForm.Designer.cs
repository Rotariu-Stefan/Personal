namespace WindowsFormsApp1
{
    partial class SimpleEvForm
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
            this.groupBox_thisSimpleEv = new System.Windows.Forms.GroupBox();
            this.textBox_name = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_cancel = new System.Windows.Forms.Button();
            this.button_save = new System.Windows.Forms.Button();
            this.label_evType = new System.Windows.Forms.Label();
            this.label_percent = new System.Windows.Forms.Label();
            this.comboBox_evType = new System.Windows.Forms.ComboBox();
            this.textBox_chance = new System.Windows.Forms.TextBox();
            this.radio_values = new System.Windows.Forms.RadioButton();
            this.textBox_possible = new System.Windows.Forms.TextBox();
            this.radio_chance = new System.Windows.Forms.RadioButton();
            this.label_division = new System.Windows.Forms.Label();
            this.textBox_favor = new System.Windows.Forms.TextBox();
            this.button_closeForm = new System.Windows.Forms.Button();
            this.button_execute = new System.Windows.Forms.Button();
            this.checkBox_defTries = new System.Windows.Forms.CheckBox();
            this.textBox_tries = new System.Windows.Forms.TextBox();
            this.label_tries = new System.Windows.Forms.Label();
            this.pan_check = new System.Windows.Forms.FlowLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox_not = new System.Windows.Forms.CheckBox();
            this.button_rename = new System.Windows.Forms.Button();
            this.textBox_output = new System.Windows.Forms.TextBox();
            this.groupBox_thisSimpleEv.SuspendLayout();
            this.panel1.SuspendLayout();
            this.pan_check.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox_thisSimpleEv
            // 
            this.groupBox_thisSimpleEv.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.groupBox_thisSimpleEv.Controls.Add(this.textBox_name);
            this.groupBox_thisSimpleEv.Controls.Add(this.panel1);
            this.groupBox_thisSimpleEv.Controls.Add(this.button_closeForm);
            this.groupBox_thisSimpleEv.Controls.Add(this.button_execute);
            this.groupBox_thisSimpleEv.Controls.Add(this.checkBox_defTries);
            this.groupBox_thisSimpleEv.Controls.Add(this.textBox_tries);
            this.groupBox_thisSimpleEv.Controls.Add(this.label_tries);
            this.groupBox_thisSimpleEv.Controls.Add(this.pan_check);
            this.groupBox_thisSimpleEv.Controls.Add(this.button_rename);
            this.groupBox_thisSimpleEv.Location = new System.Drawing.Point(12, 12);
            this.groupBox_thisSimpleEv.Name = "groupBox_thisSimpleEv";
            this.groupBox_thisSimpleEv.Size = new System.Drawing.Size(795, 212);
            this.groupBox_thisSimpleEv.TabIndex = 0;
            this.groupBox_thisSimpleEv.TabStop = false;
            this.groupBox_thisSimpleEv.Text = "SimpleEvRunner";
            // 
            // textBox_name
            // 
            this.textBox_name.Location = new System.Drawing.Point(6, 21);
            this.textBox_name.Name = "textBox_name";
            this.textBox_name.Size = new System.Drawing.Size(125, 20);
            this.textBox_name.TabIndex = 28;
            this.textBox_name.Text = "SimpleName";
            this.textBox_name.TextChanged += new System.EventHandler(this.textBox_name_TextChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.button_cancel);
            this.panel1.Controls.Add(this.button_save);
            this.panel1.Controls.Add(this.label_evType);
            this.panel1.Controls.Add(this.label_percent);
            this.panel1.Controls.Add(this.comboBox_evType);
            this.panel1.Controls.Add(this.textBox_chance);
            this.panel1.Controls.Add(this.radio_values);
            this.panel1.Controls.Add(this.textBox_possible);
            this.panel1.Controls.Add(this.radio_chance);
            this.panel1.Controls.Add(this.label_division);
            this.panel1.Controls.Add(this.textBox_favor);
            this.panel1.Location = new System.Drawing.Point(6, 55);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(783, 108);
            this.panel1.TabIndex = 27;
            // 
            // button_cancel
            // 
            this.button_cancel.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button_cancel.Enabled = false;
            this.button_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_cancel.Location = new System.Drawing.Point(679, 54);
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
            this.button_save.Location = new System.Drawing.Point(349, 54);
            this.button_save.Name = "button_save";
            this.button_save.Size = new System.Drawing.Size(99, 26);
            this.button_save.TabIndex = 28;
            this.button_save.Text = "Save";
            this.button_save.UseVisualStyleBackColor = false;
            this.button_save.Click += new System.EventHandler(this.button_save_Click);
            // 
            // label_evType
            // 
            this.label_evType.AutoSize = true;
            this.label_evType.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_evType.Location = new System.Drawing.Point(3, 18);
            this.label_evType.Name = "label_evType";
            this.label_evType.Size = new System.Drawing.Size(95, 17);
            this.label_evType.TabIndex = 19;
            this.label_evType.Text = "Event Type:";
            // 
            // label_percent
            // 
            this.label_percent.AutoSize = true;
            this.label_percent.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_percent.Location = new System.Drawing.Point(701, 18);
            this.label_percent.Name = "label_percent";
            this.label_percent.Size = new System.Drawing.Size(22, 18);
            this.label_percent.TabIndex = 26;
            this.label_percent.Text = "%";
            // 
            // comboBox_evType
            // 
            this.comboBox_evType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_evType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox_evType.FormattingEnabled = true;
            this.comboBox_evType.Items.AddRange(new object[] {
            "Custom (values)",
            "Custom (chance)",
            "Success",
            "Fail",
            "Half"});
            this.comboBox_evType.Location = new System.Drawing.Point(104, 17);
            this.comboBox_evType.Name = "comboBox_evType";
            this.comboBox_evType.Size = new System.Drawing.Size(239, 21);
            this.comboBox_evType.TabIndex = 18;
            this.comboBox_evType.SelectedIndexChanged += new System.EventHandler(this.comboBox_evType_SelectedIndexChanged);
            // 
            // textBox_chance
            // 
            this.textBox_chance.Location = new System.Drawing.Point(641, 18);
            this.textBox_chance.Name = "textBox_chance";
            this.textBox_chance.ReadOnly = true;
            this.textBox_chance.Size = new System.Drawing.Size(54, 20);
            this.textBox_chance.TabIndex = 25;
            this.textBox_chance.Text = "50";
            this.textBox_chance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_chance_KeyPress);
            // 
            // radio_values
            // 
            this.radio_values.AutoSize = true;
            this.radio_values.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_values.Location = new System.Drawing.Point(349, 18);
            this.radio_values.Name = "radio_values";
            this.radio_values.Size = new System.Drawing.Size(67, 17);
            this.radio_values.TabIndex = 20;
            this.radio_values.Text = "Values:";
            this.radio_values.UseVisualStyleBackColor = true;
            this.radio_values.CheckedChanged += new System.EventHandler(this.radio_values_CheckedChanged);
            // 
            // textBox_possible
            // 
            this.textBox_possible.Location = new System.Drawing.Point(497, 17);
            this.textBox_possible.Name = "textBox_possible";
            this.textBox_possible.ReadOnly = true;
            this.textBox_possible.Size = new System.Drawing.Size(54, 20);
            this.textBox_possible.TabIndex = 24;
            this.textBox_possible.Text = "2";
            this.textBox_possible.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_possible_KeyPress);
            // 
            // radio_chance
            // 
            this.radio_chance.AutoSize = true;
            this.radio_chance.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radio_chance.Location = new System.Drawing.Point(567, 18);
            this.radio_chance.Name = "radio_chance";
            this.radio_chance.Size = new System.Drawing.Size(72, 17);
            this.radio_chance.TabIndex = 21;
            this.radio_chance.Text = "Chance:";
            this.radio_chance.UseVisualStyleBackColor = true;
            this.radio_chance.CheckedChanged += new System.EventHandler(this.radio_chance_CheckedChanged);
            // 
            // label_division
            // 
            this.label_division.AutoSize = true;
            this.label_division.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_division.Location = new System.Drawing.Point(478, 17);
            this.label_division.Name = "label_division";
            this.label_division.Size = new System.Drawing.Size(13, 18);
            this.label_division.TabIndex = 23;
            this.label_division.Text = "/";
            // 
            // textBox_favor
            // 
            this.textBox_favor.Location = new System.Drawing.Point(418, 17);
            this.textBox_favor.Name = "textBox_favor";
            this.textBox_favor.ReadOnly = true;
            this.textBox_favor.Size = new System.Drawing.Size(54, 20);
            this.textBox_favor.TabIndex = 22;
            this.textBox_favor.Text = "1";
            this.textBox_favor.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_favor_KeyPress);
            // 
            // button_closeForm
            // 
            this.button_closeForm.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button_closeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_closeForm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_closeForm.Location = new System.Drawing.Point(643, 169);
            this.button_closeForm.Name = "button_closeForm";
            this.button_closeForm.Size = new System.Drawing.Size(146, 37);
            this.button_closeForm.TabIndex = 17;
            this.button_closeForm.Text = "Close";
            this.button_closeForm.UseVisualStyleBackColor = false;
            this.button_closeForm.Click += new System.EventHandler(this.button_closeForm_Click);
            // 
            // button_execute
            // 
            this.button_execute.BackColor = System.Drawing.SystemColors.HighlightText;
            this.button_execute.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_execute.ForeColor = System.Drawing.Color.DarkRed;
            this.button_execute.Location = new System.Drawing.Point(303, 169);
            this.button_execute.Name = "button_execute";
            this.button_execute.Size = new System.Drawing.Size(203, 37);
            this.button_execute.TabIndex = 16;
            this.button_execute.Text = "Execute";
            this.button_execute.UseVisualStyleBackColor = false;
            this.button_execute.Click += new System.EventHandler(this.button_execute_Click);
            // 
            // checkBox_defTries
            // 
            this.checkBox_defTries.AutoSize = true;
            this.checkBox_defTries.Checked = true;
            this.checkBox_defTries.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_defTries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_defTries.Location = new System.Drawing.Point(218, 179);
            this.checkBox_defTries.Name = "checkBox_defTries";
            this.checkBox_defTries.Size = new System.Drawing.Size(79, 21);
            this.checkBox_defTries.TabIndex = 15;
            this.checkBox_defTries.Text = "Default";
            this.checkBox_defTries.UseVisualStyleBackColor = true;
            this.checkBox_defTries.CheckedChanged += new System.EventHandler(this.checkBox_defTries_CheckedChanged);
            // 
            // textBox_tries
            // 
            this.textBox_tries.Enabled = false;
            this.textBox_tries.Location = new System.Drawing.Point(136, 179);
            this.textBox_tries.Name = "textBox_tries";
            this.textBox_tries.Size = new System.Drawing.Size(79, 20);
            this.textBox_tries.TabIndex = 14;
            this.textBox_tries.Text = "1000000";
            this.textBox_tries.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_tries_KeyPress);
            // 
            // label_tries
            // 
            this.label_tries.AutoSize = true;
            this.label_tries.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tries.Location = new System.Drawing.Point(6, 180);
            this.label_tries.Name = "label_tries";
            this.label_tries.Size = new System.Drawing.Size(130, 17);
            this.label_tries.TabIndex = 13;
            this.label_tries.Text = "Number of Tries:";
            // 
            // pan_check
            // 
            this.pan_check.AutoScroll = true;
            this.pan_check.BackColor = System.Drawing.SystemColors.Control;
            this.pan_check.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pan_check.Controls.Add(this.panel2);
            this.pan_check.Location = new System.Drawing.Point(201, 19);
            this.pan_check.Name = "pan_check";
            this.pan_check.Size = new System.Drawing.Size(588, 30);
            this.pan_check.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.LavenderBlush;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.checkBox_not);
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(158, 21);
            this.panel2.TabIndex = 8;
            // 
            // checkBox_not
            // 
            this.checkBox_not.AutoSize = true;
            this.checkBox_not.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox_not.Location = new System.Drawing.Point(49, 0);
            this.checkBox_not.Name = "checkBox_not";
            this.checkBox_not.Size = new System.Drawing.Size(60, 21);
            this.checkBox_not.TabIndex = 16;
            this.checkBox_not.Text = "NOT";
            this.checkBox_not.UseVisualStyleBackColor = true;
            this.checkBox_not.CheckedChanged += new System.EventHandler(this.checkBox_not_CheckedChanged);
            // 
            // button_rename
            // 
            this.button_rename.Enabled = false;
            this.button_rename.Location = new System.Drawing.Point(137, 19);
            this.button_rename.Name = "button_rename";
            this.button_rename.Size = new System.Drawing.Size(58, 23);
            this.button_rename.TabIndex = 7;
            this.button_rename.Text = "Rename";
            this.button_rename.UseVisualStyleBackColor = true;
            this.button_rename.Click += new System.EventHandler(this.button_rename_Click);
            // 
            // textBox_output
            // 
            this.textBox_output.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.textBox_output.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_output.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.textBox_output.Location = new System.Drawing.Point(12, 220);
            this.textBox_output.Multiline = true;
            this.textBox_output.Name = "textBox_output";
            this.textBox_output.ReadOnly = true;
            this.textBox_output.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_output.Size = new System.Drawing.Size(795, 161);
            this.textBox_output.TabIndex = 2;
            this.textBox_output.Text = "Output Area...";
            // 
            // SimpleEvForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 393);
            this.Controls.Add(this.textBox_output);
            this.Controls.Add(this.groupBox_thisSimpleEv);
            this.Name = "SimpleEvForm";
            this.Text = "SimpleEvForm";
            this.groupBox_thisSimpleEv.ResumeLayout(false);
            this.groupBox_thisSimpleEv.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pan_check.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox_thisSimpleEv;
        private System.Windows.Forms.TextBox textBox_output;
        private System.Windows.Forms.Button button_rename;
        private System.Windows.Forms.FlowLayoutPanel pan_check;
        private System.Windows.Forms.CheckBox checkBox_defTries;
        private System.Windows.Forms.TextBox textBox_tries;
        private System.Windows.Forms.Label label_tries;
        private System.Windows.Forms.Button button_execute;
        private System.Windows.Forms.Button button_closeForm;
        private System.Windows.Forms.Label label_evType;
        private System.Windows.Forms.ComboBox comboBox_evType;
        private System.Windows.Forms.RadioButton radio_chance;
        private System.Windows.Forms.RadioButton radio_values;
        private System.Windows.Forms.TextBox textBox_possible;
        private System.Windows.Forms.Label label_division;
        private System.Windows.Forms.TextBox textBox_favor;
        private System.Windows.Forms.Label label_percent;
        private System.Windows.Forms.TextBox textBox_chance;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button_cancel;
        private System.Windows.Forms.Button button_save;
        private System.Windows.Forms.TextBox textBox_name;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox_not;
    }
}