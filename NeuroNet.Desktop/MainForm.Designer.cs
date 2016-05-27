namespace NeuroNet.Desktop
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.InfoButton = new System.Windows.Forms.Button();
            this.ProgressLabel = new System.Windows.Forms.Label();
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.LoadButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CreateNeuronetButton = new System.Windows.Forms.Button();
            this.TeachByTrainingSetButton = new System.Windows.Forms.Button();
            this.PaintBoard = new NeuroNet.Desktop.PaintBoard();
            this.NetworkDigitAnswerVisualizator = new NeuroNet.Desktop.NetworkDigitAnswerVisualizator();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PaintBoard)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.PaintBoard, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.NetworkDigitAnswerVisualizator, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(420, 254);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.InfoButton);
            this.panel1.Controls.Add(this.ProgressLabel);
            this.panel1.Controls.Add(this.ProgressBar);
            this.panel1.Controls.Add(this.LoadButton);
            this.panel1.Controls.Add(this.SaveButton);
            this.panel1.Controls.Add(this.CreateNeuronetButton);
            this.panel1.Controls.Add(this.TeachByTrainingSetButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(223, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 198);
            this.panel1.TabIndex = 2;
            // 
            // InfoButton
            // 
            this.InfoButton.Location = new System.Drawing.Point(6, 127);
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(180, 24);
            this.InfoButton.TabIndex = 9;
            this.InfoButton.Text = "Info";
            this.InfoButton.UseVisualStyleBackColor = true;
            this.InfoButton.Click += new System.EventHandler(this.InfoButton_Click);
            // 
            // ProgressLabel
            // 
            this.ProgressLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.ProgressLabel.Location = new System.Drawing.Point(7, 148);
            this.ProgressLabel.Name = "ProgressLabel";
            this.ProgressLabel.Size = new System.Drawing.Size(178, 13);
            this.ProgressLabel.TabIndex = 8;
            this.ProgressLabel.Text = "-";
            this.ProgressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(6, 164);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(179, 23);
            this.ProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.ProgressBar.TabIndex = 7;
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(6, 97);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(180, 24);
            this.LoadButton.TabIndex = 6;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Enabled = false;
            this.SaveButton.Location = new System.Drawing.Point(6, 67);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(180, 24);
            this.SaveButton.TabIndex = 6;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CreateNeuronetButton
            // 
            this.CreateNeuronetButton.Location = new System.Drawing.Point(6, 7);
            this.CreateNeuronetButton.Name = "CreateNeuronetButton";
            this.CreateNeuronetButton.Size = new System.Drawing.Size(180, 24);
            this.CreateNeuronetButton.TabIndex = 2;
            this.CreateNeuronetButton.Text = "Create";
            this.CreateNeuronetButton.UseVisualStyleBackColor = true;
            this.CreateNeuronetButton.Click += new System.EventHandler(this.CreateNeuronetButton_Click);
            // 
            // TeachByTrainingSetButton
            // 
            this.TeachByTrainingSetButton.Enabled = false;
            this.TeachByTrainingSetButton.Location = new System.Drawing.Point(6, 37);
            this.TeachByTrainingSetButton.Name = "TeachByTrainingSetButton";
            this.TeachByTrainingSetButton.Size = new System.Drawing.Size(180, 24);
            this.TeachByTrainingSetButton.TabIndex = 2;
            this.TeachByTrainingSetButton.Text = "Teach";
            this.TeachByTrainingSetButton.UseVisualStyleBackColor = true;
            this.TeachByTrainingSetButton.Click += new System.EventHandler(this.TeachByImgButton_Click);
            // 
            // PaintBoard
            // 
            this.PaintBoard.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("PaintBoard.BackgroundImage")));
            this.PaintBoard.BrushRadius = 1;
            this.PaintBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PaintBoard.Image = ((System.Drawing.Image)(resources.GetObject("PaintBoard.Image")));
            this.PaintBoard.Location = new System.Drawing.Point(3, 3);
            this.PaintBoard.Name = "PaintBoard";
            this.PaintBoard.Size = new System.Drawing.Size(214, 198);
            this.PaintBoard.TabIndex = 0;
            this.PaintBoard.TabStop = false;
            this.PaintBoard.XResolution = 16;
            this.PaintBoard.YResolution = 16;
            // 
            // NetworkDigitAnswerVisualizator
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.NetworkDigitAnswerVisualizator, 2);
            this.NetworkDigitAnswerVisualizator.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NetworkDigitAnswerVisualizator.Font = new System.Drawing.Font("Cambria", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NetworkDigitAnswerVisualizator.ForeColor = System.Drawing.Color.White;
            this.NetworkDigitAnswerVisualizator.Location = new System.Drawing.Point(9, 213);
            this.NetworkDigitAnswerVisualizator.Margin = new System.Windows.Forms.Padding(9, 9, 9, 9);
            this.NetworkDigitAnswerVisualizator.Name = "NetworkDigitAnswerVisualizator";
            this.NetworkDigitAnswerVisualizator.Size = new System.Drawing.Size(402, 32);
            this.NetworkDigitAnswerVisualizator.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 254);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.MinimumSize = new System.Drawing.Size(436, 292);
            this.Name = "MainForm";
            this.Text = "NeuroNet.Desktop";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.PaintBoard)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private PaintBoard PaintBoard;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button TeachByTrainingSetButton;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Label ProgressLabel;
        private NetworkDigitAnswerVisualizator NetworkDigitAnswerVisualizator;
        private System.Windows.Forms.Button CreateNeuronetButton;
        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.Button InfoButton;

    }
}

