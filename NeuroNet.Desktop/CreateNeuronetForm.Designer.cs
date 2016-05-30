namespace NeuroNet.Desktop
{
    partial class CreateNeuronetForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.AmountOfOutputNeuronsSelector = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.AmountOfHiddenNeuronsSelector = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HeightSelector = new System.Windows.Forms.NumericUpDown();
            this.WidthSelector = new System.Windows.Forms.NumericUpDown();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.CurrentTrainigSpeedLabel = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TrainingSpeedSelector = new System.Windows.Forms.TrackBar();
            this.BackpropogationTeacherSelector = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.AgesSelector = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.DarkDigitSelector = new System.Windows.Forms.RadioButton();
            this.LightDigitSelector = new System.Windows.Forms.RadioButton();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.ManyPairsPerImageSelector = new System.Windows.Forms.RadioButton();
            this.OnePairPerImageSelector = new System.Windows.Forms.RadioButton();
            this.MaxPairPerImageSelector = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.PathTextBox = new System.Windows.Forms.TextBox();
            this.CahngePathButton = new System.Windows.Forms.Button();
            this.CreateButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmountOfOutputNeuronsSelector)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightSelector)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthSelector)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrainingSpeedSelector)).BeginInit();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AgesSelector)).BeginInit();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPairPerImageSelector)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(357, 224);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Perceptron settings";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.AmountOfOutputNeuronsSelector);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Location = new System.Drawing.Point(7, 161);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(338, 57);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Output layer";
            // 
            // AmountOfOutputNeuronsSelector
            // 
            this.AmountOfOutputNeuronsSelector.Enabled = false;
            this.AmountOfOutputNeuronsSelector.Location = new System.Drawing.Point(162, 22);
            this.AmountOfOutputNeuronsSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AmountOfOutputNeuronsSelector.Name = "AmountOfOutputNeuronsSelector";
            this.AmountOfOutputNeuronsSelector.Size = new System.Drawing.Size(120, 22);
            this.AmountOfOutputNeuronsSelector.TabIndex = 1;
            this.AmountOfOutputNeuronsSelector.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Amount of output neurons:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.AmountOfHiddenNeuronsSelector);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(7, 83);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(344, 71);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Hidden layer";
            // 
            // AmountOfHiddenNeuronsSelector
            // 
            this.AmountOfHiddenNeuronsSelector.Location = new System.Drawing.Point(167, 19);
            this.AmountOfHiddenNeuronsSelector.Name = "AmountOfHiddenNeuronsSelector";
            this.AmountOfHiddenNeuronsSelector.Size = new System.Drawing.Size(171, 22);
            this.AmountOfHiddenNeuronsSelector.TabIndex = 1;
            this.AmountOfHiddenNeuronsSelector.Text = "150";
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.Color.Gray;
            this.label4.Location = new System.Drawing.Point(9, 44);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(329, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "\',\' is delimeter symbol for each layer (e.g.: \"250, 100\")";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Amount of hidden neurons:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.HeightSelector);
            this.groupBox2.Controls.Add(this.WidthSelector);
            this.groupBox2.Location = new System.Drawing.Point(7, 22);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 54);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Input layer (image parameters)";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(210, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Height:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Width:";
            // 
            // HeightSelector
            // 
            this.HeightSelector.Location = new System.Drawing.Point(276, 21);
            this.HeightSelector.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.HeightSelector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.HeightSelector.Name = "HeightSelector";
            this.HeightSelector.Size = new System.Drawing.Size(62, 22);
            this.HeightSelector.TabIndex = 0;
            this.HeightSelector.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // WidthSelector
            // 
            this.WidthSelector.Location = new System.Drawing.Point(67, 21);
            this.WidthSelector.Maximum = new decimal(new int[] {
            64,
            0,
            0,
            0});
            this.WidthSelector.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.WidthSelector.Name = "WidthSelector";
            this.WidthSelector.Size = new System.Drawing.Size(62, 22);
            this.WidthSelector.TabIndex = 0;
            this.WidthSelector.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.CurrentTrainigSpeedLabel);
            this.groupBox5.Controls.Add(this.label8);
            this.groupBox5.Controls.Add(this.TrainingSpeedSelector);
            this.groupBox5.Controls.Add(this.BackpropogationTeacherSelector);
            this.groupBox5.Location = new System.Drawing.Point(13, 244);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(357, 104);
            this.groupBox5.TabIndex = 1;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Teacher";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(319, 53);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 13);
            this.label10.TabIndex = 4;
            this.label10.Text = "1.0";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(220, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(28, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "0.01";
            // 
            // CurrentTrainigSpeedLabel
            // 
            this.CurrentTrainigSpeedLabel.AutoSize = true;
            this.CurrentTrainigSpeedLabel.Location = new System.Drawing.Point(267, 53);
            this.CurrentTrainigSpeedLabel.Name = "CurrentTrainigSpeedLabel";
            this.CurrentTrainigSpeedLabel.Size = new System.Drawing.Size(11, 13);
            this.CurrentTrainigSpeedLabel.TabIndex = 3;
            this.CurrentTrainigSpeedLabel.Text = "-";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(131, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Training speed:";
            // 
            // TrainingSpeedSelector
            // 
            this.TrainingSpeedSelector.LargeChange = 10;
            this.TrainingSpeedSelector.Location = new System.Drawing.Point(223, 21);
            this.TrainingSpeedSelector.Maximum = 100;
            this.TrainingSpeedSelector.Name = "TrainingSpeedSelector";
            this.TrainingSpeedSelector.Size = new System.Drawing.Size(123, 45);
            this.TrainingSpeedSelector.SmallChange = 5;
            this.TrainingSpeedSelector.TabIndex = 1;
            this.TrainingSpeedSelector.TickFrequency = 10;
            this.TrainingSpeedSelector.Value = 10;
            this.TrainingSpeedSelector.Scroll += new System.EventHandler(this.TrainingSpeedSelector_Scroll);
            // 
            // BackpropogationTeacherSelector
            // 
            this.BackpropogationTeacherSelector.AutoSize = true;
            this.BackpropogationTeacherSelector.Checked = true;
            this.BackpropogationTeacherSelector.Enabled = false;
            this.BackpropogationTeacherSelector.Location = new System.Drawing.Point(7, 22);
            this.BackpropogationTeacherSelector.Name = "BackpropogationTeacherSelector";
            this.BackpropogationTeacherSelector.Size = new System.Drawing.Size(118, 17);
            this.BackpropogationTeacherSelector.TabIndex = 0;
            this.BackpropogationTeacherSelector.TabStop = true;
            this.BackpropogationTeacherSelector.Text = "Back-propagation";
            this.BackpropogationTeacherSelector.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.AgesSelector);
            this.groupBox6.Controls.Add(this.label7);
            this.groupBox6.Controls.Add(this.groupBox8);
            this.groupBox6.Controls.Add(this.groupBox7);
            this.groupBox6.Controls.Add(this.MaxPairPerImageSelector);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.PathTextBox);
            this.groupBox6.Controls.Add(this.CahngePathButton);
            this.groupBox6.Location = new System.Drawing.Point(14, 354);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(357, 261);
            this.groupBox6.TabIndex = 2;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Training set";
            // 
            // AgesSelector
            // 
            this.AgesSelector.Location = new System.Drawing.Point(248, 227);
            this.AgesSelector.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.AgesSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.AgesSelector.Name = "AgesSelector";
            this.AgesSelector.Size = new System.Drawing.Size(92, 22);
            this.AgesSelector.TabIndex = 7;
            this.AgesSelector.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(7, 227);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(206, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Ages (number of repeating trainig set):";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.DarkDigitSelector);
            this.groupBox8.Controls.Add(this.LightDigitSelector);
            this.groupBox8.Location = new System.Drawing.Point(7, 171);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(338, 49);
            this.groupBox8.TabIndex = 5;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "Digit properties";
            // 
            // DarkDigitSelector
            // 
            this.DarkDigitSelector.AutoSize = true;
            this.DarkDigitSelector.Checked = true;
            this.DarkDigitSelector.Location = new System.Drawing.Point(64, 22);
            this.DarkDigitSelector.Name = "DarkDigitSelector";
            this.DarkDigitSelector.Size = new System.Drawing.Size(49, 17);
            this.DarkDigitSelector.TabIndex = 0;
            this.DarkDigitSelector.TabStop = true;
            this.DarkDigitSelector.Text = "Dark";
            this.DarkDigitSelector.UseVisualStyleBackColor = true;
            // 
            // LightDigitSelector
            // 
            this.LightDigitSelector.AutoSize = true;
            this.LightDigitSelector.Location = new System.Drawing.Point(7, 22);
            this.LightDigitSelector.Name = "LightDigitSelector";
            this.LightDigitSelector.Size = new System.Drawing.Size(51, 17);
            this.LightDigitSelector.TabIndex = 0;
            this.LightDigitSelector.Text = "Light";
            this.LightDigitSelector.UseVisualStyleBackColor = true;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.ManyPairsPerImageSelector);
            this.groupBox7.Controls.Add(this.OnePairPerImageSelector);
            this.groupBox7.Location = new System.Drawing.Point(7, 94);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(344, 70);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Method";
            // 
            // ManyPairsPerImageSelector
            // 
            this.ManyPairsPerImageSelector.AutoSize = true;
            this.ManyPairsPerImageSelector.Location = new System.Drawing.Point(7, 45);
            this.ManyPairsPerImageSelector.Name = "ManyPairsPerImageSelector";
            this.ManyPairsPerImageSelector.Size = new System.Drawing.Size(204, 17);
            this.ManyPairsPerImageSelector.TabIndex = 0;
            this.ManyPairsPerImageSelector.Text = "Many training pair from one image";
            this.ManyPairsPerImageSelector.UseVisualStyleBackColor = true;
            // 
            // OnePairPerImageSelector
            // 
            this.OnePairPerImageSelector.AutoSize = true;
            this.OnePairPerImageSelector.Checked = true;
            this.OnePairPerImageSelector.Location = new System.Drawing.Point(7, 22);
            this.OnePairPerImageSelector.Name = "OnePairPerImageSelector";
            this.OnePairPerImageSelector.Size = new System.Drawing.Size(198, 17);
            this.OnePairPerImageSelector.TabIndex = 0;
            this.OnePairPerImageSelector.TabStop = true;
            this.OnePairPerImageSelector.Text = "One training pair from one image";
            this.OnePairPerImageSelector.UseVisualStyleBackColor = true;
            // 
            // MaxPairPerImageSelector
            // 
            this.MaxPairPerImageSelector.Location = new System.Drawing.Point(257, 56);
            this.MaxPairPerImageSelector.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.MaxPairPerImageSelector.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.MaxPairPerImageSelector.Name = "MaxPairPerImageSelector";
            this.MaxPairPerImageSelector.Size = new System.Drawing.Size(94, 22);
            this.MaxPairPerImageSelector.TabIndex = 3;
            this.MaxPairPerImageSelector.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(7, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(244, 31);
            this.label6.TabIndex = 2;
            this.label6.Text = "Max teach pair per image (only for many training pair from image):";
            // 
            // PathTextBox
            // 
            this.PathTextBox.Location = new System.Drawing.Point(7, 22);
            this.PathTextBox.Name = "PathTextBox";
            this.PathTextBox.Size = new System.Drawing.Size(244, 22);
            this.PathTextBox.TabIndex = 1;
            // 
            // CahngePathButton
            // 
            this.CahngePathButton.Location = new System.Drawing.Point(257, 20);
            this.CahngePathButton.Name = "CahngePathButton";
            this.CahngePathButton.Size = new System.Drawing.Size(94, 23);
            this.CahngePathButton.TabIndex = 0;
            this.CahngePathButton.Text = "Change";
            this.CahngePathButton.UseVisualStyleBackColor = true;
            this.CahngePathButton.Click += new System.EventHandler(this.CahngePathButton_Click);
            // 
            // CreateButton
            // 
            this.CreateButton.Location = new System.Drawing.Point(13, 621);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(358, 33);
            this.CreateButton.TabIndex = 3;
            this.CreateButton.Text = "Create";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // CreateNeuronetForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 666);
            this.ControlBox = false;
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CreateNeuronetForm";
            this.Text = "Create multi-layer perceptron";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AmountOfOutputNeuronsSelector)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.HeightSelector)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.WidthSelector)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TrainingSpeedSelector)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AgesSelector)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxPairPerImageSelector)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown HeightSelector;
        private System.Windows.Forms.NumericUpDown WidthSelector;
        private System.Windows.Forms.TextBox AmountOfHiddenNeuronsSelector;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.NumericUpDown AmountOfOutputNeuronsSelector;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.RadioButton BackpropogationTeacherSelector;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox PathTextBox;
        private System.Windows.Forms.Button CahngePathButton;
        private System.Windows.Forms.NumericUpDown MaxPairPerImageSelector;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox8;
        private System.Windows.Forms.RadioButton DarkDigitSelector;
        private System.Windows.Forms.RadioButton LightDigitSelector;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.RadioButton ManyPairsPerImageSelector;
        private System.Windows.Forms.RadioButton OnePairPerImageSelector;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.NumericUpDown AgesSelector;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TrackBar TrainingSpeedSelector;
        private System.Windows.Forms.Label CurrentTrainigSpeedLabel;
    }
}