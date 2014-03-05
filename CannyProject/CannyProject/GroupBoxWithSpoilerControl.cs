using System;
using System.Drawing;
using System.Windows.Forms;
using CannyProject.Properties;

namespace CannyProject
{
    public partial class GroupBoxWithSpoilerControl : UserControl
    {
        private const int VERTICAL_INDENTATION = 6;
        private const int HORIZONTAL_INDENTATION = 6;
        private const int SPOILER_HEIGHT = 12;
        private int _expandHeight;
        private bool _isExpand = true;

        public GroupBoxWithSpoilerControl()
        {
            InitializeComponent();
            uiMainGroupBox.Width = Width - HORIZONTAL_INDENTATION;
            uiMainGroupBox.Height = Height - VERTICAL_INDENTATION - SPOILER_HEIGHT;
        }

        private void GroupBoxWithSpoilerControl_SizeChanged(object sender, EventArgs e)
        {
            uiMainGroupBox.Width = Width - HORIZONTAL_INDENTATION;
            uiMainGroupBox.Height = Height - VERTICAL_INDENTATION - SPOILER_HEIGHT;
            uiSpoilerPanel.Width = Width - HORIZONTAL_INDENTATION;
            uiSpoilerSlipPictureBox.Location = new Point(uiSpoilerPanel.Width - 13, 2);
        }

        public void SetName(string name)
        {
            uiNameLabel.Text = name;
        }

        private void uiSpoiler_MouseClick(object sender, MouseEventArgs e)
        {
            if (_isExpand)
            {
                Collapse();
            }
            else
            {
                Expand();
            }
        }

        public void Collapse()
        {
            SetSpoilerImageByName("spoilerIco");
            _expandHeight = Height;
            Height = VERTICAL_INDENTATION + SPOILER_HEIGHT;
            _isExpand = false;
        }

        public void Expand()
        {
            SetSpoilerImageByName("spoilerIcoRevert");
            Height = _expandHeight;
            _isExpand = true;
        }

        private void SetSpoilerImageByName(string name)
        {
            var resourceManager = Resources.ResourceManager;
            uiSpoilerSlipPictureBox.Image = (Bitmap) resourceManager.GetObject(name);
        }
    }
}
