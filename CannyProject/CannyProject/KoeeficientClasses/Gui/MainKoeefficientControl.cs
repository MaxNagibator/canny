using System;

namespace CannyProject.KoeeficientClasses.Gui
{
    public partial class MainKoeefficientControl : GroupBoxWithSpoilerControl
    {
        public MainKoeefficientControl()
        {
            InitializeComponent();
            SetName("Main");
        }

        public MainKoeefficient GetKoeefficients()
        {
            var k = new MainKoeefficient
                    {
                        maxHysteresisThresh = (float) Convert.ToDouble(uiHighThresholdTextBox.Text),
                        minHysteresisThresh = (float) Convert.ToDouble(uiLowThresholdTextBox.Text),
                        kernelSize = Convert.ToInt32(uiGaussianMaskSizeTextBox.Text),
                        sigma = (float) Convert.ToDouble(uiSigmaTextBox.Text),
                    };
            return k;
        }
    }
}
