namespace FoodTracker_TextLoadDB
{
    partial class MainForm
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
            this.button_findFile = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.textBox_filepath = new System.Windows.Forms.TextBox();
            this.openFileDialog_dbtextfile = new System.Windows.Forms.OpenFileDialog();
            this.button_intoDB = new System.Windows.Forms.Button();
            this.button_fromDB = new System.Windows.Forms.Button();
            this.output = new System.Windows.Forms.RichTextBox();
            this.button_clear = new System.Windows.Forms.Button();
            this.button_seePeriod = new System.Windows.Forms.Button();
            this.calendar = new System.Windows.Forms.MonthCalendar();
            this.button_seeFood = new System.Windows.Forms.Button();
            this.button_searchFood = new System.Windows.Forms.Button();
            this.textBox_searchFood = new System.Windows.Forms.TextBox();
            this.button_processFile = new System.Windows.Forms.Button();
            this.button_writeFile = new System.Windows.Forms.Button();
            this.button_addDay = new System.Windows.Forms.Button();
            this.button_WTF = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_findFile
            // 
            this.button_findFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_findFile.Location = new System.Drawing.Point(107, 36);
            this.button_findFile.Name = "button_findFile";
            this.button_findFile.Size = new System.Drawing.Size(110, 30);
            this.button_findFile.TabIndex = 0;
            this.button_findFile.Text = "Find File";
            this.button_findFile.UseVisualStyleBackColor = true;
            this.button_findFile.Click += new System.EventHandler(this.button_findFile_Click);
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.ForeColor = System.Drawing.Color.DarkRed;
            this.label_title.Location = new System.Drawing.Point(12, 9);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(716, 24);
            this.label_title.TabIndex = 1;
            this.label_title.Text = "SvFoodTracker Database - Load From/Backup To a Text File + Testing Data";
            // 
            // textBox_filepath
            // 
            this.textBox_filepath.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_filepath.Location = new System.Drawing.Point(223, 43);
            this.textBox_filepath.Name = "textBox_filepath";
            this.textBox_filepath.Size = new System.Drawing.Size(399, 20);
            this.textBox_filepath.TabIndex = 2;
            this.textBox_filepath.Text = "..\\..\\NUTcalc.text";
            // 
            // openFileDialog_dbtextfile
            // 
            this.openFileDialog_dbtextfile.DefaultExt = "rtf";
            this.openFileDialog_dbtextfile.FileName = "..\\..\\NUTcalc.text";
            this.openFileDialog_dbtextfile.InitialDirectory = "..\\..";
            // 
            // button_intoDB
            // 
            this.button_intoDB.Enabled = false;
            this.button_intoDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_intoDB.ForeColor = System.Drawing.Color.Maroon;
            this.button_intoDB.Location = new System.Drawing.Point(316, 72);
            this.button_intoDB.Name = "button_intoDB";
            this.button_intoDB.Size = new System.Drawing.Size(141, 30);
            this.button_intoDB.TabIndex = 3;
            this.button_intoDB.Text = "LOAD INTO DB";
            this.button_intoDB.UseVisualStyleBackColor = true;
            this.button_intoDB.Click += new System.EventHandler(this.button_LoadIntoDB_Click);
            // 
            // button_fromDB
            // 
            this.button_fromDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_fromDB.ForeColor = System.Drawing.Color.Maroon;
            this.button_fromDB.Location = new System.Drawing.Point(463, 72);
            this.button_fromDB.Name = "button_fromDB";
            this.button_fromDB.Size = new System.Drawing.Size(159, 30);
            this.button_fromDB.TabIndex = 4;
            this.button_fromDB.Text = "GET FROM DB";
            this.button_fromDB.UseVisualStyleBackColor = true;
            this.button_fromDB.Click += new System.EventHandler(this.button_GetFromDB_Click);
            // 
            // output
            // 
            this.output.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.output.Location = new System.Drawing.Point(16, 117);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(712, 600);
            this.output.TabIndex = 5;
            this.output.Text = "...output\n";
            // 
            // button_clear
            // 
            this.button_clear.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_clear.Location = new System.Drawing.Point(653, 98);
            this.button_clear.Name = "button_clear";
            this.button_clear.Size = new System.Drawing.Size(75, 23);
            this.button_clear.TabIndex = 7;
            this.button_clear.Text = "Clear";
            this.button_clear.UseVisualStyleBackColor = true;
            this.button_clear.Click += new System.EventHandler(this.button_clear_Click);
            // 
            // button_seePeriod
            // 
            this.button_seePeriod.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_seePeriod.Location = new System.Drawing.Point(16, 723);
            this.button_seePeriod.Name = "button_seePeriod";
            this.button_seePeriod.Size = new System.Drawing.Size(136, 49);
            this.button_seePeriod.TabIndex = 8;
            this.button_seePeriod.Text = "See Entries for Selected Period";
            this.button_seePeriod.UseVisualStyleBackColor = true;
            this.button_seePeriod.Click += new System.EventHandler(this.button_seeMealsDay_Click);
            // 
            // calendar
            // 
            this.calendar.FirstDayOfWeek = System.Windows.Forms.Day.Monday;
            this.calendar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calendar.Location = new System.Drawing.Point(164, 723);
            this.calendar.MaxSelectionCount = 1000;
            this.calendar.Name = "calendar";
            this.calendar.TabIndex = 9;
            this.calendar.TitleBackColor = System.Drawing.SystemColors.Highlight;
            this.calendar.TrailingForeColor = System.Drawing.SystemColors.Highlight;
            // 
            // button_seeFood
            // 
            this.button_seeFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_seeFood.Location = new System.Drawing.Point(403, 778);
            this.button_seeFood.Name = "button_seeFood";
            this.button_seeFood.Size = new System.Drawing.Size(136, 49);
            this.button_seeFood.TabIndex = 12;
            this.button_seeFood.Text = "See All Food Items";
            this.button_seeFood.UseVisualStyleBackColor = true;
            this.button_seeFood.Click += new System.EventHandler(this.button_seeAllFoodItems_Click);
            // 
            // button_searchFood
            // 
            this.button_searchFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_searchFood.Location = new System.Drawing.Point(403, 723);
            this.button_searchFood.Name = "button_searchFood";
            this.button_searchFood.Size = new System.Drawing.Size(136, 49);
            this.button_searchFood.TabIndex = 13;
            this.button_searchFood.Text = "Search For Food Item";
            this.button_searchFood.UseVisualStyleBackColor = true;
            this.button_searchFood.Click += new System.EventHandler(this.button_searchFood_Click);
            // 
            // textBox_searchFood
            // 
            this.textBox_searchFood.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_searchFood.ForeColor = System.Drawing.Color.DarkGreen;
            this.textBox_searchFood.Location = new System.Drawing.Point(545, 739);
            this.textBox_searchFood.Name = "textBox_searchFood";
            this.textBox_searchFood.Size = new System.Drawing.Size(183, 21);
            this.textBox_searchFood.TabIndex = 14;
            this.textBox_searchFood.Text = "varza";
            // 
            // button_processFile
            // 
            this.button_processFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_processFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_processFile.Location = new System.Drawing.Point(16, 72);
            this.button_processFile.Name = "button_processFile";
            this.button_processFile.Size = new System.Drawing.Size(145, 30);
            this.button_processFile.TabIndex = 15;
            this.button_processFile.Text = "PROCESS FILE";
            this.button_processFile.UseVisualStyleBackColor = true;
            this.button_processFile.Click += new System.EventHandler(this.button_processFile_Click);
            // 
            // button_writeFile
            // 
            this.button_writeFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_writeFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button_writeFile.Location = new System.Drawing.Point(167, 72);
            this.button_writeFile.Name = "button_writeFile";
            this.button_writeFile.Size = new System.Drawing.Size(145, 30);
            this.button_writeFile.TabIndex = 16;
            this.button_writeFile.Text = "WRITE TO FILE";
            this.button_writeFile.UseVisualStyleBackColor = true;
            this.button_writeFile.Click += new System.EventHandler(this.button_writeFile_Click);
            // 
            // button_addDay
            // 
            this.button_addDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_addDay.Location = new System.Drawing.Point(16, 778);
            this.button_addDay.Name = "button_addDay";
            this.button_addDay.Size = new System.Drawing.Size(136, 49);
            this.button_addDay.TabIndex = 17;
            this.button_addDay.Text = "Add Day Entry";
            this.button_addDay.UseVisualStyleBackColor = true;
            this.button_addDay.Click += new System.EventHandler(this.button_addDay_Click);
            // 
            // button_WTF
            // 
            this.button_WTF.Location = new System.Drawing.Point(660, 862);
            this.button_WTF.Name = "button_WTF";
            this.button_WTF.Size = new System.Drawing.Size(75, 23);
            this.button_WTF.TabIndex = 45;
            this.button_WTF.Text = "WTF";
            this.button_WTF.UseVisualStyleBackColor = true;
            this.button_WTF.Click += new System.EventHandler(this.button_WTF_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(747, 892);
            this.Controls.Add(this.button_WTF);
            this.Controls.Add(this.button_addDay);
            this.Controls.Add(this.button_writeFile);
            this.Controls.Add(this.button_processFile);
            this.Controls.Add(this.textBox_searchFood);
            this.Controls.Add(this.button_searchFood);
            this.Controls.Add(this.button_seeFood);
            this.Controls.Add(this.calendar);
            this.Controls.Add(this.button_seePeriod);
            this.Controls.Add(this.button_clear);
            this.Controls.Add(this.output);
            this.Controls.Add(this.button_fromDB);
            this.Controls.Add(this.button_intoDB);
            this.Controls.Add(this.textBox_filepath);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.button_findFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SvFoodTracker_TextLoadDB";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_findFile;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.TextBox textBox_filepath;
        private System.Windows.Forms.OpenFileDialog openFileDialog_dbtextfile;
        private System.Windows.Forms.Button button_intoDB;
        private System.Windows.Forms.Button button_fromDB;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.Button button_clear;
        private System.Windows.Forms.Button button_seePeriod;
        private System.Windows.Forms.MonthCalendar calendar;
        private System.Windows.Forms.Button button_seeFood;
        private System.Windows.Forms.Button button_searchFood;
        private System.Windows.Forms.TextBox textBox_searchFood;
        private System.Windows.Forms.Button button_processFile;
        private System.Windows.Forms.Button button_writeFile;
        private System.Windows.Forms.Button button_addDay;
        private System.Windows.Forms.Button button_WTF;
    }
}

