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
            this.uiSpecialPictureBox = new System.Windows.Forms.PictureBox();
            this.uiGradientPictureBox = new System.Windows.Forms.PictureBox();
            this.uiGnlPictureBox = new System.Windows.Forms.PictureBox();
            this.uiGnhPictureBox = new System.Windows.Forms.PictureBox();
            this.uiFinalCannyPictureBox = new System.Windows.Forms.PictureBox();
            this.uiGaussianFilteredImagePictureBox = new System.Windows.Forms.PictureBox();
            this.uiInputImagePictureBox = new System.Windows.Forms.PictureBox();
            this.uiNonMaxPictureBox = new System.Windows.Forms.PictureBox();
            this.colorKoeefficientControl = new CannyProject.KoeeficientClasses.Gui.ColorKoeefficientControl();
            this.uiClearGradientIfOtherNeighborhoodKoeefficientControl = new CannyProject.KoeeficientClasses.Gui.ClearGradientIfOtherNeighborhoodKoeefficientControl();
            this.uiMainKoeefficientControl = new CannyProject.KoeeficientClasses.Gui.MainKoeefficientControl();
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl = new CannyProject.KoeeficientClasses.Gui.ClearEdgeMapHomeAlonePointKoeefficientControl();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpecialPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGradientPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGnlPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGnhPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiFinalCannyPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiGaussianFilteredImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiInputImagePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uiNonMaxPictureBox)).BeginInit();
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
            // pictureBox1
            // 
            this.uiNonMaxPictureBox.Location = new System.Drawing.Point(18, 646);
            this.uiNonMaxPictureBox.Name = "uiNonMaxPictureBox";
            this.uiNonMaxPictureBox.Size = new System.Drawing.Size(256, 196);
            this.uiNonMaxPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiNonMaxPictureBox.TabIndex = 93;
            this.uiNonMaxPictureBox.TabStop = false;
            // 
            // colorKoeefficientControl
            // 
            this.colorKoeefficientControl.Location = new System.Drawing.Point(974, 494);
            this.colorKoeefficientControl.MinimumSize = new System.Drawing.Size(15, 15);
            this.colorKoeefficientControl.Name = "colorKoeefficientControl";
            this.colorKoeefficientControl.Size = new System.Drawing.Size(125, 150);
            this.colorKoeefficientControl.TabIndex = 92;
            // 
            // uiClearGradientIfOtherNeighborhoodKoeefficientControl
            // 
            this.uiClearGradientIfOtherNeighborhoodKoeefficientControl.Location = new System.Drawing.Point(825, 259);
            this.uiClearGradientIfOtherNeighborhoodKoeefficientControl.MinimumSize = new System.Drawing.Size(15, 15);
            this.uiClearGradientIfOtherNeighborhoodKoeefficientControl.Name = "uiClearGradientIfOtherNeighborhoodKoeefficientControl";
            this.uiClearGradientIfOtherNeighborhoodKoeefficientControl.Size = new System.Drawing.Size(122, 213);
            this.uiClearGradientIfOtherNeighborhoodKoeefficientControl.TabIndex = 91;
            // 
            // uiMainKoeefficientControl
            // 
            this.uiMainKoeefficientControl.Location = new System.Drawing.Point(666, 259);
            this.uiMainKoeefficientControl.MinimumSize = new System.Drawing.Size(15, 15);
            this.uiMainKoeefficientControl.Name = "uiMainKoeefficientControl";
            this.uiMainKoeefficientControl.Size = new System.Drawing.Size(153, 217);
            this.uiMainKoeefficientControl.TabIndex = 90;
            // 
            // uiClearEdgeMapHomeAlonePointKoeefficientControl
            // 
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.Location = new System.Drawing.Point(971, 259);
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.MinimumSize = new System.Drawing.Size(15, 15);
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.Name = "uiClearEdgeMapHomeAlonePointKoeefficientControl";
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.Size = new System.Drawing.Size(128, 229);
            this.uiClearEdgeMapHomeAlonePointKoeefficientControl.TabIndex = 89;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1124, 889);
            this.Controls.Add(this.uiNonMaxPictureBox);
            this.Controls.Add(this.colorKoeefficientControl);
            this.Controls.Add(this.uiClearGradientIfOtherNeighborhoodKoeefficientControl);
            this.Controls.Add(this.uiMainKoeefficientControl);
            this.Controls.Add(this.uiClearEdgeMapHomeAlonePointKoeefficientControl);
            this.Controls.Add(this.uiSpecialPictureBox);
            this.Controls.Add(this.uiGradientPictureBox);
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
            ((System.ComponentModel.ISupportInitialize)(this.uiNonMaxPictureBox)).EndInit();
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
        private System.Windows.Forms.PictureBox uiGradientPictureBox;
        private System.Windows.Forms.PictureBox uiSpecialPictureBox;
        private ClearEdgeMapHomeAlonePointKoeefficientControl uiClearEdgeMapHomeAlonePointKoeefficientControl;
        private MainKoeefficientControl uiMainKoeefficientControl;
        private ClearGradientIfOtherNeighborhoodKoeefficientControl uiClearGradientIfOtherNeighborhoodKoeefficientControl;
        private ColorKoeefficientControl colorKoeefficientControl;
        private System.Windows.Forms.PictureBox uiNonMaxPictureBox;
    }
}

