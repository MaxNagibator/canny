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
            this.uiShiftLabel = new System.Windows.Forms.Label();
            this.uiShiftTextBox = new System.Windows.Forms.TextBox();
            this.uiShiftSizeLabel = new System.Windows.Forms.Label();
            this.uiSizeTextBox = new System.Windows.Forms.TextBox();
            this.uiShift2SizeLabel = new System.Windows.Forms.Label();
            this.uiShift2SizeTextBox = new System.Windows.Forms.TextBox();
            this.uiShift2Label = new System.Windows.Forms.Label();
            this.uiShift2TextBox = new System.Windows.Forms.TextBox();
            this.uiKoefficient1Label = new System.Windows.Forms.Label();
            this.uiKoefficient1TextBox = new System.Windows.Forms.TextBox();
            this.uiKoefficient2Label = new System.Windows.Forms.Label();
            this.uiKoefficient2TextBox = new System.Windows.Forms.TextBox();
            this.uiKoefficient3Label = new System.Windows.Forms.Label();
            this.uiKoefficient3TextBox = new System.Windows.Forms.TextBox();
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl = new CannyProject.KoeeficientClasses.Gui.ClearEdgeMapHomeAlonePointKoeefficientControl();
            this.uiSpecialPictureBox = new System.Windows.Forms.PictureBox();
            this.uiGradientPictureBox = new System.Windows.Forms.PictureBox();
            this.uiGnlPictureBox = new System.Windows.Forms.PictureBox();
            this.uiGnhPictureBox = new System.Windows.Forms.PictureBox();
            this.uiFinalCannyPictureBox = new System.Windows.Forms.PictureBox();
            this.uiGaussianFilteredImagePictureBox = new System.Windows.Forms.PictureBox();
            this.uiInputImagePictureBox = new System.Windows.Forms.PictureBox();
            this.uiMainKoeefficientControl = new CannyProject.KoeeficientClasses.Gui.MainKoeefficientControl();
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
            this.toolStrip1.Size = new System.Drawing.Size(1099, 25);
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
            // uiShiftLabel
            // 
            this.uiShiftLabel.AutoSize = true;
            this.uiShiftLabel.Location = new System.Drawing.Point(278, 439);
            this.uiShiftLabel.Name = "uiShiftLabel";
            this.uiShiftLabel.Size = new System.Drawing.Size(26, 13);
            this.uiShiftLabel.TabIndex = 74;
            this.uiShiftLabel.Text = "shift";
            // 
            // uiShiftTextBox
            // 
            this.uiShiftTextBox.Location = new System.Drawing.Point(281, 455);
            this.uiShiftTextBox.Name = "uiShiftTextBox";
            this.uiShiftTextBox.Size = new System.Drawing.Size(41, 20);
            this.uiShiftTextBox.TabIndex = 73;
            this.uiShiftTextBox.Text = "5";
            // 
            // uiShiftSizeLabel
            // 
            this.uiShiftSizeLabel.AutoSize = true;
            this.uiShiftSizeLabel.Location = new System.Drawing.Point(342, 439);
            this.uiShiftSizeLabel.Name = "uiShiftSizeLabel";
            this.uiShiftSizeLabel.Size = new System.Drawing.Size(25, 13);
            this.uiShiftSizeLabel.TabIndex = 76;
            this.uiShiftSizeLabel.Text = "size";
            // 
            // uiSizeTextBox
            // 
            this.uiSizeTextBox.Location = new System.Drawing.Point(345, 455);
            this.uiSizeTextBox.Name = "uiSizeTextBox";
            this.uiSizeTextBox.Size = new System.Drawing.Size(41, 20);
            this.uiSizeTextBox.TabIndex = 75;
            this.uiSizeTextBox.Text = "20";
            // 
            // uiShift2SizeLabel
            // 
            this.uiShift2SizeLabel.AutoSize = true;
            this.uiShift2SizeLabel.Location = new System.Drawing.Point(927, 298);
            this.uiShift2SizeLabel.Name = "uiShift2SizeLabel";
            this.uiShift2SizeLabel.Size = new System.Drawing.Size(47, 13);
            this.uiShift2SizeLabel.TabIndex = 80;
            this.uiShift2SizeLabel.Text = "shift size";
            this.uiShift2SizeLabel.Visible = false;
            // 
            // uiShift2SizeTextBox
            // 
            this.uiShift2SizeTextBox.Location = new System.Drawing.Point(930, 314);
            this.uiShift2SizeTextBox.Name = "uiShift2SizeTextBox";
            this.uiShift2SizeTextBox.Size = new System.Drawing.Size(41, 20);
            this.uiShift2SizeTextBox.TabIndex = 79;
            this.uiShift2SizeTextBox.Text = "3";
            this.uiShift2SizeTextBox.Visible = false;
            // 
            // uiShift2Label
            // 
            this.uiShift2Label.AutoSize = true;
            this.uiShift2Label.Location = new System.Drawing.Point(863, 298);
            this.uiShift2Label.Name = "uiShift2Label";
            this.uiShift2Label.Size = new System.Drawing.Size(26, 13);
            this.uiShift2Label.TabIndex = 78;
            this.uiShift2Label.Text = "shift";
            this.uiShift2Label.Visible = false;
            // 
            // uiShift2TextBox
            // 
            this.uiShift2TextBox.Location = new System.Drawing.Point(866, 314);
            this.uiShift2TextBox.Name = "uiShift2TextBox";
            this.uiShift2TextBox.Size = new System.Drawing.Size(41, 20);
            this.uiShift2TextBox.TabIndex = 77;
            this.uiShift2TextBox.Text = "30";
            this.uiShift2TextBox.Visible = false;
            // 
            // uiKoefficient1Label
            // 
            this.uiKoefficient1Label.AutoSize = true;
            this.uiKoefficient1Label.Location = new System.Drawing.Point(278, 474);
            this.uiKoefficient1Label.Name = "uiKoefficient1Label";
            this.uiKoefficient1Label.Size = new System.Drawing.Size(63, 13);
            this.uiKoefficient1Label.TabIndex = 84;
            this.uiKoefficient1Label.Text = "Koefficient1";
            // 
            // uiKoefficient1TextBox
            // 
            this.uiKoefficient1TextBox.Location = new System.Drawing.Point(281, 490);
            this.uiKoefficient1TextBox.Name = "uiKoefficient1TextBox";
            this.uiKoefficient1TextBox.Size = new System.Drawing.Size(41, 20);
            this.uiKoefficient1TextBox.TabIndex = 83;
            this.uiKoefficient1TextBox.Text = "2";
            // 
            // uiKoefficient2Label
            // 
            this.uiKoefficient2Label.AutoSize = true;
            this.uiKoefficient2Label.Location = new System.Drawing.Point(278, 507);
            this.uiKoefficient2Label.Name = "uiKoefficient2Label";
            this.uiKoefficient2Label.Size = new System.Drawing.Size(63, 13);
            this.uiKoefficient2Label.TabIndex = 86;
            this.uiKoefficient2Label.Text = "Koefficient2";
            // 
            // uiKoefficient2TextBox
            // 
            this.uiKoefficient2TextBox.Location = new System.Drawing.Point(281, 523);
            this.uiKoefficient2TextBox.Name = "uiKoefficient2TextBox";
            this.uiKoefficient2TextBox.Size = new System.Drawing.Size(41, 20);
            this.uiKoefficient2TextBox.TabIndex = 85;
            this.uiKoefficient2TextBox.Text = "5";
            // 
            // uiKoefficient3Label
            // 
            this.uiKoefficient3Label.AutoSize = true;
            this.uiKoefficient3Label.Location = new System.Drawing.Point(278, 543);
            this.uiKoefficient3Label.Name = "uiKoefficient3Label";
            this.uiKoefficient3Label.Size = new System.Drawing.Size(63, 13);
            this.uiKoefficient3Label.TabIndex = 88;
            this.uiKoefficient3Label.Text = "Koefficient3";
            // 
            // uiKoefficient3TextBox
            // 
            this.uiKoefficient3TextBox.Location = new System.Drawing.Point(281, 559);
            this.uiKoefficient3TextBox.Name = "uiKoefficient3TextBox";
            this.uiKoefficient3TextBox.Size = new System.Drawing.Size(41, 20);
            this.uiKoefficient3TextBox.TabIndex = 87;
            this.uiKoefficient3TextBox.Text = "4";
            // 
            // uiClearEdgeMapHomeAlonePointKoeefficientControl
            // 
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.Location = new System.Drawing.Point(844, 340);
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.MinimumSize = new System.Drawing.Size(15, 15);
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.Name = "uiClearEdgeMapHomeAlonePointKoeefficientControl";
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.Size = new System.Drawing.Size(243, 217);
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.TabIndex = 89;
            // 
            // uiSpecialPictureBox
            // 
            this.uiSpecialPictureBox.Location = new System.Drawing.Point(394, 444);
            this.uiSpecialPictureBox.Name = "uiSpecialPictureBox";
            this.uiSpecialPictureBox.Size = new System.Drawing.Size(256, 196);
            this.uiSpecialPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiSpecialPictureBox.TabIndex = 82;
            this.uiSpecialPictureBox.TabStop = false;
            // 
            // uiGradientPictureBox
            // 
            this.uiGradientPictureBox.Location = new System.Drawing.Point(394, 242);
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
            // mainKoeefficientControl1
            // 
            this.uiMainKoeefficientControl.Location = new System.Drawing.Point(676, 340);
            this.uiMainKoeefficientControl.MinimumSize = new System.Drawing.Size(15, 15);
            this.uiMainKoeefficientControl.Name = "uiMainKoeefficientControl";
            this.uiMainKoeefficientControl.Size = new System.Drawing.Size(153, 217);
            this.uiMainKoeefficientControl.TabIndex = 90;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1099, 698);
            this.Controls.Add(this.uiMainKoeefficientControl);
            this.Controls.Add(this.uiClearEdgeMapHomeAlonePointKoeefficientControl);
            this.Controls.Add(this.uiKoefficient3Label);
            this.Controls.Add(this.uiKoefficient3TextBox);
            this.Controls.Add(this.uiKoefficient2Label);
            this.Controls.Add(this.uiKoefficient2TextBox);
            this.Controls.Add(this.uiKoefficient1Label);
            this.Controls.Add(this.uiKoefficient1TextBox);
            this.Controls.Add(this.uiSpecialPictureBox);
            this.Controls.Add(this.uiGradientPictureBox);
            this.Controls.Add(this.uiShift2SizeLabel);
            this.Controls.Add(this.uiShift2SizeTextBox);
            this.Controls.Add(this.uiShift2Label);
            this.Controls.Add(this.uiShift2TextBox);
            this.Controls.Add(this.uiShiftSizeLabel);
            this.Controls.Add(this.uiSizeTextBox);
            this.Controls.Add(this.uiShiftLabel);
            this.Controls.Add(this.uiShiftTextBox);
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
        private System.Windows.Forms.Label uiShiftLabel;
        private System.Windows.Forms.TextBox uiShiftTextBox;
        private System.Windows.Forms.Label uiShiftSizeLabel;
        private System.Windows.Forms.TextBox uiSizeTextBox;
        private System.Windows.Forms.Label uiShift2SizeLabel;
        private System.Windows.Forms.TextBox uiShift2SizeTextBox;
        private System.Windows.Forms.Label uiShift2Label;
        private System.Windows.Forms.TextBox uiShift2TextBox;
        private System.Windows.Forms.PictureBox uiGradientPictureBox;
        private System.Windows.Forms.PictureBox uiSpecialPictureBox;
        private System.Windows.Forms.Label uiKoefficient1Label;
        private System.Windows.Forms.TextBox uiKoefficient1TextBox;
        private System.Windows.Forms.Label uiKoefficient2Label;
        private System.Windows.Forms.TextBox uiKoefficient2TextBox;
        private System.Windows.Forms.Label uiKoefficient3Label;
        private System.Windows.Forms.TextBox uiKoefficient3TextBox;
        private ClearEdgeMapHomeAlonePointKoeefficientControl uiClearEdgeMapHomeAlonePointKoeefficientControl;
        private MainKoeefficientControl uiMainKoeefficientControl;
    }
}

