namespace NeuroNet.Desktop
{
    partial class NeuronetInfoViewer
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
            this.label1 = new System.Windows.Forms.Label();
            this.ImageSizeLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TrainingTimeLabel = new System.Windows.Forms.Label();
            this.AdditionalInfoList = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.AmountOfHiddenNeuronsLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Image size:";
            // 
            // ImageSizeLabel
            // 
            this.ImageSizeLabel.AutoSize = true;
            this.ImageSizeLabel.Location = new System.Drawing.Point(149, 13);
            this.ImageSizeLabel.Name = "ImageSizeLabel";
            this.ImageSizeLabel.Size = new System.Drawing.Size(26, 13);
            this.ImageSizeLabel.TabIndex = 1;
            this.ImageSizeLabel.Text = "size";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Training time:";
            // 
            // TrainingTimeLabel
            // 
            this.TrainingTimeLabel.AutoSize = true;
            this.TrainingTimeLabel.Location = new System.Drawing.Point(149, 41);
            this.TrainingTimeLabel.Name = "TrainingTimeLabel";
            this.TrainingTimeLabel.Size = new System.Drawing.Size(29, 13);
            this.TrainingTimeLabel.TabIndex = 0;
            this.TrainingTimeLabel.Text = "time";
            // 
            // AdditionalInfoList
            // 
            this.AdditionalInfoList.FormattingEnabled = true;
            this.AdditionalInfoList.Location = new System.Drawing.Point(16, 167);
            this.AdditionalInfoList.Name = "AdditionalInfoList";
            this.AdditionalInfoList.Size = new System.Drawing.Size(178, 95);
            this.AdditionalInfoList.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 30);
            this.label3.TabIndex = 3;
            this.label3.Text = "Amount of hidden neurons:";
            // 
            // AmountOfHiddenNeuronsLabel
            // 
            this.AmountOfHiddenNeuronsLabel.AutoSize = true;
            this.AmountOfHiddenNeuronsLabel.Location = new System.Drawing.Point(149, 72);
            this.AmountOfHiddenNeuronsLabel.Name = "AmountOfHiddenNeuronsLabel";
            this.AmountOfHiddenNeuronsLabel.Size = new System.Drawing.Size(47, 13);
            this.AmountOfHiddenNeuronsLabel.TabIndex = 0;
            this.AmountOfHiddenNeuronsLabel.Text = "amount";
            // 
            // NeuronetInfoViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(206, 274);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.AdditionalInfoList);
            this.Controls.Add(this.ImageSizeLabel);
            this.Controls.Add(this.AmountOfHiddenNeuronsLabel);
            this.Controls.Add(this.TrainingTimeLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NeuronetInfoViewer";
            this.Text = "NeuronetInfoViewer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label ImageSizeLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label TrainingTimeLabel;
        private System.Windows.Forms.ListBox AdditionalInfoList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label AmountOfHiddenNeuronsLabel;
    }
}