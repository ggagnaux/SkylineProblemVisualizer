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
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SkylineProblemVisualizer.Controllers;
using SkylineProblemVisualizer.Interfaces;

namespace SkylineProblemVisualizer.UI
{
    public partial class InfoPanel : FormBase, ILogTarget
    {
        public enum DockLocationEnum
        {
            [Description("Not Docked")]
            None = 0,

            [Description("Parent Window - Left Side")]
            ParentLeft,

            [Description("Parent Window - Right Side")]
            ParentRight,
        };

        private static InfoPanel _infoPanel = null;
        public static InfoPanel GetInstance(Form parent, IFormController _controller)
        {
            if (_infoPanel == null)
            {
                _infoPanel = new InfoPanel(parent, _controller);
            }
            return _infoPanel;
        }


        #region Properties
        public UserSettings UserSettings
        {
            get { return ((MainFormController)Controller).UserSettings; }
        }
        public IList<BuildingCoordinates> Data { get; set; }
        private DockLocationEnum _dockLocation;
        public DockLocationEnum DockLocation
        {
            get
            {
                return _dockLocation;
            }
            set
            {
                _dockLocation = value;
                DockToParent();
            }
        }
        private string MouseCoordinates
        {
            set
            {
                labelMousePosition.Text = value;
            }
        }
        private string ZoomLevel
        {
            set
            {
                labelZoomLevel.Text = value;
            }
        }
        private Point InitialPosition { get; set; }
        #endregion

        #region Constructor(s)
        private InfoPanel(Form parent, IFormController _controller) : base(_controller)
        {
            Init(parent);

            Initialize();
        }
        #endregion

        #region Private Methods

        public override void Initialize()
        {
            base.Initialize();
        }

        private void Init(Form parent)
        {
            InitializeComponent();
            this.Owner = parent;

            InitialPosition = new Point(UserSettings.InfoPanelPositionX, UserSettings.InfoPanelPositionY);
            DockLocation = (DockLocationEnum)UserSettings.InfoPanelDockingLocation;

            // Tell the logger that we want to output log entries to a control in the dialog.
            // This will usually be a TextBox or TextArea control.
            AddLogTarget(this);

            //InitLogFileWatcher();
        }

        //private void InitLogFileWatcher()
        //{
        //    fileSystemWatcher1.Path = @"D:\Temp\InternalSource\COMP3761\A3\SkylineProblemVisualizer\SkylineProblemVisualizer\bin\Debug\";
        //    fileSystemWatcher1.Filter = "primary.log";

        //    // Add event handlers.
        //    fileSystemWatcher1.Changed += new FileSystemEventHandler(OnChanged);
        //    fileSystemWatcher1.Created += new FileSystemEventHandler(OnChanged);
        //    fileSystemWatcher1.Deleted += new FileSystemEventHandler(OnChanged);

        //    // Start monitoring.
        //    fileSystemWatcher1.EnableRaisingEvents = false;

        //}
        #endregion

        #region Event Handlers
        protected override void OnLoad(EventArgs e)
        {
            SetMouseCoordinates(new Point(500, 500));
            SetZoomLevel(100);

            UserSettings.PropertyChanged += UserSettings_PropertyChanged;

            base.OnLoad(e);
        }

        private void UserSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.UserSettingsChanged(sender, e);
        }

        private void textBoxProgramLog_TextChanged(object sender, EventArgs e)
        {
            //ScrollBars txtProgress.ScrollToLine(txtProgress.LineCount - 1);
            var scrollBars = textBoxProgramLog.ScrollBars;

            textBoxProgramLog.SelectionStart = textBoxProgramLog.Text.Length;
            //textBoxProgramLog.ScrollToCaret();
        }

        private void InfoPanel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (UserSettings.SaveInfoPanelPosition == true)
            {
                UserSettings.InfoPanelPosition = this.Location;
            }
        }
        #endregion

        #region Public Methods
        public void SetData(IList<BuildingCoordinates> data)
        {
            this.Data = data;

            ListView lv = listViewData;

            // Clear old data and load new data
            lv.Clear();

            // Create the columns
            lv.Columns.Add("Left");
            lv.Columns.Add("Height");
            lv.Columns.Add("Right");

            // Populate Listbox
            foreach (var a in Data)
            {
                string[] output = {a.Left.ToString(),
                                   a.Height.ToString(),
                                   a.Right.ToString()};
                lv.Items.Add(new ListViewItem(output));
            }
        }

        public void SetMouseCoordinates(Point p)
        {
            MouseCoordinates = string.Format("{0,22}", p.X.ToString() + " x " + p.Y.ToString());
        }

        public void SetZoomLevel(float _zoomLevel)
        {
            var zoomLevel = string.Format("{0}", (int)_zoomLevel);
            string s = $"{zoomLevel}%";
            s = string.Format("{0,11}", s);
            ZoomLevel = s;
        }

        public void DockToParent()
        {
            // Current parent metrics
            Point parentLocation = Owner.Location;
            int parentWidth = Owner.Width;

            // My Width
            int myWidth = this.Width;

            // The destination starting point
            int x, y;
            Point theLocation = new Point(0, 0);

            switch (this._dockLocation) {
                case DockLocationEnum.None:
                    this.Location = InitialPosition;
                    break;

                case DockLocationEnum.ParentLeft:
                    theLocation.X = parentLocation.X - myWidth;
                    theLocation.Y = parentLocation.Y;
                    Location = theLocation;
                    break;

                case DockLocationEnum.ParentRight:
                default:
                    theLocation.X = parentLocation.X + parentWidth;
                    theLocation.Y = parentLocation.Y;
                    Location = theLocation;
                    break;
            }
        }

        public void Show(bool show)
        {
            if (show)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }

        public new void Show()
        {
            base.Show();
            DockToParent();
        }

        public new void Hide()
        {
            base.Hide();
        }

        public void LogToControl(string text)
        {
            textBoxProgramLog.Text += text + Environment.NewLine;
        }
        #endregion
    }
}
