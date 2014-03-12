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
                        MaxHysteresisThresh = (float) Convert.ToDouble(uiHighThresholdTextBox.Text),
                        MinHysteresisThresh = (float) Convert.ToDouble(uiLowThresholdTextBox.Text),
                        KernelSize = Convert.ToInt32(uiGaussianMaskSizeTextBox.Text),
                        Sigma = (float) Convert.ToDouble(uiSigmaTextBox.Text),
                    };
            return k;
        }
    }
}
