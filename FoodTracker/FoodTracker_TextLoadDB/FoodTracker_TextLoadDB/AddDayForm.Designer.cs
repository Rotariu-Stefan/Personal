namespace FoodTracker_TextLoadDB
{
    partial class AddDayForm
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
            this.button_addMeal = new System.Windows.Forms.Button();
            this.button_addFood = new System.Windows.Forms.Button();
            this.label_title = new System.Windows.Forms.Label();
            this.label_noteScore = new System.Windows.Forms.Label();
            this.label_noteText = new System.Windows.Forms.Label();
            this.button_setDayNote = new System.Windows.Forms.Button();
            this.textBox_noteText = new System.Windows.Forms.TextBox();
            this.output = new System.Windows.Forms.RichTextBox();
            this.textBox_noteMealText = new System.Windows.Forms.TextBox();
            this.label_mealNoteText = new System.Windows.Forms.Label();
            this.label_mealNoteScore = new System.Windows.Forms.Label();
            this.comboBox_meals = new System.Windows.Forms.ComboBox();
            this.label_fat = new System.Windows.Forms.Label();
            this.label_carbs = new System.Windows.Forms.Label();
            this.label_protein = new System.Windows.Forms.Label();
            this.textBox_foodName = new System.Windows.Forms.TextBox();
            this.label_foodName = new System.Windows.Forms.Label();
            this.textBox_brand = new System.Windows.Forms.TextBox();
            this.label_foodBrand = new System.Windows.Forms.Label();
            this.label_amount = new System.Windows.Forms.Label();
            this.comboBox_measure = new System.Windows.Forms.ComboBox();
            this.button_commit = new System.Windows.Forms.Button();
            this.label_measure = new System.Windows.Forms.Label();
            this.textBox_pattern = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label_to = new System.Windows.Forms.Label();
            this.radio_list = new System.Windows.Forms.RadioButton();
            this.radio_pattern = new System.Windows.Forms.RadioButton();
            this.radio_Values = new System.Windows.Forms.RadioButton();
            this.label_list = new System.Windows.Forms.Label();
            this.listBox_foodItems = new System.Windows.Forms.ListBox();
            this.label_search = new System.Windows.Forms.Label();
            this.textBox_searchFood = new System.Windows.Forms.TextBox();
            this.textBox_activ = new System.Windows.Forms.TextBox();
            this.button_setActiv = new System.Windows.Forms.Button();
            this.button_search = new System.Windows.Forms.Button();
            this.button_WTF = new System.Windows.Forms.Button();
            this.button_setMealNote = new System.Windows.Forms.Button();
            this.label_subtitle = new System.Windows.Forms.Label();
            this.button_setMealPortion = new System.Windows.Forms.Button();
            this.label_portion = new System.Windows.Forms.Label();
            this.button_undo = new System.Windows.Forms.Button();
            this.button_cancel = new System.Windows.Forms.Button();
            this.textBox_portion = new FoodTracker_TextLoadDB.tbpaste();
            this.textBox_noteMealScore = new FoodTracker_TextLoadDB.tbpaste();
            this.textBox_noteScore = new FoodTracker_TextLoadDB.tbpaste();
            this.textBox_amount = new FoodTracker_TextLoadDB.tbpaste();
            this.textBox_protein = new FoodTracker_TextLoadDB.tbpaste();
            this.textBox_carbs = new FoodTracker_TextLoadDB.tbpaste();
            this.textBox_fat = new FoodTracker_TextLoadDB.tbpaste();
            this.SuspendLayout();
            // 
            // button_addMeal
            // 
            this.button_addMeal.Location = new System.Drawing.Point(12, 137);
            this.button_addMeal.Name = "button_addMeal";
            this.button_addMeal.Size = new System.Drawing.Size(75, 23);
            this.button_addMeal.TabIndex = 3;
            this.button_addMeal.Text = "Add Meal";
            this.button_addMeal.UseVisualStyleBackColor = true;
            this.button_addMeal.Click += new System.EventHandler(this.button_addMeal_Click);
            // 
            // button_addFood
            // 
            this.button_addFood.Enabled = false;
            this.button_addFood.Location = new System.Drawing.Point(12, 208);
            this.button_addFood.Name = "button_addFood";
            this.button_addFood.Size = new System.Drawing.Size(75, 23);
            this.button_addFood.TabIndex = 10;
            this.button_addFood.Text = "Add Food";
            this.button_addFood.UseVisualStyleBackColor = true;
            this.button_addFood.Click += new System.EventHandler(this.button_addFood_Click);
            // 
            // label_title
            // 
            this.label_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_title.Location = new System.Drawing.Point(12, 9);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(186, 26);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "Day: xx/xx/xxxx";
            // 
            // label_noteScore
            // 
            this.label_noteScore.AutoSize = true;
            this.label_noteScore.Location = new System.Drawing.Point(33, 90);
            this.label_noteScore.Name = "label_noteScore";
            this.label_noteScore.Size = new System.Drawing.Size(38, 13);
            this.label_noteScore.TabIndex = 24;
            this.label_noteScore.Text = "Score:";
            // 
            // label_noteText
            // 
            this.label_noteText.AutoSize = true;
            this.label_noteText.Location = new System.Drawing.Point(133, 90);
            this.label_noteText.Name = "label_noteText";
            this.label_noteText.Size = new System.Drawing.Size(31, 13);
            this.label_noteText.TabIndex = 25;
            this.label_noteText.Text = "Text:";
            // 
            // button_setDayNote
            // 
            this.button_setDayNote.Location = new System.Drawing.Point(476, 85);
            this.button_setDayNote.Name = "button_setDayNote";
            this.button_setDayNote.Size = new System.Drawing.Size(75, 23);
            this.button_setDayNote.TabIndex = 2;
            this.button_setDayNote.Text = "Set D Note";
            this.button_setDayNote.UseVisualStyleBackColor = true;
            this.button_setDayNote.Click += new System.EventHandler(this.button_addNote_Click);
            // 
            // textBox_noteText
            // 
            this.textBox_noteText.Location = new System.Drawing.Point(170, 87);
            this.textBox_noteText.Name = "textBox_noteText";
            this.textBox_noteText.Size = new System.Drawing.Size(300, 20);
            this.textBox_noteText.TabIndex = 1;
            // 
            // output
            // 
            this.output.Location = new System.Drawing.Point(12, 405);
            this.output.Name = "output";
            this.output.ReadOnly = true;
            this.output.Size = new System.Drawing.Size(540, 399);
            this.output.TabIndex = 43;
            this.output.Text = "";
            // 
            // textBox_noteMealText
            // 
            this.textBox_noteMealText.Location = new System.Drawing.Point(170, 165);
            this.textBox_noteMealText.Name = "textBox_noteMealText";
            this.textBox_noteMealText.Size = new System.Drawing.Size(300, 20);
            this.textBox_noteMealText.TabIndex = 5;
            // 
            // label_mealNoteText
            // 
            this.label_mealNoteText.AutoSize = true;
            this.label_mealNoteText.Location = new System.Drawing.Point(133, 168);
            this.label_mealNoteText.Name = "label_mealNoteText";
            this.label_mealNoteText.Size = new System.Drawing.Size(31, 13);
            this.label_mealNoteText.TabIndex = 27;
            this.label_mealNoteText.Text = "Text:";
            // 
            // label_mealNoteScore
            // 
            this.label_mealNoteScore.AutoSize = true;
            this.label_mealNoteScore.Location = new System.Drawing.Point(33, 168);
            this.label_mealNoteScore.Name = "label_mealNoteScore";
            this.label_mealNoteScore.Size = new System.Drawing.Size(38, 13);
            this.label_mealNoteScore.TabIndex = 26;
            this.label_mealNoteScore.Text = "Score:";
            // 
            // comboBox_meals
            // 
            this.comboBox_meals.FormattingEnabled = true;
            this.comboBox_meals.Location = new System.Drawing.Point(234, 208);
            this.comboBox_meals.Name = "comboBox_meals";
            this.comboBox_meals.Size = new System.Drawing.Size(81, 21);
            this.comboBox_meals.TabIndex = 7;
            this.comboBox_meals.SelectedValueChanged += new System.EventHandler(this.comboBox_meals_SelectedValueChanged);
            // 
            // label_fat
            // 
            this.label_fat.AutoSize = true;
            this.label_fat.Location = new System.Drawing.Point(302, 370);
            this.label_fat.Name = "label_fat";
            this.label_fat.Size = new System.Drawing.Size(25, 13);
            this.label_fat.TabIndex = 40;
            this.label_fat.Text = "Fat:";
            // 
            // label_carbs
            // 
            this.label_carbs.AutoSize = true;
            this.label_carbs.Location = new System.Drawing.Point(369, 370);
            this.label_carbs.Name = "label_carbs";
            this.label_carbs.Size = new System.Drawing.Size(37, 13);
            this.label_carbs.TabIndex = 41;
            this.label_carbs.Text = "Carbs:";
            // 
            // label_protein
            // 
            this.label_protein.AutoSize = true;
            this.label_protein.Location = new System.Drawing.Point(437, 370);
            this.label_protein.Name = "label_protein";
            this.label_protein.Size = new System.Drawing.Size(43, 13);
            this.label_protein.TabIndex = 42;
            this.label_protein.Text = "Protein:";
            // 
            // textBox_foodName
            // 
            this.textBox_foodName.Location = new System.Drawing.Point(100, 333);
            this.textBox_foodName.Name = "textBox_foodName";
            this.textBox_foodName.ReadOnly = true;
            this.textBox_foodName.Size = new System.Drawing.Size(161, 20);
            this.textBox_foodName.TabIndex = 12;
            this.textBox_foodName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_foodName_KeyPress);
            // 
            // label_foodName
            // 
            this.label_foodName.AutoSize = true;
            this.label_foodName.Location = new System.Drawing.Point(56, 336);
            this.label_foodName.Name = "label_foodName";
            this.label_foodName.Size = new System.Drawing.Size(38, 13);
            this.label_foodName.TabIndex = 37;
            this.label_foodName.Text = "Name:";
            // 
            // textBox_brand
            // 
            this.textBox_brand.Location = new System.Drawing.Point(100, 363);
            this.textBox_brand.Name = "textBox_brand";
            this.textBox_brand.ReadOnly = true;
            this.textBox_brand.Size = new System.Drawing.Size(161, 20);
            this.textBox_brand.TabIndex = 13;
            this.textBox_brand.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_brand_KeyPress);
            // 
            // label_foodBrand
            // 
            this.label_foodBrand.AutoSize = true;
            this.label_foodBrand.Location = new System.Drawing.Point(56, 366);
            this.label_foodBrand.Name = "label_foodBrand";
            this.label_foodBrand.Size = new System.Drawing.Size(38, 13);
            this.label_foodBrand.TabIndex = 38;
            this.label_foodBrand.Text = "Brand:";
            // 
            // label_amount
            // 
            this.label_amount.AutoSize = true;
            this.label_amount.Location = new System.Drawing.Point(97, 213);
            this.label_amount.Name = "label_amount";
            this.label_amount.Size = new System.Drawing.Size(46, 13);
            this.label_amount.TabIndex = 28;
            this.label_amount.Text = "Amount:";
            // 
            // comboBox_measure
            // 
            this.comboBox_measure.Enabled = false;
            this.comboBox_measure.FormattingEnabled = true;
            this.comboBox_measure.Items.AddRange(new object[] {
            "Grams",
            "ML",
            "Quant"});
            this.comboBox_measure.Location = new System.Drawing.Point(414, 332);
            this.comboBox_measure.Name = "comboBox_measure";
            this.comboBox_measure.Size = new System.Drawing.Size(97, 21);
            this.comboBox_measure.TabIndex = 17;
            // 
            // button_commit
            // 
            this.button_commit.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_commit.Location = new System.Drawing.Point(12, 810);
            this.button_commit.Name = "button_commit";
            this.button_commit.Size = new System.Drawing.Size(93, 23);
            this.button_commit.TabIndex = 20;
            this.button_commit.Text = "Commit";
            this.button_commit.UseVisualStyleBackColor = true;
            this.button_commit.Click += new System.EventHandler(this.button_commit_Click);
            // 
            // label_measure
            // 
            this.label_measure.AutoSize = true;
            this.label_measure.Location = new System.Drawing.Point(362, 335);
            this.label_measure.Name = "label_measure";
            this.label_measure.Size = new System.Drawing.Size(51, 13);
            this.label_measure.TabIndex = 39;
            this.label_measure.Text = "Measure:";
            // 
            // textBox_pattern
            // 
            this.textBox_pattern.Location = new System.Drawing.Point(100, 307);
            this.textBox_pattern.Name = "textBox_pattern";
            this.textBox_pattern.ReadOnly = true;
            this.textBox_pattern.Size = new System.Drawing.Size(411, 20);
            this.textBox_pattern.TabIndex = 11;
            this.textBox_pattern.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_pattern_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 310);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Pattern:";
            // 
            // label_to
            // 
            this.label_to.AutoSize = true;
            this.label_to.Location = new System.Drawing.Point(205, 211);
            this.label_to.Name = "label_to";
            this.label_to.Size = new System.Drawing.Size(23, 13);
            this.label_to.TabIndex = 29;
            this.label_to.Text = "To:";
            // 
            // radio_list
            // 
            this.radio_list.AutoSize = true;
            this.radio_list.Checked = true;
            this.radio_list.Location = new System.Drawing.Point(325, 209);
            this.radio_list.Name = "radio_list";
            this.radio_list.Size = new System.Drawing.Size(41, 17);
            this.radio_list.TabIndex = 9;
            this.radio_list.TabStop = true;
            this.radio_list.Text = "List";
            this.radio_list.UseVisualStyleBackColor = true;
            this.radio_list.CheckedChanged += new System.EventHandler(this.radio_list_CheckedChanged);
            // 
            // radio_pattern
            // 
            this.radio_pattern.AutoSize = true;
            this.radio_pattern.Location = new System.Drawing.Point(372, 209);
            this.radio_pattern.Name = "radio_pattern";
            this.radio_pattern.Size = new System.Drawing.Size(59, 17);
            this.radio_pattern.TabIndex = 10;
            this.radio_pattern.Text = "Pattern";
            this.radio_pattern.UseVisualStyleBackColor = true;
            this.radio_pattern.CheckedChanged += new System.EventHandler(this.radio_pattern_CheckedChanged);
            // 
            // radio_Values
            // 
            this.radio_Values.AutoSize = true;
            this.radio_Values.Location = new System.Drawing.Point(437, 209);
            this.radio_Values.Name = "radio_Values";
            this.radio_Values.Size = new System.Drawing.Size(57, 17);
            this.radio_Values.TabIndex = 11;
            this.radio_Values.Text = "Values";
            this.radio_Values.UseVisualStyleBackColor = true;
            this.radio_Values.CheckedChanged += new System.EventHandler(this.radio_Values_CheckedChanged);
            // 
            // label_list
            // 
            this.label_list.AutoSize = true;
            this.label_list.Location = new System.Drawing.Point(234, 278);
            this.label_list.Name = "label_list";
            this.label_list.Size = new System.Drawing.Size(53, 13);
            this.label_list.TabIndex = 35;
            this.label_list.Text = "Food List:";
            // 
            // listBox_foodItems
            // 
            this.listBox_foodItems.FormattingEnabled = true;
            this.listBox_foodItems.Location = new System.Drawing.Point(293, 232);
            this.listBox_foodItems.Name = "listBox_foodItems";
            this.listBox_foodItems.Size = new System.Drawing.Size(218, 69);
            this.listBox_foodItems.TabIndex = 22;
            this.listBox_foodItems.SelectedValueChanged += new System.EventHandler(this.listBox_foodItems_SelectedValueChanged);
            // 
            // label_search
            // 
            this.label_search.AutoSize = true;
            this.label_search.Location = new System.Drawing.Point(50, 249);
            this.label_search.Name = "label_search";
            this.label_search.Size = new System.Drawing.Size(44, 13);
            this.label_search.TabIndex = 33;
            this.label_search.Text = "Search:";
            // 
            // textBox_searchFood
            // 
            this.textBox_searchFood.Location = new System.Drawing.Point(100, 246);
            this.textBox_searchFood.Name = "textBox_searchFood";
            this.textBox_searchFood.ReadOnly = true;
            this.textBox_searchFood.Size = new System.Drawing.Size(184, 20);
            this.textBox_searchFood.TabIndex = 8;
            this.textBox_searchFood.TextChanged += new System.EventHandler(this.textBox_searchFood_TextChanged);
            this.textBox_searchFood.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_searchFood_KeyPress);
            this.textBox_searchFood.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.textBox_searchFood_PreviewKeyDown);
            // 
            // textBox_activ
            // 
            this.textBox_activ.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox_activ.Location = new System.Drawing.Point(414, 14);
            this.textBox_activ.Name = "textBox_activ";
            this.textBox_activ.Size = new System.Drawing.Size(138, 21);
            this.textBox_activ.TabIndex = 18;
            // 
            // button_setActiv
            // 
            this.button_setActiv.Location = new System.Drawing.Point(333, 12);
            this.button_setActiv.Name = "button_setActiv";
            this.button_setActiv.Size = new System.Drawing.Size(75, 23);
            this.button_setActiv.TabIndex = 19;
            this.button_setActiv.Text = "Set Activity";
            this.button_setActiv.UseVisualStyleBackColor = true;
            this.button_setActiv.Click += new System.EventHandler(this.button_setActiv_Click);
            // 
            // button_search
            // 
            this.button_search.Location = new System.Drawing.Point(100, 273);
            this.button_search.Name = "button_search";
            this.button_search.Size = new System.Drawing.Size(98, 23);
            this.button_search.TabIndex = 34;
            this.button_search.Text = "Search Food List";
            this.button_search.UseVisualStyleBackColor = true;
            this.button_search.Click += new System.EventHandler(this.button_search_Click);
            // 
            // button_WTF
            // 
            this.button_WTF.Location = new System.Drawing.Point(252, 811);
            this.button_WTF.Name = "button_WTF";
            this.button_WTF.Size = new System.Drawing.Size(75, 23);
            this.button_WTF.TabIndex = 44;
            this.button_WTF.Text = "WTF";
            this.button_WTF.UseVisualStyleBackColor = true;
            this.button_WTF.Click += new System.EventHandler(this.button_WTF_Click);
            // 
            // button_setMealNote
            // 
            this.button_setMealNote.Enabled = false;
            this.button_setMealNote.Location = new System.Drawing.Point(476, 163);
            this.button_setMealNote.Name = "button_setMealNote";
            this.button_setMealNote.Size = new System.Drawing.Size(75, 23);
            this.button_setMealNote.TabIndex = 6;
            this.button_setMealNote.Text = "Set M Note";
            this.button_setMealNote.UseVisualStyleBackColor = true;
            this.button_setMealNote.Click += new System.EventHandler(this.button_setMealNote_Click);
            // 
            // label_subtitle
            // 
            this.label_subtitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_subtitle.Location = new System.Drawing.Point(12, 35);
            this.label_subtitle.Name = "label_subtitle";
            this.label_subtitle.Size = new System.Drawing.Size(540, 47);
            this.label_subtitle.TabIndex = 1;
            this.label_subtitle.Text = "xx(note text)";
            // 
            // button_setMealPortion
            // 
            this.button_setMealPortion.Enabled = false;
            this.button_setMealPortion.Location = new System.Drawing.Point(187, 136);
            this.button_setMealPortion.Name = "button_setMealPortion";
            this.button_setMealPortion.Size = new System.Drawing.Size(75, 23);
            this.button_setMealPortion.TabIndex = 45;
            this.button_setMealPortion.Text = "Set Portion";
            this.button_setMealPortion.UseVisualStyleBackColor = true;
            this.button_setMealPortion.Click += new System.EventHandler(this.button_setMealPortion_Click);
            // 
            // label_portion
            // 
            this.label_portion.AutoSize = true;
            this.label_portion.Location = new System.Drawing.Point(97, 142);
            this.label_portion.Name = "label_portion";
            this.label_portion.Size = new System.Drawing.Size(43, 13);
            this.label_portion.TabIndex = 47;
            this.label_portion.Text = "Portion:";
            // 
            // button_undo
            // 
            this.button_undo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_undo.Location = new System.Drawing.Point(503, 405);
            this.button_undo.Name = "button_undo";
            this.button_undo.Size = new System.Drawing.Size(55, 23);
            this.button_undo.TabIndex = 48;
            this.button_undo.Text = "Undo";
            this.button_undo.UseVisualStyleBackColor = true;
            this.button_undo.Click += new System.EventHandler(this.button_undo_Click);
            // 
            // button_cancel
            // 
            this.button_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_cancel.Location = new System.Drawing.Point(458, 811);
            this.button_cancel.Name = "button_cancel";
            this.button_cancel.Size = new System.Drawing.Size(93, 23);
            this.button_cancel.TabIndex = 49;
            this.button_cancel.Text = "Cancel";
            this.button_cancel.UseVisualStyleBackColor = true;
            this.button_cancel.Click += new System.EventHandler(this.button_cancel_Click);
            // 
            // textBox_portion
            // 
            this.textBox_portion.dot = false;
            this.textBox_portion.Location = new System.Drawing.Point(141, 139);
            this.textBox_portion.Name = "textBox_portion";
            this.textBox_portion.pasted = false;
            this.textBox_portion.Size = new System.Drawing.Size(40, 20);
            this.textBox_portion.TabIndex = 46;
            this.textBox_portion.Text = "1";
            this.textBox_portion.TextChanged += new System.EventHandler(this.textBox_portion_TextChanged);
            this.textBox_portion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_portion_KeyPress);
            // 
            // textBox_noteMealScore
            // 
            this.textBox_noteMealScore.dot = false;
            this.textBox_noteMealScore.Location = new System.Drawing.Point(77, 165);
            this.textBox_noteMealScore.Name = "textBox_noteMealScore";
            this.textBox_noteMealScore.pasted = false;
            this.textBox_noteMealScore.Size = new System.Drawing.Size(40, 20);
            this.textBox_noteMealScore.TabIndex = 4;
            this.textBox_noteMealScore.TextChanged += new System.EventHandler(this.textBox_noteMealScore_TextChanged);
            this.textBox_noteMealScore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_noteMealScore_KeyPress);
            // 
            // textBox_noteScore
            // 
            this.textBox_noteScore.dot = false;
            this.textBox_noteScore.Location = new System.Drawing.Point(77, 87);
            this.textBox_noteScore.Name = "textBox_noteScore";
            this.textBox_noteScore.pasted = false;
            this.textBox_noteScore.Size = new System.Drawing.Size(40, 20);
            this.textBox_noteScore.TabIndex = 0;
            this.textBox_noteScore.TextChanged += new System.EventHandler(this.textBox_noteScore_TextChanged);
            this.textBox_noteScore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_noteScore_KeyPress);
            // 
            // textBox_amount
            // 
            this.textBox_amount.dot = false;
            this.textBox_amount.Location = new System.Drawing.Point(141, 208);
            this.textBox_amount.Name = "textBox_amount";
            this.textBox_amount.pasted = false;
            this.textBox_amount.ReadOnly = true;
            this.textBox_amount.Size = new System.Drawing.Size(40, 20);
            this.textBox_amount.TabIndex = 9;
            this.textBox_amount.TextChanged += new System.EventHandler(this.textBox_amount_TextChanged);
            this.textBox_amount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_amount_KeyPress);
            // 
            // textBox_protein
            // 
            this.textBox_protein.dot = false;
            this.textBox_protein.Location = new System.Drawing.Point(483, 367);
            this.textBox_protein.Name = "textBox_protein";
            this.textBox_protein.pasted = false;
            this.textBox_protein.ReadOnly = true;
            this.textBox_protein.Size = new System.Drawing.Size(29, 20);
            this.textBox_protein.TabIndex = 16;
            this.textBox_protein.TextChanged += new System.EventHandler(this.textBox_protein_TextChanged);
            this.textBox_protein.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_protein_KeyPress);
            // 
            // textBox_carbs
            // 
            this.textBox_carbs.dot = false;
            this.textBox_carbs.Location = new System.Drawing.Point(409, 367);
            this.textBox_carbs.Name = "textBox_carbs";
            this.textBox_carbs.pasted = false;
            this.textBox_carbs.ReadOnly = true;
            this.textBox_carbs.Size = new System.Drawing.Size(29, 20);
            this.textBox_carbs.TabIndex = 15;
            this.textBox_carbs.TextChanged += new System.EventHandler(this.textBox_carbs_TextChanged);
            this.textBox_carbs.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_carbs_KeyPress);
            // 
            // textBox_fat
            // 
            this.textBox_fat.dot = false;
            this.textBox_fat.Location = new System.Drawing.Point(333, 367);
            this.textBox_fat.Name = "textBox_fat";
            this.textBox_fat.pasted = false;
            this.textBox_fat.ReadOnly = true;
            this.textBox_fat.Size = new System.Drawing.Size(29, 20);
            this.textBox_fat.TabIndex = 14;
            this.textBox_fat.TextChanged += new System.EventHandler(this.textBox_fat_TextChanged);
            this.textBox_fat.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_fat_KeyPress);
            // 
            // AddDayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 845);
            this.Controls.Add(this.button_cancel);
            this.Controls.Add(this.button_undo);
            this.Controls.Add(this.textBox_portion);
            this.Controls.Add(this.label_portion);
            this.Controls.Add(this.button_setMealPortion);
            this.Controls.Add(this.label_subtitle);
            this.Controls.Add(this.textBox_noteMealScore);
            this.Controls.Add(this.textBox_noteScore);
            this.Controls.Add(this.textBox_amount);
            this.Controls.Add(this.textBox_protein);
            this.Controls.Add(this.textBox_carbs);
            this.Controls.Add(this.textBox_fat);
            this.Controls.Add(this.button_setMealNote);
            this.Controls.Add(this.button_WTF);
            this.Controls.Add(this.button_search);
            this.Controls.Add(this.button_setActiv);
            this.Controls.Add(this.textBox_activ);
            this.Controls.Add(this.textBox_searchFood);
            this.Controls.Add(this.label_search);
            this.Controls.Add(this.listBox_foodItems);
            this.Controls.Add(this.label_list);
            this.Controls.Add(this.radio_Values);
            this.Controls.Add(this.radio_pattern);
            this.Controls.Add(this.radio_list);
            this.Controls.Add(this.label_to);
            this.Controls.Add(this.textBox_pattern);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label_measure);
            this.Controls.Add(this.button_commit);
            this.Controls.Add(this.comboBox_measure);
            this.Controls.Add(this.label_amount);
            this.Controls.Add(this.textBox_brand);
            this.Controls.Add(this.label_foodBrand);
            this.Controls.Add(this.textBox_foodName);
            this.Controls.Add(this.label_foodName);
            this.Controls.Add(this.label_protein);
            this.Controls.Add(this.label_carbs);
            this.Controls.Add(this.label_fat);
            this.Controls.Add(this.comboBox_meals);
            this.Controls.Add(this.textBox_noteMealText);
            this.Controls.Add(this.label_mealNoteText);
            this.Controls.Add(this.label_mealNoteScore);
            this.Controls.Add(this.output);
            this.Controls.Add(this.textBox_noteText);
            this.Controls.Add(this.button_setDayNote);
            this.Controls.Add(this.label_noteText);
            this.Controls.Add(this.label_noteScore);
            this.Controls.Add(this.label_title);
            this.Controls.Add(this.button_addFood);
            this.Controls.Add(this.button_addMeal);
            this.Name = "AddDayForm";
            this.Text = "AddFood";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_addMeal;
        private System.Windows.Forms.Button button_addFood;
        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label_noteScore;
        private System.Windows.Forms.Label label_noteText;
        private System.Windows.Forms.Button button_setDayNote;
        private System.Windows.Forms.TextBox textBox_noteText;
        private System.Windows.Forms.RichTextBox output;
        private System.Windows.Forms.TextBox textBox_noteMealText;
        private System.Windows.Forms.Label label_mealNoteText;
        private System.Windows.Forms.Label label_mealNoteScore;
        private System.Windows.Forms.ComboBox comboBox_meals;
        private System.Windows.Forms.Label label_fat;
        private System.Windows.Forms.Label label_carbs;
        private System.Windows.Forms.Label label_protein;
        private System.Windows.Forms.TextBox textBox_foodName;
        private System.Windows.Forms.Label label_foodName;
        private System.Windows.Forms.TextBox textBox_brand;
        private System.Windows.Forms.Label label_foodBrand;
        private System.Windows.Forms.Label label_amount;
        private System.Windows.Forms.ComboBox comboBox_measure;
        private System.Windows.Forms.Button button_commit;
        private System.Windows.Forms.Label label_measure;
        private System.Windows.Forms.TextBox textBox_pattern;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_to;
        private System.Windows.Forms.RadioButton radio_list;
        private System.Windows.Forms.RadioButton radio_pattern;
        private System.Windows.Forms.RadioButton radio_Values;
        private System.Windows.Forms.Label label_list;
        private System.Windows.Forms.ListBox listBox_foodItems;
        private System.Windows.Forms.Label label_search;
        private System.Windows.Forms.TextBox textBox_searchFood;
        private System.Windows.Forms.TextBox textBox_activ;
        private System.Windows.Forms.Button button_setActiv;
        private System.Windows.Forms.Button button_search;
        private System.Windows.Forms.Button button_WTF;
        private System.Windows.Forms.Button button_setMealNote;
        private tbpaste textBox_fat;
        private tbpaste textBox_carbs;
        private tbpaste textBox_protein;
        private tbpaste textBox_amount;
        private tbpaste textBox_noteScore;
        private tbpaste textBox_noteMealScore;
        private System.Windows.Forms.Label label_subtitle;
        private System.Windows.Forms.Button button_setMealPortion;
        private tbpaste textBox_portion;
        private System.Windows.Forms.Label label_portion;
        private System.Windows.Forms.Button button_undo;
        private System.Windows.Forms.Button button_cancel;
    }
}