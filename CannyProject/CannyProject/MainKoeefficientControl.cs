using System;

namespace CannyProject
{
    public partial class MainKoeefficientControl : GroupBoxWithSpoilerControl
    {
        public MainKoeefficientControl()
        {
            InitializeComponent();
            SetName("ClearEdgeMapHomeAlonePointKoeefficients");
        }

        public ClearEdgeMapHomeAlonePointKoeefficient GetKoeefficients()
        {
            var k = new ClearEdgeMapHomeAlonePointKoeefficient
                    {
                        Width = Convert.ToInt32(uiWidthTextBox.Text),
                        Height = Convert.ToInt32(uiHeightTextBox.Text),
                        Step = Convert.ToInt32(uiStepTextBox.Text),
                        Count = Convert.ToInt32(uiCountTextBox.Text),
                        IsNeedApply = Convert.ToBoolean(uiIsNeedApplyCheckBox.Checked)
                    };
            return k;
        }
    }
}
