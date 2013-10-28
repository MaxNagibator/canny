namespace CannyProject
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.uiOpenImageToolStripLabel = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLabel4 = new System.Windows.Forms.ToolStripLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.uiInputImagePictureBox = new System.Windows.Forms.PictureBox();
            this.uiGaussianFilteredImagePictureBox = new System.Windows.Forms.PictureBox();
            this.uiFinalCannyPictureBox = new System.Windows.Forms.PictureBox();
            this.uiSigmaLabel = new System.Windows.Forms.Label();
            this.uiGaussianMaskSizeLabel = new System.Windows.Forms.Label();
            this.uiSigmaTextBox = new System.Windows.Forms.TextBox();
            this.uiGaussianMaskSizeTextBox = new System.Windows.Forms.TextBox();
            this.uiLowThresholdLabel = new System.Windows.Forms.Label();
            this.uiHighThresholdLabel = new System.Windows.Forms.Label();
            this.uiLowThresholdTextBox = new System.Windows.Forms.TextBox();
            this.uiCalcButton = new System.Windows.Forms.Button();
            this.uiHighThresholdTextBox = new System.Windows.Forms.TextBox();
            this.uiGnhPictureBox = new System.Windows.Forms.PictureBox();
            this.uiGnlPictureBox = new System.Windows.Forms.PictureBox();
            this.uiShiftLabel = new System.Windows.Forms.Label();
            this.uiShiftTextBox = new System.Windows.Forms.TextBox();
            this.uiShiftSizeLabel = new System.Windows.Forms.Label();
            this.uiShiftSizeTextBox = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiInputImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGaussianFilteredImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFinalCannyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGnhPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGnlPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiOpenImageToolStripLabel,
            this.toolStripLabel4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1068, 25);
            this.toolStrip1.TabIndex = 13;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // uiOpenImageToolStripLabel
            // 
            this.uiOpenImageToolStripLabel.Name = "uiOpenImageToolStripLabel";
            this.uiOpenImageToolStripLabel.Size = new System.Drawing.Size(36, 22);
            this.uiOpenImageToolStripLabel.Text = "Open";
            this.uiOpenImageToolStripLabel.Click += new System.EventHandler(this.uiOpenImageToolStripLabel_Click);
            // 
            // toolStripLabel4
            // 
            this.toolStripLabel4.Name = "toolStripLabel4";
            this.toolStripLabel4.Size = new System.Drawing.Size(25, 22);
            this.toolStripLabel4.Text = "Exit";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 53;
            this.label3.Text = "Input Image";
            // 
            // uiInputImagePictureBox
            // 
            this.uiInputImagePictureBox.Location = new System.Drawing.Point(14, 41);
            this.uiInputImagePictureBox.Name = "uiInputImagePictureBox";
            this.uiInputImagePictureBox.Size = new System.Drawing.Size(256, 196);
            this.uiInputImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiInputImagePictureBox.TabIndex = 52;
            this.uiInputImagePictureBox.TabStop = false;
            // 
            // uiGaussianFilteredImagePictureBox
            // 
            this.uiGaussianFilteredImagePictureBox.Location = new System.Drawing.Point(281, 41);
            this.uiGaussianFilteredImagePictureBox.Name = "uiGaussianFilteredImagePictureBox";
            this.uiGaussianFilteredImagePictureBox.Size = new System.Drawing.Size(256, 196);
            this.uiGaussianFilteredImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiGaussianFilteredImagePictureBox.TabIndex = 57;
            this.uiGaussianFilteredImagePictureBox.TabStop = false;
            // 
            // uiFinalCannyPictureBox
            // 
            this.uiFinalCannyPictureBox.Location = new System.Drawing.Point(14, 243);
            this.uiFinalCannyPictureBox.Name = "uiFinalCannyPictureBox";
            this.uiFinalCannyPictureBox.Size = new System.Drawing.Size(256, 196);
            this.uiFinalCannyPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiFinalCannyPictureBox.TabIndex = 58;
            this.uiFinalCannyPictureBox.TabStop = false;
            // 
            // uiSigmaLabel
            // 
            this.uiSigmaLabel.AutoSize = true;
            this.uiSigmaLabel.Location = new System.Drawing.Point(278, 360);
            this.uiSigmaLabel.Name = "uiSigmaLabel";
            this.uiSigmaLabel.Size = new System.Drawing.Size(36, 13);
            this.uiSigmaLabel.TabIndex = 70;
            this.uiSigmaLabel.Text = "Sigma";
            // 
            // uiGaussianMaskSizeLabel
            // 
            this.uiGaussianMaskSizeLabel.AutoSize = true;
            this.uiGaussianMaskSizeLabel.Location = new System.Drawing.Point(278, 321);
            this.uiGaussianMaskSizeLabel.Name = "uiGaussianMaskSizeLabel";
            this.uiGaussianMaskSizeLabel.Size = new System.Drawing.Size(103, 13);
            this.uiGaussianMaskSizeLabel.TabIndex = 69;
            this.uiGaussianMaskSizeLabel.Text = "Gaussian Mask Size";
            // 
            // uiSigmaTextBox
            // 
            this.uiSigmaTextBox.Location = new System.Drawing.Point(281, 376);
            this.uiSigmaTextBox.Name = "uiSigmaTextBox";
            this.uiSigmaTextBox.Size = new System.Drawing.Size(41, 20);
            this.uiSigmaTextBox.TabIndex = 68;
            this.uiSigmaTextBox.Text = "1";
            // 
            // uiGaussianMaskSizeTextBox
            // 
            this.uiGaussianMaskSizeTextBox.Location = new System.Drawing.Point(281, 337);
            this.uiGaussianMaskSizeTextBox.Name = "uiGaussianMaskSizeTextBox";
            this.uiGaussianMaskSizeTextBox.Size = new System.Drawing.Size(38, 20);
            this.uiGaussianMaskSizeTextBox.TabIndex = 67;
            this.uiGaussianMaskSizeTextBox.Text = "5";
            // 
            // uiLowThresholdLabel
            // 
            this.uiLowThresholdLabel.AutoSize = true;
            this.uiLowThresholdLabel.Location = new System.Drawing.Point(278, 282);
            this.uiLowThresholdLabel.Name = "uiLowThresholdLabel";
            this.uiLowThresholdLabel.Size = new System.Drawing.Size(93, 13);
            this.uiLowThresholdLabel.TabIndex = 66;
            this.uiLowThresholdLabel.Text = "Low Threshold TL";
            // 
            // uiHighThresholdLabel
            // 
            this.uiHighThresholdLabel.AutoSize = true;
            this.uiHighThresholdLabel.Location = new System.Drawing.Point(278, 243);
            this.uiHighThresholdLabel.Name = "uiHighThresholdLabel";
            this.uiHighThresholdLabel.Size = new System.Drawing.Size(97, 13);
            this.uiHighThresholdLabel.TabIndex = 65;
            this.uiHighThresholdLabel.Text = "High Threshold TH";
            // 
            // uiLowThresholdTextBox
            // 
            this.uiLowThresholdTextBox.Location = new System.Drawing.Point(281, 298);
            this.uiLowThresholdTextBox.Name = "uiLowThresholdTextBox";
            this.uiLowThresholdTextBox.Size = new System.Drawing.Size(41, 20);
            this.uiLowThresholdTextBox.TabIndex = 63;
            this.uiLowThresholdTextBox.Text = "10";
            // 
            // uiCalcButton
            // 
            this.uiCalcButton.Location = new System.Drawing.Point(276, 402);
            this.uiCalcButton.Name = "uiCalcButton";
            this.uiCalcButton.Size = new System.Drawing.Size(75, 36);
            this.uiCalcButton.TabIndex = 64;
            this.uiCalcButton.Text = "Canny";
            this.uiCalcButton.UseVisualStyleBackColor = true;
            this.uiCalcButton.Click += new System.EventHandler(this.uiCalcButton_Click);
            // 
            // uiHighThresholdTextBox
            // 
            this.uiHighThresholdTextBox.Location = new System.Drawing.Point(281, 259);
            this.uiHighThresholdTextBox.Name = "uiHighThresholdTextBox";
            this.uiHighThresholdTextBox.Size = new System.Drawing.Size(38, 20);
            this.uiHighThresholdTextBox.TabIndex = 62;
            this.uiHighThresholdTextBox.Text = "20";
            // 
            // uiGnhPictureBox
            // 
            this.uiGnhPictureBox.Location = new System.Drawing.Point(543, 41);
            this.uiGnhPictureBox.Name = "uiGnhPictureBox";
            this.uiGnhPictureBox.Size = new System.Drawing.Size(256, 196);
            this.uiGnhPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiGnhPictureBox.TabIndex = 71;
            this.uiGnhPictureBox.TabStop = false;
            // 
            // uiGnlPictureBox
            // 
            this.uiGnlPictureBox.Location = new System.Drawing.Point(805, 41);
            this.uiGnlPictureBox.Name = "uiGnlPictureBox";
            this.uiGnlPictureBox.Size = new System.Drawing.Size(256, 196);
            this.uiGnlPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiGnlPictureBox.TabIndex = 72;
            this.uiGnlPictureBox.TabStop = false;
            // 
            // uiShiftLabel
            // 
            this.uiShiftLabel.AutoSize = true;
            this.uiShiftLabel.Location = new System.Drawing.Point(399, 360);
            this.uiShiftLabel.Name = "uiShiftLabel";
            this.uiShiftLabel.Size = new System.Drawing.Size(26, 13);
            this.uiShiftLabel.TabIndex = 74;
            this.uiShiftLabel.Text = "shift";
            // 
            // uiShiftTextBox
            // 
            this.uiShiftTextBox.Location = new System.Drawing.Point(402, 376);
            this.uiShiftTextBox.Name = "uiShiftTextBox";
            this.uiShiftTextBox.Size = new System.Drawing.Size(41, 20);
            this.uiShiftTextBox.TabIndex = 73;
            this.uiShiftTextBox.Text = "30";
            // 
            // uiShiftSizeLabel
            // 
            this.uiShiftSizeLabel.AutoSize = true;
            this.uiShiftSizeLabel.Location = new System.Drawing.Point(463, 360);
            this.uiShiftSizeLabel.Name = "uiShiftSizeLabel";
            this.uiShiftSizeLabel.Size = new System.Drawing.Size(47, 13);
            this.uiShiftSizeLabel.TabIndex = 76;
            this.uiShiftSizeLabel.Text = "shift size";
            // 
            // uiShiftSizeTextBox
            // 
            this.uiShiftSizeTextBox.Location = new System.Drawing.Point(466, 376);
            this.uiShiftSizeTextBox.Name = "uiShiftSizeTextBox";
            this.uiShiftSizeTextBox.Size = new System.Drawing.Size(41, 20);
            this.uiShiftSizeTextBox.TabIndex = 75;
            this.uiShiftSizeTextBox.Text = "3";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1068, 492);
            this.Controls.Add(this.uiShiftSizeLabel);
            this.Controls.Add(this.uiShiftSizeTextBox);
            this.Controls.Add(this.uiShiftLabel);
            this.Controls.Add(this.uiShiftTextBox);
            this.Controls.Add(this.uiGnlPictureBox);
            this.Controls.Add(this.uiGnhPictureBox);
            this.Controls.Add(this.uiSigmaLabel);
            this.Controls.Add(this.uiGaussianMaskSizeLabel);
            this.Controls.Add(this.uiSigmaTextBox);
            this.Controls.Add(this.uiGaussianMaskSizeTextBox);
            this.Controls.Add(this.uiLowThresholdLabel);
            this.Controls.Add(this.uiHighThresholdLabel);
            this.Controls.Add(this.uiLowThresholdTextBox);
            this.Controls.Add(this.uiCalcButton);
            this.Controls.Add(this.uiHighThresholdTextBox);
            this.Controls.Add(this.uiFinalCannyPictureBox);
            this.Controls.Add(this.uiGaussianFilteredImagePictureBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uiInputImagePictureBox);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Canny";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiInputImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGaussianFilteredImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFinalCannyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGnhPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGnlPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripLabel uiOpenImageToolStripLabel;
        private System.Windows.Forms.ToolStripLabel toolStripLabel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox uiInputImagePictureBox;
        private System.Windows.Forms.PictureBox uiGaussianFilteredImagePictureBox;
        private System.Windows.Forms.PictureBox uiFinalCannyPictureBox;
        private System.Windows.Forms.Label uiSigmaLabel;
        private System.Windows.Forms.Label uiGaussianMaskSizeLabel;
        private System.Windows.Forms.TextBox uiSigmaTextBox;
        private System.Windows.Forms.TextBox uiGaussianMaskSizeTextBox;
        private System.Windows.Forms.Label uiLowThresholdLabel;
        private System.Windows.Forms.Label uiHighThresholdLabel;
        private System.Windows.Forms.TextBox uiLowThresholdTextBox;
        private System.Windows.Forms.Button uiCalcButton;
        private System.Windows.Forms.TextBox uiHighThresholdTextBox;
        private System.Windows.Forms.PictureBox uiGnhPictureBox;
        private System.Windows.Forms.PictureBox uiGnlPictureBox;
        private System.Windows.Forms.Label uiShiftLabel;
        private System.Windows.Forms.TextBox uiShiftTextBox;
        private System.Windows.Forms.Label uiShiftSizeLabel;
        private System.Windows.Forms.TextBox uiShiftSizeTextBox;
    }
}

