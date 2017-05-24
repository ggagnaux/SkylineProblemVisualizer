using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylineProblemWinforms
{
    public class SkylineSettings : ApplicationSettingsBase, INotifyPropertyChanged
    {
        #region Properties
        private string defaultDataFile;
        public string DefaultDataFile
        {
            get { return defaultDataFile; }
            set
            {
                defaultDataFile = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("DefaultDataFile"));
            }
        }

        private bool highlightSkyline;
        public bool HighlightSkyline
        {
            get { return highlightSkyline; }
            set
            {
                highlightSkyline = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("HighlightSkyline"));
            }
        }


        private string skylineBorderColorRGB;
        public string SkylineBorderColorRGB
        {
            get { return skylineBorderColorRGB; }
            set
            {
                skylineBorderColorRGB = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("SkylineBorderColorRGB"));
            }
        }

        private bool showCoordinates;
        public bool ShowCoordinates
        {
            get { return showCoordinates; }
            set
            {
                showCoordinates = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("ShowCoordinates"));
            }
        }

        private bool showXAxis;
        public bool ShowXAxis
        {
            get { return showXAxis; }
            set
            {
                showXAxis = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("ShowXAxis"));
            }
        }

        private bool showYAxis;
        public bool ShowYAxis
        {
            get { return showYAxis; }
            set
            {
                showYAxis = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("ShowYAxis"));
            }
        }

        private int canvasMargin;
        public int CanvasMargin
        {
            get { return canvasMargin; }
            set
            {
                canvasMargin = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("CanvasMargin"));
            }
        }

        private string canvasBackgroundColorRGB;
        public string CanvasBackgroundColorRGB
        {
            get { return canvasBackgroundColorRGB; }
            set
            {
                canvasBackgroundColorRGB = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("CanvasBackgroundColorRGB"));
            }
        }

        private bool showDataPointWindow;
        public bool ShowDataPointWindow
        {
            get { return showDataPointWindow; }
            set
            {
                showDataPointWindow = value;
                InvokePropertyChanged(new PropertyChangedEventArgs("ShowDataPointWindow"));
            }
        }

        #endregion


        public event PropertyChangedEventHandler PropertyChanged;
        public void InvokePropertyChanged(PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, e);
        }
    }
}
