using CannyProject.KoeeficientClasses.Gui;

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
            this.uiCalcButton = new System.Windows.Forms.Button();
            this.uiShift2SizeLabel = new System.Windows.Forms.Label();
            this.uiShift2SizeTextBox = new System.Windows.Forms.TextBox();
            this.uiShift2Label = new System.Windows.Forms.Label();
            this.uiShift2TextBox = new System.Windows.Forms.TextBox();
            this.uiSpecialPictureBox = new System.Windows.Forms.PictureBox();
            this.uiGradientPictureBox = new System.Windows.Forms.PictureBox();
            this.uiGnlPictureBox = new System.Windows.Forms.PictureBox();
            this.uiGnhPictureBox = new System.Windows.Forms.PictureBox();
            this.uiFinalCannyPictureBox = new System.Windows.Forms.PictureBox();
            this.uiGaussianFilteredImagePictureBox = new System.Windows.Forms.PictureBox();
            this.uiInputImagePictureBox = new System.Windows.Forms.PictureBox();
            this.uiMainKoeefficientControl = new CannyProject.KoeeficientClasses.Gui.MainKoeefficientControl();
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl = new CannyProject.KoeeficientClasses.Gui.ClearEdgeMapHomeAlonePointKoeefficientControl();
            this.uiClearGradientIfOtherNeighborhoodKoeefficientControl = new CannyProject.KoeeficientClasses.Gui.ClearGradientIfOtherNeighborhoodKoeefficientControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpecialPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGradientPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGnlPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGnhPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFinalCannyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGaussianFilteredImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiInputImagePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uiOpenImageToolStripLabel,
            this.toolStripLabel4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1124, 25);
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
            // uiShift2SizeLabel
            // 
            this.uiShift2SizeLabel.AutoSize = true;
            this.uiShift2SizeLabel.Location = new System.Drawing.Point(697, 521);
            this.uiShift2SizeLabel.Name = "uiShift2SizeLabel";
            this.uiShift2SizeLabel.Size = new System.Drawing.Size(47, 13);
            this.uiShift2SizeLabel.TabIndex = 80;
            this.uiShift2SizeLabel.Text = "shift size";
            this.uiShift2SizeLabel.Visible = false;
            // 
            // uiShift2SizeTextBox
            // 
            this.uiShift2SizeTextBox.Location = new System.Drawing.Point(700, 537);
            this.uiShift2SizeTextBox.Name = "uiShift2SizeTextBox";
            this.uiShift2SizeTextBox.Size = new System.Drawing.Size(41, 20);
            this.uiShift2SizeTextBox.TabIndex = 79;
            this.uiShift2SizeTextBox.Text = "3";
            this.uiShift2SizeTextBox.Visible = false;
            // 
            // uiShift2Label
            // 
            this.uiShift2Label.AutoSize = true;
            this.uiShift2Label.Location = new System.Drawing.Point(633, 521);
            this.uiShift2Label.Name = "uiShift2Label";
            this.uiShift2Label.Size = new System.Drawing.Size(26, 13);
            this.uiShift2Label.TabIndex = 78;
            this.uiShift2Label.Text = "shift";
            this.uiShift2Label.Visible = false;
            // 
            // uiShift2TextBox
            // 
            this.uiShift2TextBox.Location = new System.Drawing.Point(636, 537);
            this.uiShift2TextBox.Name = "uiShift2TextBox";
            this.uiShift2TextBox.Size = new System.Drawing.Size(41, 20);
            this.uiShift2TextBox.TabIndex = 77;
            this.uiShift2TextBox.Text = "30";
            this.uiShift2TextBox.Visible = false;
            // 
            // uiSpecialPictureBox
            // 
            this.uiSpecialPictureBox.Location = new System.Drawing.Point(281, 444);
            this.uiSpecialPictureBox.Name = "uiSpecialPictureBox";
            this.uiSpecialPictureBox.Size = new System.Drawing.Size(256, 196);
            this.uiSpecialPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiSpecialPictureBox.TabIndex = 82;
            this.uiSpecialPictureBox.TabStop = false;
            // 
            // uiGradientPictureBox
            // 
            this.uiGradientPictureBox.Location = new System.Drawing.Point(14, 444);
            this.uiGradientPictureBox.Name = "uiGradientPictureBox";
            this.uiGradientPictureBox.Size = new System.Drawing.Size(256, 196);
            this.uiGradientPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiGradientPictureBox.TabIndex = 81;
            this.uiGradientPictureBox.TabStop = false;
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
            // uiGnhPictureBox
            // 
            this.uiGnhPictureBox.Location = new System.Drawing.Point(543, 41);
            this.uiGnhPictureBox.Name = "uiGnhPictureBox";
            this.uiGnhPictureBox.Size = new System.Drawing.Size(256, 196);
            this.uiGnhPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiGnhPictureBox.TabIndex = 71;
            this.uiGnhPictureBox.TabStop = false;
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
            // uiGaussianFilteredImagePictureBox
            // 
            this.uiGaussianFilteredImagePictureBox.Location = new System.Drawing.Point(281, 41);
            this.uiGaussianFilteredImagePictureBox.Name = "uiGaussianFilteredImagePictureBox";
            this.uiGaussianFilteredImagePictureBox.Size = new System.Drawing.Size(256, 196);
            this.uiGaussianFilteredImagePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiGaussianFilteredImagePictureBox.TabIndex = 57;
            this.uiGaussianFilteredImagePictureBox.TabStop = false;
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
            // uiMainKoeefficientControl
            // 
            this.uiMainKoeefficientControl.Location = new System.Drawing.Point(566, 256);
            this.uiMainKoeefficientControl.MinimumSize = new System.Drawing.Size(15, 15);
            this.uiMainKoeefficientControl.Name = "uiMainKoeefficientControl";
            this.uiMainKoeefficientControl.Size = new System.Drawing.Size(153, 217);
            this.uiMainKoeefficientControl.TabIndex = 90;
            // 
            // uiClearEdgeMapHomeAlonePointKoeefficientControl
            // 
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.Location = new System.Drawing.Point(871, 256);
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.MinimumSize = new System.Drawing.Size(15, 15);
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.Name = "uiClearEdgeMapHomeAlonePointKoeefficientControl";
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.Size = new System.Drawing.Size(243, 217);
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.TabIndex = 89;
            // 
            // uiClearGradientIfOtherNeighborhoodKoeefficientControl
            // 
            this.uiClearGradientIfOtherNeighborhoodKoeefficientControl.Location = new System.Drawing.Point(725, 256);
            this.uiClearGradientIfOtherNeighborhoodKoeefficientControl.MinimumSize = new System.Drawing.Size(15, 15);
            this.uiClearGradientIfOtherNeighborhoodKoeefficientControl.Name = "uiClearGradientIfOtherNeighborhoodKoeefficientControl";
            this.uiClearGradientIfOtherNeighborhoodKoeefficientControl.Size = new System.Drawing.Size(140, 213);
            this.uiClearGradientIfOtherNeighborhoodKoeefficientControl.TabIndex = 91;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 698);
            this.Controls.Add(this.uiClearGradientIfOtherNeighborhoodKoeefficientControl);
            this.Controls.Add(this.uiMainKoeefficientControl);
            this.Controls.Add(this.uiClearEdgeMapHomeAlonePointKoeefficientControl);
            this.Controls.Add(this.uiSpecialPictureBox);
            this.Controls.Add(this.uiGradientPictureBox);
            this.Controls.Add(this.uiShift2SizeLabel);
            this.Controls.Add(this.uiShift2SizeTextBox);
            this.Controls.Add(this.uiShift2Label);
            this.Controls.Add(this.uiShift2TextBox);
            this.Controls.Add(this.uiGnlPictureBox);
            this.Controls.Add(this.uiGnhPictureBox);
            this.Controls.Add(this.uiCalcButton);
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
            ((System.ComponentModel.ISupportInitialize)(this.uiSpecialPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGradientPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGnlPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGnhPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFinalCannyPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGaussianFilteredImagePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiInputImagePictureBox)).EndInit();
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
        private System.Windows.Forms.Button uiCalcButton;
        private System.Windows.Forms.PictureBox uiGnhPictureBox;
        private System.Windows.Forms.PictureBox uiGnlPictureBox;
        private System.Windows.Forms.Label uiShift2SizeLabel;
        private System.Windows.Forms.TextBox uiShift2SizeTextBox;
        private System.Windows.Forms.Label uiShift2Label;
        private System.Windows.Forms.TextBox uiShift2TextBox;
        private System.Windows.Forms.PictureBox uiGradientPictureBox;
        private System.Windows.Forms.PictureBox uiSpecialPictureBox;
        private ClearEdgeMapHomeAlonePointKoeefficientControl uiClearEdgeMapHomeAlonePointKoeefficientControl;
        private MainKoeefficientControl uiMainKoeefficientControl;
        private ClearGradientIfOtherNeighborhoodKoeefficientControl uiClearGradientIfOtherNeighborhoodKoeefficientControl;
    }
}

