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
            var imagePath = "D:\\мои документы\\Visual Studio 2012\\Projects\\Diplom\\canny\\Images\\x_e7da9276.jpg";
            uiInputImagePictureBox.Image = Image.FromFile(imagePath);
            fileNames = new[] {imagePath};
        }

        private void Calculate()
        {
            foreach (var fileName in fileNames)
            {

                var th = (float) Convert.ToDouble(uiHighThresholdTextBox.Text);
                var tl = (float) Convert.ToDouble(uiLowThresholdTextBox.Text);
                var maskSize = Convert.ToInt32(uiGaussianMaskSizeTextBox.Text);
                var sigma = (float) Convert.ToDouble(uiSigmaTextBox.Text);
                var shift = Convert.ToInt32(uiShiftTextBox.Text);
                var size = (int) Convert.ToDouble(uiSizeTextBox.Text);
                var koefficient1 = (float)Convert.ToDouble(uiKoefficient1TextBox.Text);
                var koefficient2 = (float)Convert.ToDouble(uiKoefficient2TextBox.Text);
                var koefficient3 = (float)Convert.ToDouble(uiKoefficient3TextBox.Text);
                uiInputImagePictureBox.Image = Image.FromFile(fileName);
                var cannyData = new Canny((Bitmap) uiInputImagePictureBox.Image, th, tl, maskSize, sigma, shift, size,
                    koefficient1,koefficient2,koefficient3);
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
