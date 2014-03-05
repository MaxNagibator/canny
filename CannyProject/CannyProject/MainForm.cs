﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace CannyProject
{
    public partial class MainForm : Form
    {
        private bool _switcher = true;
        private string[] fileNames;
        public MainForm()
        {
            InitializeComponent();
            ForLightDevelop();
        }

        private void uiOpenImageToolStripLabel_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
                          {
                              Filter =
                                  "Bitmap files (*.bmp)|*.bmp|PNG files (*.png)|*.png|TIFF files (*.tif)|*tif|JPEG files (*.jpg)|*.jpg |All files (*.*)|*.*",
                              FilterIndex = 5,
                              RestoreDirectory = true,
                              Multiselect = true
                          };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    fileNames = ofd.FileNames;
                    Calculate();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ForLightDevelop()
        {
            var imagePath = "..\\..\\..\\..\\..\\canny\\Images\\x_e7da9276.jpg";
            uiInputImagePictureBox.Image = Image.FromFile(imagePath);
            fileNames = new[] {imagePath};
        }

        private void Calculate()
        {
            foreach (var fileName in fileNames)
            {
                var shift = Convert.ToInt32(uiShiftTextBox.Text);
                var size = (int) Convert.ToDouble(uiSizeTextBox.Text);
                var koefficient1 = (float)Convert.ToDouble(uiKoefficient1TextBox.Text);
                uiInputImagePictureBox.Image = Image.FromFile(fileName);
                _switcher = !_switcher;
                var mainKoeefficient = uiMainKoeefficientControl.GetKoeefficients();
                var clearEdgeMapHomeAlonePointKoeefficient = uiClearEdgeMapHomeAlonePointKoeefficientControl.GetKoeefficients();
                var cannyData = new Canny((Bitmap)uiInputImagePictureBox.Image, mainKoeefficient, shift, size,
                    koefficient1, clearEdgeMapHomeAlonePointKoeefficient);
                uiGaussianFilteredImagePictureBox.Image = cannyData.GetDisplayedImage(cannyData.GaussianFilterImage);
                uiFinalCannyPictureBox.Image = cannyData.GetDisplayedImage(cannyData.EdgeMap);
                uiGnhPictureBox.Image = cannyData.GetDisplayedImage(cannyData.GNH);
                uiGnlPictureBox.Image = cannyData.GetDisplayedImage(cannyData.GNL);
                uiGradientPictureBox.Image = cannyData.GetDisplayedImage(cannyData.Gradient);
                uiSpecialPictureBox.Image = cannyData.GetDisplayedImage(cannyData.SpecialMatrix);
                var a  = fileName.Substring(0,fileName.LastIndexOf('\\')+1)+"canny_"+fileName.Substring(fileName.LastIndexOf('\\')+1);
                uiFinalCannyPictureBox.Image.Save(a);
            }
        }

        private void uiCalcButton_Click(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
