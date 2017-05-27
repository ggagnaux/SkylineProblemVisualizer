#region Copyright (c) 2017 G. Gagnaux, https://github.com/ggagnaux/SkylineProblemVisualizer
/*
SkylineProblemVisualizer - An application to visualize the skyline algorithm problem

Copyright (c) 2017 G. Gagnaux, https://github.com/ggagnaux/SkylineProblemVisualizer

Permission is hereby granted, free of charge, to any person obtaining a copy of 
this software and associated documentation files (the "Software"), to deal in the 
Software without restriction, including without limitation the rights to use, copy, 
modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, 
and to permit persons to whom the Software is furnished to do so, subject to the 
following conditions:

The above copyright notice and this permission notice shall be included in 
all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A 
PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT 
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF 
CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE 
OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.ComponentModel;
using System.Drawing;
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
