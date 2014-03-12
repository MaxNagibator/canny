namespace CannyProject.KoeeficientClasses.Gui
{
    partial class ColorKoeefficientControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.uiIsNeedApplyCheckBox = new System.Windows.Forms.CheckBox();
            this.uiRedCheckBox = new System.Windows.Forms.CheckBox();
            this.uiGreenCheckBox = new System.Windows.Forms.CheckBox();
            this.uiBlueCheckBox = new System.Windows.Forms.CheckBox();
            this.uiMainGroupBox.SuspendLayout();
            this.uiSpoilerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpoilerSlipPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uiMainGroupBox
            // 
            this.uiMainGroupBox.Controls.Add(this.uiBlueCheckBox);
            this.uiMainGroupBox.Controls.Add(this.uiGreenCheckBox);
            this.uiMainGroupBox.Controls.Add(this.uiRedCheckBox);
            this.uiMainGroupBox.Controls.Add(this.uiIsNeedApplyCheckBox);
            this.uiMainGroupBox.Size = new System.Drawing.Size(136, 142);
            // 
            // uiSpoilerPanel
            // 
            this.uiSpoilerPanel.Size = new System.Drawing.Size(136, 15);
            // 
            // uiSpoilerSlipPictureBox
            // 
            this.uiSpoilerSlipPictureBox.Location = new System.Drawing.Point(123, 2);
            // 
            // uiIsNeedApplyCheckBox
            // 
            this.uiIsNeedApplyCheckBox.AutoSize = true;
            this.uiIsNeedApplyCheckBox.Location = new System.Drawing.Point(17, 19);
            this.uiIsNeedApplyCheckBox.Name = "uiIsNeedApplyCheckBox";
            this.uiIsNeedApplyCheckBox.Size = new System.Drawing.Size(92, 17);
            this.uiIsNeedApplyCheckBox.TabIndex = 108;
            this.uiIsNeedApplyCheckBox.Text = "IsNeedApply?";
            this.uiIsNeedApplyCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.uiRedCheckBox.AutoSize = true;
            this.uiRedCheckBox.Location = new System.Drawing.Point(17, 59);
            this.uiRedCheckBox.Name = "uiRedCheckBox";
            this.uiRedCheckBox.Size = new System.Drawing.Size(46, 17);
            this.uiRedCheckBox.TabIndex = 109;
            this.uiRedCheckBox.Text = "Red";
            this.uiRedCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            this.uiGreenCheckBox.AutoSize = true;
            this.uiGreenCheckBox.Location = new System.Drawing.Point(17, 82);
            this.uiGreenCheckBox.Name = "uiGreenCheckBox";
            this.uiGreenCheckBox.Size = new System.Drawing.Size(55, 17);
            this.uiGreenCheckBox.TabIndex = 110;
            this.uiGreenCheckBox.Text = "Green";
            this.uiGreenCheckBox.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            this.uiBlueCheckBox.AutoSize = true;
            this.uiBlueCheckBox.Location = new System.Drawing.Point(17, 105);
            this.uiBlueCheckBox.Name = "uiBlueCheckBox";
            this.uiBlueCheckBox.Size = new System.Drawing.Size(47, 17);
            this.uiBlueCheckBox.TabIndex = 111;
            this.uiBlueCheckBox.Text = "Blue";
            this.uiBlueCheckBox.UseVisualStyleBackColor = true;
            // 
            // ColorKoeefficientControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "ColorKoeefficientControl";
            this.Size = new System.Drawing.Size(142, 160);
            this.uiMainGroupBox.ResumeLayout(false);
            this.uiMainGroupBox.PerformLayout();
            this.uiSpoilerPanel.ResumeLayout(false);
            this.uiSpoilerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpoilerSlipPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox uiBlueCheckBox;
        private System.Windows.Forms.CheckBox uiGreenCheckBox;
        private System.Windows.Forms.CheckBox uiRedCheckBox;
        private System.Windows.Forms.CheckBox uiIsNeedApplyCheckBox;


    }
}
