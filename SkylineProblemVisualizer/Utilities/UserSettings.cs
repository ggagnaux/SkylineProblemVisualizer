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
using System.Configuration;
using System.Drawing;

namespace SkylineProblemVisualizer
{
    public class UserSettings : ApplicationSettingsBase
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private static UserSettings _settings = null;
        public static UserSettings GetInstance()
        {
            if (_settings == null)
            {
                _settings = new UserSettings();
            }
            return _settings;
        }

        private UserSettings()
        {
        }

        public Point InfoPanelPosition
        {
            get
            {
                return new Point(InfoPanelPositionX, InfoPanelPositionY);
            }
            set
            {
                InfoPanelPositionX = value.X;
                InfoPanelPositionY = value.Y;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("skyline_data.txt")]
        public string DefaultDataFile
        {
            get
            {
                return ((String)this["DefaultDataFile"]);
            }

            set
            {
                this["DefaultDataFile"] = (String)value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public bool ShowXAxis
        {
            get
            {
                return ((bool)this["ShowXAxis"]);
            }

            set
            {
                this["ShowXAxis"] = (bool)value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("2")]
        public int XAxisWidth
        {
            get
            {
                return ((int)this["XAxisWidth"]);
            }

            set
            {
                this["XAxisWidth"] = (int)value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("ff0000")]
        public string XAxisColor
        {
            get
            {
                return (string)this["XAxisColor"];
            }

            set
            {
                this["XAxisColor"] = value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public bool ShowYAxis
        {
            get
            {
                return ((bool)this["ShowYAxis"]);
            }

            set
            {
                this["ShowYAxis"] = (bool)value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("1")]
        public int YAxisWidth
        {
            get
            {
                return ((int)this["YAxisWidth"]);
            }

            set
            {
                this["YAxisWidth"] = (int)value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("ff0000")]
        public string YAxisColor
        {
            get
            {
                return (string)this["YAxisColor"];
            }

            set
            {
                this["YAxisColor"] = value;
            }
        }


        [UserScopedSetting]
        [DefaultSettingValue("False")]
        public bool ShowDataCoordinates
        {
            get
            {
                return ((bool)this["ShowDataCoordinates"]);
            }

            set
            {
                this["ShowDataCoordinates"] = (bool)value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public bool HighlightSkyline
        {
            get
            {
                return ((bool)this["HighlightSkyline"]);
            }

            set
            {
                this["HighlightSkyline"] = (bool)value;
                OnPropertyChanged("HighlightSkyline");
            }
        }


        [UserScopedSetting]
        [DefaultSettingValue("1")]
        public int SkylineBorderWidth
        {
            get
            {
                return ((int)this["SkylineBorderWidth"]);
            }

            set
            {
                this["SkylineBorderWidth"] = (int)value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("30")]
        public int CanvasMarginLeft
        {
            get { return ((int)this["CanvasMarginLeft"]); }
            set { this["CanvasMarginLeft"] = (int)value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("30")]
        public int CanvasMarginRight
        {
            get { return ((int)this["CanvasMarginRight"]); }
            set { this["CanvasMarginRight"] = (int)value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("30")]
        public int CanvasMarginTop
        {
            get { return ((int)this["CanvasMarginTop"]); }
            set { this["CanvasMarginTop"] = (int)value; }
        }

        [UserScopedSetting]
        [DefaultSettingValue("30")]
        public int CanvasMarginBottom
        {
            get { return ((int)this["CanvasMarginBottom"]); }
            set { this["CanvasMarginBottom"] = (int)value; }
        }


        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public bool ShowDataPointWindow
        {
            get
            {
                return ((bool)this["ShowDataPointWindow"]);
            }

            set
            {
                this["ShowDataPointWindow"] = (bool)value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public bool ShowGrid
        {
            get
            {
                return ((bool)this["ShowGrid"]);
            }

            set
            {
                this["ShowGrid"] = (bool)value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("FF0000")]
        public string SkylineBorderColor
        {
            get
            {
                return (string)this["SkylineBorderColor"];
            }

            set
            {
                this["SkylineBorderColor"] = value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("FFFFFF")]
        public string SkylineFillForegroundColor
        {
            get
            {
                return (string)this["SkylineFillForegroundColor"];
            }

            set
            {
                this["SkylineFillForegroundColor"] = value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("FFFFFF")]
        public string SkylineFillBackgroundColor
        {
            get
            {
                return (string)this["SkylineFillBackgroundColor"];
            }

            set
            {
                this["SkylineFillBackgroundColor"] = value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public bool SkylineFillFlag
        {
            get
            {
                return ((bool)this["SkylineFillFlag"]);
            }

            set
            {
                this["SkylineFillFlag"] = (bool)value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("303030")]
        public string GridColor
        {
            get
            {
                return (string)this["GridColor"];
            }

            set
            {
                this["GridColor"] = value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("000010")]
        public string CanvasBackgroundColor
        {
            get
            {
                return (string)this["CanvasBackgroundColor"];
            }

            set
            {
                this["CanvasBackgroundColor"] = value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public bool ShowMouseCoordinates
        {
            get
            {
                return (bool)this["ShowMouseCoordinates"];
            }

            set
            {
                this["ShowMouseCoordinates"] = value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public bool ShowInfoPanel
        {
            get
            {
                return (bool)this["ShowInfoPanel"];
            }

            set
            {
                this["ShowInfoPanel"] = value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public bool SaveInfoPanelPosition
        {
            get
            {
                return (bool)this["SaveInfoPanelPosition"];
            }

            set
            {
                this["SaveInfoPanelPosition"] = value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("0")]
        public int InfoPanelPositionX
        {
            get
            {
                return (int)this["InfoPanelPositionX"];
            }

            set
            {
                this["InfoPanelPositionX"] = value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("0")]
        public int InfoPanelPositionY
        {
            get
            {
                return (int)this["InfoPanelPositionY"];
            }

            set
            {
                this["InfoPanelPositionY"] = value;
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("1")]
        public int InfoPanelDockingLocation
        {
            get
            {
                return (int)this["InfoPanelDockingLocation"];
            }

            set
            {
                this["InfoPanelDockingLocation"] = value;

                // We want to inform all other windows of this event.
                OnPropertyChanged("InfoPanelDockingLocation");
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("True")]
        public bool MakeTopMostWindow
        {
            get
            {
                return (bool)this["MakeTopMostWindow"];
            }

            set
            {
                this["MakeTopMostWindow"] = value;

                // We want to inform all other windows of this event.
                OnPropertyChanged("MakeTopMostWindow");
            }
        }

        [UserScopedSetting]
        [DefaultSettingValue("2")] // 0 = Default, 1 = Light, 2 = Dark
        public int ActiveTheme
        {
            get
            {
                return (int)this["ActiveTheme"];
            }

            set
            {
                this["ActiveTheme"] = value;

                // We want to inform all other windows of this event.
                OnPropertyChanged("ActiveTheme");
            }
        }
    }
}
