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
            var imagePath = "D:\\мои документы\\Visual Studio 2012\\Projects\\Diplom ^_^\\canny\\Images\\x_e7da9276.jpg";
            uiInputImagePictureBox.Image = Image.FromFile(imagePath);
        }

        private void Calculate()
        {
            var TH = (float)Convert.ToDouble(TxtTH.Text);
            var TL = (float)Convert.ToDouble(TxtTL.Text);

            var MaskSize = Convert.ToInt32(TxtGMask.Text);
            var Sigma = (float)Convert.ToDouble(TxtSigma.Text);
            var CannyData = new Canny((Bitmap)uiInputImagePictureBox.Image, TH, TL, MaskSize, Sigma);
            uiGaussianFilteredImagePictureBox.Image = CannyData.DisplayImage(CannyData.FilteredImage);

            uiFinalCannyPictureBox.Image = CannyData.DisplayImage(CannyData.EdgeMap);

        }

        private void uiCalcButton_Click(object sender, EventArgs e)
        {
            Calculate();
        }
    }
}
