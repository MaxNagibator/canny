using System;

namespace CannyProject.KoeeficientClasses.Gui
{
    public partial class ColorKoeefficientControl : GroupBoxWithSpoilerControl
    {
        public ColorKoeefficientControl()
        {
            InitializeComponent();
            SetName("Color koeeficient");
        }

        public ColorKoeefficient GetKoeefficients()
        {
            var k = new ColorKoeefficient
                    {
                        IsNeedApply = Convert.ToBoolean(uiIsNeedApplyCheckBox.Checked),
                        IsNeedRed = Convert.ToBoolean(uiRedCheckBox.Checked),
                        IsNeedGreen = Convert.ToBoolean(uiGreenCheckBox.Checked),
                        IsNeedBlue = Convert.ToBoolean(uiBlueCheckBox.Checked),
                    };
            return k;
        }
    }
}
