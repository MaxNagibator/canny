using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CannyProject
{
    public partial class MainForm : Form
    {
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
                              RestoreDirectory = true
                          };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    uiInputImagePictureBox.Image = Image.FromFile(ofd.FileName);
                    Calculate();
                }
                catch (ApplicationException ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ForLightDevelop()
        {
            var imagePath = "D:\\мои документы\\Visual Studio 2012\\Projects\\Diplom\\canny\\Images\\x_e7da9276.jpg";
            uiInputImagePictureBox.Image = Image.FromFile(imagePath);
        }

        private void Calculate()
        {
            var th = (float)Convert.ToDouble(uiHighThresholdTextBox.Text);
            var tl = (float)Convert.ToDouble(uiLowThresholdTextBox.Text);
            var maskSize = Convert.ToInt32(uiGaussianMaskSizeTextBox.Text);
            var sigma = (float)Convert.ToDouble(uiSigmaTextBox.Text);
            var shift = (float)Convert.ToDouble(uiShiftTextBox.Text);
            var shiftSize = (int)Convert.ToDouble(uiShiftSizeTextBox.Text);
            var cannyData = new Canny((Bitmap)uiInputImagePictureBox.Image, th, tl, maskSize, sigma, shift, shiftSize);
            uiGaussianFilteredImagePictureBox.Image = cannyData.GetDisplayedImage(cannyData.GaussianFilterImage);
            uiFinalCannyPictureBox.Image = cannyData.GetDisplayedImage(cannyData.EdgeMap);
            uiGnhPictureBox.Image = cannyData.GetDisplayedImage(cannyData.GNH);
            uiGnlPictureBox.Image = cannyData.GetDisplayedImage(cannyData.GNL);
        }

        private void uiCalcButton_Click(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
