namespace ImageEffectsApplier
{
    partial class MainWindow
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.effectsComboBox = new System.Windows.Forms.ComboBox();
            this.openFileButton = new System.Windows.Forms.Button();
            this.resultLabel = new System.Windows.Forms.Label();
            this.effectLabel = new System.Windows.Forms.Label();
            this.gradientOption1 = new System.Windows.Forms.RadioButton();
            this.gradientOption3 = new System.Windows.Forms.RadioButton();
            this.gradientOption2 = new System.Windows.Forms.RadioButton();
            this.effectOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.gradientGroupBoxSettings = new System.Windows.Forms.GroupBox();
            this.contrastGroupBoxSettings = new System.Windows.Forms.GroupBox();
            this.contrastTrackBar = new System.Windows.Forms.TrackBar();
            this.contrastOption2 = new System.Windows.Forms.RadioButton();
            this.contrastOption1 = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.effectOptionsGroupBox.SuspendLayout();
            this.gradientGroupBoxSettings.SuspendLayout();
            this.contrastGroupBoxSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pictureBox.Location = new System.Drawing.Point(12, 35);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(534, 520);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // effectsComboBox
            // 
            this.effectsComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.effectsComboBox.FormattingEnabled = true;
            this.effectsComboBox.Items.AddRange(new object[] {
            "Градиент",
            "Контраст"});
            this.effectsComboBox.Location = new System.Drawing.Point(564, 35);
            this.effectsComboBox.Name = "effectsComboBox";
            this.effectsComboBox.Size = new System.Drawing.Size(185, 23);
            this.effectsComboBox.TabIndex = 1;
            this.effectsComboBox.TabStop = false;
            this.effectsComboBox.SelectedIndexChanged += new System.EventHandler(this.effectsComboBox_SelectedIndexChanged);
            // 
            // openFileButton
            // 
            this.openFileButton.Location = new System.Drawing.Point(564, 520);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(185, 35);
            this.openFileButton.TabIndex = 3;
            this.openFileButton.TabStop = false;
            this.openFileButton.Text = "Open file";
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(12, 17);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(60, 15);
            this.resultLabel.TabIndex = 4;
            this.resultLabel.Text = "Результат";
            // 
            // effectLabel
            // 
            this.effectLabel.AutoSize = true;
            this.effectLabel.Location = new System.Drawing.Point(564, 17);
            this.effectLabel.Name = "effectLabel";
            this.effectLabel.Size = new System.Drawing.Size(49, 15);
            this.effectLabel.TabIndex = 5;
            this.effectLabel.Text = "Эффект";
            // 
            // gradientOption1
            // 
            this.gradientOption1.AutoSize = true;
            this.gradientOption1.Location = new System.Drawing.Point(6, 22);
            this.gradientOption1.Name = "gradientOption1";
            this.gradientOption1.Size = new System.Drawing.Size(66, 19);
            this.gradientOption1.TabIndex = 7;
            this.gradientOption1.TabStop = true;
            this.gradientOption1.Text = "Собель";
            this.gradientOption1.UseVisualStyleBackColor = true;
            this.gradientOption1.CheckedChanged += new System.EventHandler(this.gradientOption1_CheckedChanged);
            // 
            // gradientOption3
            // 
            this.gradientOption3.AutoSize = true;
            this.gradientOption3.Location = new System.Drawing.Point(6, 72);
            this.gradientOption3.Name = "gradientOption3";
            this.gradientOption3.Size = new System.Drawing.Size(68, 19);
            this.gradientOption3.TabIndex = 8;
            this.gradientOption3.TabStop = true;
            this.gradientOption3.Text = "Прюитт";
            this.gradientOption3.UseVisualStyleBackColor = true;
            this.gradientOption3.CheckedChanged += new System.EventHandler(this.gradientOption3_CheckedChanged);
            // 
            // gradientOption2
            // 
            this.gradientOption2.AutoSize = true;
            this.gradientOption2.Location = new System.Drawing.Point(6, 47);
            this.gradientOption2.Name = "gradientOption2";
            this.gradientOption2.Size = new System.Drawing.Size(57, 19);
            this.gradientOption2.TabIndex = 9;
            this.gradientOption2.TabStop = true;
            this.gradientOption2.Text = "Щарр";
            this.gradientOption2.UseVisualStyleBackColor = true;
            this.gradientOption2.CheckedChanged += new System.EventHandler(this.gradientOption2_CheckedChanged);
            // 
            // effectOptionsGroupBox
            // 
            this.effectOptionsGroupBox.Controls.Add(this.gradientGroupBoxSettings);
            this.effectOptionsGroupBox.Controls.Add(this.contrastGroupBoxSettings);
            this.effectOptionsGroupBox.Location = new System.Drawing.Point(564, 64);
            this.effectOptionsGroupBox.Name = "effectOptionsGroupBox";
            this.effectOptionsGroupBox.Size = new System.Drawing.Size(185, 450);
            this.effectOptionsGroupBox.TabIndex = 11;
            this.effectOptionsGroupBox.TabStop = false;
            this.effectOptionsGroupBox.Text = "Настройки обработки";
            // 
            // gradientGroupBoxSettings
            // 
            this.gradientGroupBoxSettings.Controls.Add(this.gradientOption3);
            this.gradientGroupBoxSettings.Controls.Add(this.gradientOption2);
            this.gradientGroupBoxSettings.Controls.Add(this.gradientOption1);
            this.gradientGroupBoxSettings.Location = new System.Drawing.Point(6, 22);
            this.gradientGroupBoxSettings.Name = "gradientGroupBoxSettings";
            this.gradientGroupBoxSettings.Size = new System.Drawing.Size(173, 101);
            this.gradientGroupBoxSettings.TabIndex = 10;
            this.gradientGroupBoxSettings.TabStop = false;
            this.gradientGroupBoxSettings.Text = "Оператор для свертки";
            // 
            // contrastGroupBoxSettings
            // 
            this.contrastGroupBoxSettings.Controls.Add(this.contrastTrackBar);
            this.contrastGroupBoxSettings.Controls.Add(this.contrastOption2);
            this.contrastGroupBoxSettings.Controls.Add(this.contrastOption1);
            this.contrastGroupBoxSettings.Location = new System.Drawing.Point(6, 22);
            this.contrastGroupBoxSettings.Name = "contrastGroupBoxSettings";
            this.contrastGroupBoxSettings.Size = new System.Drawing.Size(173, 126);
            this.contrastGroupBoxSettings.TabIndex = 11;
            this.contrastGroupBoxSettings.TabStop = false;
            this.contrastGroupBoxSettings.Text = "Контраст";
            this.contrastGroupBoxSettings.Visible = false;
            // 
            // contrastTrackBar
            // 
            this.contrastTrackBar.Location = new System.Drawing.Point(6, 72);
            this.contrastTrackBar.Maximum = 50;
            this.contrastTrackBar.Minimum = -50;
            this.contrastTrackBar.Name = "contrastTrackBar";
            this.contrastTrackBar.Size = new System.Drawing.Size(161, 45);
            this.contrastTrackBar.TabIndex = 9;
            this.contrastTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.contrastTrackBar.Scroll += new System.EventHandler(this.contrastTrackBar_Scroll);
            // 
            // contrastOption2
            // 
            this.contrastOption2.AutoSize = true;
            this.contrastOption2.Location = new System.Drawing.Point(6, 47);
            this.contrastOption2.Name = "contrastOption2";
            this.contrastOption2.Size = new System.Drawing.Size(76, 19);
            this.contrastOption2.TabIndex = 8;
            this.contrastOption2.Text = "GrayScale";
            this.contrastOption2.UseVisualStyleBackColor = true;
            this.contrastOption2.CheckedChanged += new System.EventHandler(this.contrastOption2_CheckedChanged);
            // 
            // contrastOption1
            // 
            this.contrastOption1.AutoSize = true;
            this.contrastOption1.Checked = true;
            this.contrastOption1.Location = new System.Drawing.Point(6, 22);
            this.contrastOption1.Name = "contrastOption1";
            this.contrastOption1.Size = new System.Drawing.Size(54, 19);
            this.contrastOption1.TabIndex = 7;
            this.contrastOption1.TabStop = true;
            this.contrastOption1.Text = "Color";
            this.contrastOption1.UseVisualStyleBackColor = true;
            this.contrastOption1.CheckedChanged += new System.EventHandler(this.contrastOption1_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 567);
            this.Controls.Add(this.effectOptionsGroupBox);
            this.Controls.Add(this.effectLabel);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.openFileButton);
            this.Controls.Add(this.effectsComboBox);
            this.Controls.Add(this.pictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainWindow";
            this.Text = "Image Effects Applier";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.effectOptionsGroupBox.ResumeLayout(false);
            this.gradientGroupBoxSettings.ResumeLayout(false);
            this.gradientGroupBoxSettings.PerformLayout();
            this.contrastGroupBoxSettings.ResumeLayout(false);
            this.contrastGroupBoxSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contrastTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private PictureBox pictureBox;
        private ComboBox effectsComboBox;
        private Button openFileButton;
        private Label resultLabel;
        private Label effectLabel;
        private RadioButton gradientOption1;
        private RadioButton gradientOption3;
        private RadioButton gradientOption2;
        private GroupBox effectOptionsGroupBox;
        private GroupBox gradientGroupBoxSettings;
        private GroupBox contrastGroupBoxSettings;
        private RadioButton contrastOption2;
        private RadioButton contrastOption1;
        private TrackBar contrastTrackBar;
    }
}