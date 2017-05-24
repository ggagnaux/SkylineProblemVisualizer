#region Copyright (c) 2017 Greg Gagnaux, http://www.github.com/ggagnaux/
/*
 
MetroFramework - Windows Modern UI for .NET WinForms applications

Copyright (c) 2017 Greg Gagnaux, http://www.github.com/ggagnaux/

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
 
Portions of this software are (c) 2011 Sven Walter, http://github.com/viperneo

*/
#endregion
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using KohdAndArt.Toolkit.Sys;
using MetroFramework.Forms;
using SkylineProblemVisualizer.Controllers;
using SkylineProblemVisualizer.Interfaces;

namespace SkylineProblemVisualizer.UI
{
    partial class AboutBox : FormBase
    {
        private readonly string _thirdpartyDescription =
            @"'MetroFramework - Modern UI for WinForms', " +
             "Copyright (c) 2013 - Jens Thiel.";
        private readonly string _thirdpartyLink = @"https://github.com/thielj/MetroFramework";
        private readonly string _sourceLink = @"https://github.com/ggagnaux/skyline-problem-winforms";

        public AboutBox(Form parent, IFormController _controller) : base(_controller)
        {
            InitializeComponent();

            // Need to tell the utility class that this is the assembly 
            var util = new AssemblyUtilities(Assembly.GetExecutingAssembly());

            // Set the form values
            this.Text = $"About {util.AssemblyTitle}";
            this.labelProductVersion.Text = $"V{util.AssemblyVersion}";
            this.labelCopyright.Text = util.AssemblyCopyright;
            //this.labelDescription.Text = util.AssemblyDescription;
            this.textBoxDescription.Text = util.AssemblyDescription;
            this.textBoxThirdpartyComponents.Text = _thirdpartyDescription;

            // Initialize the sourcecode link label
            this.linkLabelSource.Text = _sourceLink;
            //this.linkLabelSource.Links.Add(0, _sourceLink.Length, _sourceLink);
            //this.linkLabelSource.LinkClicked += (o, i) =>
            //{
            //    linkLabelSource.LinkVisited = true;
            //    System.Diagnostics.Process.Start(_sourceLink);
            //};

            // Initialize the thirdparty link label
            this.linkLabelThirdparty.Text = _thirdpartyLink;
            //this.linkLabelThirdparty.Links.Add(0, _thirdpartyLink.Length, _thirdpartyLink);
            //this.linkLabelThirdparty.LinkClicked += (o, i) =>
            //{
            //    linkLabelThirdparty.LinkVisited = true;
            //    System.Diagnostics.Process.Start(_thirdpartyLink);
            //};

            //SetTheme(((MainFormController)Controller).UserSettings.ActiveTheme);
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

        private void linkLabelSource_Click(object sender, System.EventArgs e)
        {
            string linkText = ((MetroFramework.Controls.MetroLink)sender).Text;
            OpenLink(linkText);
        }

        private void linkLabelThirdparty_Click(object sender, System.EventArgs e)
        {
            string linkText = ((MetroFramework.Controls.MetroLink)sender).Text;
            OpenLink(linkText);
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
