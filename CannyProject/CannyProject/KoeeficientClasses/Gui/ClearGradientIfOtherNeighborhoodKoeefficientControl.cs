using System;

namespace CannyProject.KoeeficientClasses.Gui
{
    public partial class ClearGradientIfOtherNeighborhoodKoeefficientControl : GroupBoxWithSpoilerControl
    {
        public ClearGradientIfOtherNeighborhoodKoeefficientControl()
        {
            InitializeComponent();
            SetName("ClearGradientIfOtherNeighborhood");
        }

        public ClearGradientIfOtherNeighborhoodKoeefficient GetKoeefficients()
        {
            var k = new ClearGradientIfOtherNeighborhoodKoeefficient
                    {
                        Shift = Convert.ToInt32(uiShiftTextBox.Text),
                        Size = Convert.ToInt32(uiSizeTextBox.Text),
                        Koefficient1 = Convert.ToInt32(uiKoefficient1TextBox.Text),
                        IsNeedApply = Convert.ToBoolean(uiIsNeedApplyCheckBox.Checked)
                    };
            return k;
        }
    }
}
