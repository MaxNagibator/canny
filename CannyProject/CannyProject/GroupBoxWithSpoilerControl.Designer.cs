namespace CannyProject
{
    partial class GroupBoxWithSpoilerControl
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
            this.uiMainGroupBox = new System.Windows.Forms.GroupBox();
            this.uiSpoilerPanel = new System.Windows.Forms.Panel();
            this.uiSpoilerSlipPictureBox = new System.Windows.Forms.PictureBox();
            this.uiNameLabel = new System.Windows.Forms.Label();
            this.uiSpoilerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpoilerSlipPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // uiMainGroupBox
            // 
            this.uiMainGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiMainGroupBox.Location = new System.Drawing.Point(3, 16);
            this.uiMainGroupBox.Name = "uiMainGroupBox";
            this.uiMainGroupBox.Size = new System.Drawing.Size(211, 198);
            this.uiMainGroupBox.TabIndex = 0;
            this.uiMainGroupBox.TabStop = false;
            // 
            // uiSpoilerPanel
            // 
            this.uiSpoilerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSpoilerPanel.BackColor = System.Drawing.Color.DarkGray;
            this.uiSpoilerPanel.Controls.Add(this.uiSpoilerSlipPictureBox);
            this.uiSpoilerPanel.Controls.Add(this.uiNameLabel);
            this.uiSpoilerPanel.Location = new System.Drawing.Point(3, 3);
            this.uiSpoilerPanel.Name = "uiSpoilerPanel";
            this.uiSpoilerPanel.Size = new System.Drawing.Size(211, 15);
            this.uiSpoilerPanel.TabIndex = 0;
            this.uiSpoilerPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uiSpoiler_MouseClick);
            // 
            // uiSpoilerSlipPictureBox
            // 
            this.uiSpoilerSlipPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.uiSpoilerSlipPictureBox.BackColor = System.Drawing.Color.DarkGray;
            this.uiSpoilerSlipPictureBox.Image = global::CannyProject.Properties.Resources.spoilerIcoRevert;
            this.uiSpoilerSlipPictureBox.InitialImage = null;
            this.uiSpoilerSlipPictureBox.Location = new System.Drawing.Point(198, 2);
            this.uiSpoilerSlipPictureBox.Name = "uiSpoilerSlipPictureBox";
            this.uiSpoilerSlipPictureBox.Size = new System.Drawing.Size(11, 11);
            this.uiSpoilerSlipPictureBox.TabIndex = 2;
            this.uiSpoilerSlipPictureBox.TabStop = false;
            this.uiSpoilerSlipPictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uiSpoiler_MouseClick);
            // 
            // uiNameLabel
            // 
            this.uiNameLabel.AutoSize = true;
            this.uiNameLabel.BackColor = System.Drawing.Color.DarkGray;
            this.uiNameLabel.Location = new System.Drawing.Point(3, 1);
            this.uiNameLabel.Name = "uiNameLabel";
            this.uiNameLabel.Size = new System.Drawing.Size(69, 13);
            this.uiNameLabel.TabIndex = 1;
            this.uiNameLabel.Text = "uiNameLabel";
            this.uiNameLabel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.uiSpoiler_MouseClick);
            // 
            // GroupBoxWithSpoilerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiSpoilerPanel);
            this.Controls.Add(this.uiMainGroupBox);
            this.MinimumSize = new System.Drawing.Size(15, 15);
            this.Name = "GroupBoxWithSpoilerControl";
            this.Size = new System.Drawing.Size(217, 217);
            this.SizeChanged += new System.EventHandler(this.GroupBoxWithSpoilerControl_SizeChanged);
            this.uiSpoilerPanel.ResumeLayout(false);
            this.uiSpoilerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uiSpoilerSlipPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.GroupBox uiMainGroupBox;
        protected System.Windows.Forms.Panel uiSpoilerPanel;
        protected internal System.Windows.Forms.PictureBox uiSpoilerSlipPictureBox;
        protected System.Windows.Forms.Label uiNameLabel;
    }
}
