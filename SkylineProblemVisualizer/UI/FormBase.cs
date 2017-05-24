using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework;
using MetroFramework.Forms;
using SkylineProblemVisualizer.Controllers;
using SkylineProblemVisualizer.Interfaces;
using SkylineProblemVisualizer.Utilities;

namespace SkylineProblemVisualizer.UI
{
    public partial class FormBase : MetroForm, ILoggable
    {
        private const double _DefaultOpacity = 1.0D;

        private double _formOpacity = _DefaultOpacity;
        public double FormOpacity
        {
            get
            {
                return _formOpacity;
            }
            set
            {
                if (_formOpacity >= 0.1 && _formOpacity <= 1.0)
                {
                    _formOpacity = value;
                    this.Opacity = _formOpacity;
                }
            }
        }

        private IFormController _controller;
        public MainFormController Controller
        {
            get
            {
                return (MainFormController)this._controller;
            }
            set
            {
                this._controller = (MainFormController)value;
            }
        }


        public FormBase(IFormController _controller)
        {
            if (_controller == null)
            {
                string msg = "The FormBase() constructor requires an IFormController object.";
                LogHelper.LogFatal(msg);
                throw new ArgumentNullException(msg);
            } 

            this.Controller = _controller as MainFormController;
        }

        // For Designer Only
        private FormBase() {}

        //
        // ILoggable Implementation
        //
        public void AddLogTarget(ILogTarget target) { LogHelper.AddLogTarget(target); }
        public void Log(string msg) { LogHelper.Log(msg); }
        public void LogError(string msg) { LogHelper.Log(msg); }
        public void LogException(string msg, Exception ex) { LogHelper.Log(msg); }
        public void LogMessage(string msg) { LogHelper.Log(msg); }

        public virtual void Initialize()
        {
            try
            {
                // Use double buffering to reduce flicker.
                this.SetStyle(
                    ControlStyles.ResizeRedraw |
                    ControlStyles.AllPaintingInWmPaint |
                    ControlStyles.UserPaint |
                    ControlStyles.DoubleBuffer,
                    true);
                this.UpdateStyles();

                this.TopMost = Controller.UserSettings.MakeTopMostWindow;
                this.SetTheme(Controller.UserSettings.ActiveTheme);
                this.FormOpacity = _DefaultOpacity;
                this.Refresh();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        public void ShowDialogTopMost()
        {
            this.ShowDialog(true);
        }

        public void ShowDialog(bool topMost)
        {
            this.TopMost = topMost;
            base.ShowDialog();
        }

        public void SetTheme(int theme)
        {
            var propertyName = "Theme";
            var t = (MetroFramework.MetroThemeStyle)theme;

            // Base Page
            if (this.HasProperty(propertyName))
            {
                this.Theme = t;
            }

            // All Children
            var children = this.GetAll();
            foreach (var child in children)
            {
                if (child.HasProperty(propertyName))
                {
                    child.SetPropertyValue(propertyName, t);
                }
            }
        }

        public virtual void UserSettingsChanged(object o, EventArgs e)
        {
            this.TopMost = ((UserSettings)o).MakeTopMostWindow;
            SetTheme(((UserSettings)o).ActiveTheme);
            this.Refresh();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // FormBase
            // 
            this.ClientSize = new System.Drawing.Size(300, 300);
            this.Name = "FormBase";
            this.ResumeLayout(false);
        }

        protected override void OnLoad(EventArgs e)
        {
            Initialize();
            base.OnLoad(e);
        }
    }
}
