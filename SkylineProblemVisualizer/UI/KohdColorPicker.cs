using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkylineProblemVisualizer.UI
{
    [System.ComponentModel.DefaultBindingProperty("Text")]
    public partial class KohdColorPicker : UserControl
    {
        [Bindable(true)]
        [DefaultValue("FF0000")]
        public new string Text
        {
            get
            {
                return textBoxColorRGBHex.Text;
            }

            set
            {
                if (value != textBoxColorRGBHex.Text.Trim())
                {
                    textBoxColorRGBHex.Text = value;
                }
            }
        }

        private Color _currentColor;
        public Color CurrentColor
        {
            get
            {
                if (_currentColor == null) { _currentColor = Color.Red; }
                return _currentColor;
            }

            set
            {
                _currentColor = value;
                string colorText = KohdAndArt.Toolkit.ColorUtilities.ConvertColorToHexRGBString(_currentColor);
                this.Text = colorText;
                buttonSelectColor.BackColor = _currentColor;
            }
        }

        public KohdColorPicker()
        {
            InitializeComponent();

            buttonSelectColor.BackColor = CurrentColor;
        }

        private void buttonSelectColor_Click(object sender, EventArgs e)
        {
            colorDialog1.AllowFullOpen = true;
            colorDialog1.Color = CurrentColor;
            if (colorDialog1.ShowDialog() == DialogResult.OK)
            {
                CurrentColor = colorDialog1.Color;
            }           
        }
    }
}
