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
using System.Reflection;
using System.Windows.Forms;
using KohdAndArt.Toolkit.Sys;
using SkylineProblemVisualizer.Interfaces;

namespace SkylineProblemVisualizer.UI
{
    partial class AboutBox : FormBase
    {
        // Need to tell the utility class that this is the assembly 
        private static AssemblyUtilities assemblyUtilities = new AssemblyUtilities(Assembly.GetExecutingAssembly());

        public struct SoftwareDetails
        {
            public string Description;
            public string Copyright;
            public string Url;
        }

        private List<SoftwareDetails> _softwareDetails = new List<SoftwareDetails>()
        {
            new SoftwareDetails()
            {
                Description = assemblyUtilities.AssemblyDescription,
                Copyright = assemblyUtilities.AssemblyCopyright,
                Url = @"https://github.com/ggagnaux/SkylineProblemVisualizer"
            },
        };

        private List<SoftwareDetails> _thirdPartyDetails = new List<SoftwareDetails>()
        {
            new SoftwareDetails()
            {
                Description = "MetroFramework - Modern UI for WinForms",
                Copyright = "Copyright (c) 2013 - Jens Thiel",
                Url = @"https://github.com/thielj/MetroFramework"
            },
            new SoftwareDetails()
            {
                Description = "Apache Log4Net (tm) - Logging Services",
                Copyright = "Copyright (c) 2004-20017 - Apache Software Foundation",
                Url = @"https://logging.apache.org/log4net/"
            },
        };

        public AboutBox(Form parent, IFormController _controller) : base(_controller)
        {
            InitializeComponent();

            this.Text = $"About {assemblyUtilities.AssemblyTitle} {assemblyUtilities.AssemblyVersion}";
            this.textBoxDescription.Text = BuildSoftwareDetails(_softwareDetails);
            this.textBoxThirdpartyComponents.Text = BuildSoftwareDetails(_thirdPartyDetails);
        }

        private string BuildSoftwareDetails(List<SoftwareDetails> _details)
        {
            var output = string.Empty;
            foreach (var detail in _details)
            {
                output += detail.Description + Environment.NewLine;
                output += detail.Copyright + Environment.NewLine;
                output += detail.Url + Environment.NewLine + Environment.NewLine;
            }
            return output;
        }


        // TODO - Need to get rid of border still.
        private void textBoxDescription_CustomPaint(object sender, MetroFramework.Drawing.MetroPaintEventArgs e)
        {
            //int width = ((MetroFramework.Controls.MetroTextBox)sender).Width;
            //int height = ((MetroFramework.Controls.MetroTextBox)sender).Height;

            ////e.Graphics.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Black), new Rectangle(0, 0, width, height));
            //e.Graphics.FillRectangle(new SolidBrush(Color.Green), new Rectangle(0, 0, width, height));

            return;
        }

        // TODO - Move to library
        private void OpenLink(string linkUrl)
        {
            System.Diagnostics.Process.Start(linkUrl);
        }

        private void textBoxDescription_CustomPaintBackground(object sender, MetroFramework.Drawing.MetroPaintEventArgs e)
        {
            int width = ((MetroFramework.Controls.MetroTextBox)sender).Width;
            int height = ((MetroFramework.Controls.MetroTextBox)sender).Height;

            //e.Graphics.DrawRectangle(new System.Drawing.Pen(System.Drawing.Color.Black), new Rectangle(0, 0, width, height));
            e.Graphics.FillRectangle(new SolidBrush(Color.Blue), new Rectangle(0, 0, width, height));

            return;
        }

        private void textBoxDescription_CustomPaintForeground(object sender, MetroFramework.Drawing.MetroPaintEventArgs e)
        {
            int width = ((MetroFramework.Controls.MetroTextBox)sender).Width;
            int height = ((MetroFramework.Controls.MetroTextBox)sender).Height;

            Rectangle newRect = new Rectangle(0, 0, width, height);
            newRect.Inflate(-10, -10);
            e.Graphics.FillRectangle(new SolidBrush(Color.Transparent), newRect);


            //return;
        }

        private void textBoxDescription_Paint(object sender, PaintEventArgs e)
        {
            return;
        }
    }
}
