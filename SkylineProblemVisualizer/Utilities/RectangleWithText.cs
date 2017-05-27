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
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylineProblemVisualizer.Utilities
{
    internal class RectangleWithText
    {
        RectangleF m_extent = new RectangleF();
        string m_text = "";

        Font m_textFont = null;
        RectangleF m_textRect = new RectangleF();

        public RectangleWithText(RectangleF extent, string text)
        {
            m_extent = extent;
            m_text = text;
        }

        public void Draw(Graphics g)
        {
            //var dashedGrayPen = new Pen(Color.Gray, 1.0f / g.DpiX) { DashStyle = DashStyle.Dash };
            //var brownPen = new Pen(Color.White, 1.0f / g.DpiX);

            //// Draw rectangle itself
            //g.DrawRectangle(dashedGrayPen, m_extent.X, m_extent.Y, m_extent.Width, m_extent.Height);

            // Draw text on it
            var extentCenter = new PointF((m_extent.Left + m_extent.Right) / 2, (m_extent.Bottom + m_extent.Top) / 2);
            DrawText(g, m_text, extentCenter, m_extent);
        }

        private void DrawText(Graphics g, string text, PointF ptStart, RectangleF extent)
        {
            var gs = g.Save();

            // Inverse Y axis again - now it grow down;
            // if we don't do this, text will be drawn inverted
            g.ScaleTransform(1.0f, -1.0f, MatrixOrder.Prepend);

            if (m_textFont == null)
            {
                //m_textFont = new Font("Arial", 150.0f/g.DpiX, FontStyle.Regular, GraphicsUnit.Pixel);


                // Find the maximum appropriate text size to fix the extent
                float fontSize = 100.0f;
                Font fnt;
                SizeF textSize;
                do
                {
                    fnt = new Font("Arial", fontSize / g.DpiX, FontStyle.Regular, GraphicsUnit.Pixel);
                    textSize = g.MeasureString(text, fnt);
                    m_textRect = new RectangleF(new PointF(ptStart.X - textSize.Width / 2.0f, -ptStart.Y - textSize.Height / 2.0f), textSize);

                    var textRectInv = new RectangleF(m_textRect.X, -m_textRect.Y, m_textRect.Width, m_textRect.Height);
                    if (extent.Contains(textRectInv))
                        break;

                    fontSize -= 1.0f;
                    if (fontSize <= 0)
                    {
                        fontSize = 1.0f;
                        break;
                    }
                } while (true);

                m_textFont = fnt;
            }

            // Create a StringFormat object with the each line of text, and the block of text centered on the page
            var stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };
            //m_textFont = new Font(FontFamily.GenericSansSerif, 2.0f, FontStyle.Regular);
            g.DrawString(text, m_textFont, Brushes.White, m_textRect, stringFormat);

            g.Restore(gs);
        }
    }
}
