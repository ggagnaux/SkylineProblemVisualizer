using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Reflection;
using KohdAndArt.Toolkit;
using MetroFramework.Forms;
using SkylineProblemVisualizer.Controllers;
using SkylineProblemVisualizer.Interfaces;
using SkylineProblemVisualizer.UI;
using SkylineProblemVisualizer.Utilities;
using System.Collections.Generic;
using MetroFramework.Components;
using MetroFramework;
using System.Diagnostics;

namespace SkylineProblemVisualizer
{
    public partial class SkylineSettingsManagerForm : FormBase //MetroForm
    {
        //public UserSettings Settings { get; set; }

        public UserSettings UserSettings
        {
            get { return ((MainFormController)Controller).UserSettings; }
        }

        public new MainForm ParentForm
        {
            get { return (MainForm)Owner; } 
        }

        public SkylineSettingsManagerForm(Form parent, IFormController _controller) : base(_controller)
        {
            InitializeComponent();
            this.Owner = parent;
            SetBindings();
        }

        protected override void OnLoad(EventArgs e)
        {
            SetInitialVisibilityStateForUIElements();
            InitializeInfoPanelDockingLocationComboBox((InfoPanel.DockLocationEnum)UserSettings.InfoPanelDockingLocation);
            InitializeUIThemeComboBox((MetroFramework.MetroThemeStyle)UserSettings.ActiveTheme);

            base.OnLoad(e);
        }

        private void SetInitialVisibilityStateForUIElements()
        {
            panelSkylineSettingsGroup.Visible = UserSettings.HighlightSkyline;
            panelXAxisGroup.Visible = UserSettings.ShowXAxis;
            panelYAxisGroup.Visible = UserSettings.ShowYAxis;

            panelSkylineBorderColorSwatch.BackColor = ColorUtilities.GetColorFromHexRGBString(UserSettings.SkylineBorderColor);
            panelCanvasGridColorSwatch.BackColor = ColorUtilities.GetColorFromHexRGBString(UserSettings.GridColor);
            panelCanvasBackgroundColorSwatch.BackColor = ColorUtilities.GetColorFromHexRGBString(UserSettings.CanvasBackgroundColor);
            panelXAxisColorSwatch.BackColor = ColorUtilities.GetColorFromHexRGBString(UserSettings.XAxisColor);
            panelYAxisColorSwatch.BackColor = ColorUtilities.GetColorFromHexRGBString(UserSettings.YAxisColor);

            panelSkylineFillForegroundColorSwatch.BackColor = ColorUtilities.GetColorFromHexRGBString(UserSettings.SkylineFillForegroundColor);
            panelSkylineFillBackgroundColorSwatch.BackColor = ColorUtilities.GetColorFromHexRGBString(UserSettings.SkylineFillBackgroundColor);

            panelInfoBoxDockingLocation.Visible = UserSettings.ShowInfoPanel;

            metroTabControl.SelectTab(0);
        }

        private void InitializeInfoPanelDockingLocationComboBox(InfoPanel.DockLocationEnum location)
        {
            LoadInfoPanelDockingComboBox(comboBoxInfoPanelDockingLocation, (int)location);
        }

        private void InitializeUIThemeComboBox(MetroFramework.MetroThemeStyle themeId)
        {
            LoadUIThemeComboBox(comboBoxUITheme, (int)themeId);
        }

        //
        // This method will fill the docking location combobox
        // using the [Description] attribute of the InfoPanel.DockLocationEnum
        //
        private void LoadInfoPanelDockingComboBox(ComboBox cbo, int selectedIndex)
        {
            cbo.DataSource = Enum.GetValues(typeof(InfoPanel.DockLocationEnum))
                .Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), 
                        typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value)
                .ToList();
            cbo.DisplayMember = "Description";
            cbo.ValueMember = "value";
            cbo.SelectedIndex = selectedIndex;
        }

        //
        // This method will fill the UI Theme combobox
        //
        private void LoadUIThemeComboBox(ComboBox cbo, int selectedIndex)
        {
            cbo.DataSource = Enum.GetValues(typeof(MetroThemeStyle))
                .Cast<Enum>()
                .Select(value => new
                {
                    description = GetUIThemeDescription((MetroThemeStyle)value),
                    value
                })
                .OrderBy(item => item.value)
                .ToList();

            cbo.DisplayMember = "description";
            cbo.ValueMember = "value";
            cbo.SelectedIndex = selectedIndex;
        }

        private string GetUIThemeDescription(MetroThemeStyle index)
        {
            //var themes = MetroStyleManager.Styles.Themes.Keys;
            //while (true)
            //{
            //    string newTheme = themes.ElementAt(rng.Next(themes.Count));
            //    if (newTheme == metroStyleManager.Theme) continue;
            //    metroStyleManager.Theme = newTheme;
            //    return;
            //}

            string desc;
            switch ((int)index)
            {
                case 0:
                default:
                    desc = "Default";
                    break;
                case 1:
                    desc = "Light";
                    break;
                case 2:
                    desc = "Dark";
                    break;
            }
            return desc;
        }


        private void SetBindings()
        {
            // Skyline Settings

            this.checkBoxHighlightSkyline.DataBindings.Add("Checked", UserSettings, "HighlightSkyline", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxSkylineBorderWidth.DataBindings.Add("Text", UserSettings, "SkylineBorderWidth", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxSkylineBorderColor.DataBindings.Add("Text", UserSettings, "SkylineBorderColor", false, DataSourceUpdateMode.OnPropertyChanged);
            this.checkBoxEnableSkylineFill.DataBindings.Add("Checked", UserSettings, "SkylineFillFlag", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxSkylineFillForegroundColor.DataBindings.Add("Text", UserSettings, "SkylineFillForegroundColor", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxSkylineFillBackgroundColor.DataBindings.Add("Text", UserSettings, "SkylineFillBackgroundColor", false, DataSourceUpdateMode.OnPropertyChanged);


            // Canvas and Grid Settings

            this.textBoxCanvasBackgroundColor.DataBindings.Add("Text", UserSettings, "CanvasBackgroundColor", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxMarginLeft.DataBindings.Add("Text", UserSettings, "CanvasMarginLeft", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxMarginRight.DataBindings.Add("Text", UserSettings, "CanvasMarginRight", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxMarginTop.DataBindings.Add("Text", UserSettings, "CanvasMarginTop", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxMarginBottom.DataBindings.Add("Text", UserSettings, "CanvasMarginBottom", false, DataSourceUpdateMode.OnPropertyChanged);
            this.checkBoxShowGrid.DataBindings.Add("Checked", UserSettings, "ShowGrid", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxCanvasGridColor.DataBindings.Add("Text", UserSettings, "GridColor", false, DataSourceUpdateMode.OnPropertyChanged);


            // Axis Settings

            this.checkBoxShowXAxis.DataBindings.Add("Checked", UserSettings, "ShowXAxis", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxXAxisColor.DataBindings.Add("Text", UserSettings, "XAxisColor", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxXAxisWidth.DataBindings.Add("Text", UserSettings, "XAxisWidth", false, DataSourceUpdateMode.OnPropertyChanged);
            this.checkBoxShowYAxis.DataBindings.Add("Checked", UserSettings, "ShowYAxis", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxYAxisWidth.DataBindings.Add("Text", UserSettings, "YAxisWidth", false, DataSourceUpdateMode.OnPropertyChanged);
            this.textBoxYAxisColor.DataBindings.Add("Text", UserSettings, "YAxisColor", false, DataSourceUpdateMode.OnPropertyChanged);


            // Other Settings

            this.textBoxDefaultDataFile.DataBindings.Add("Text", UserSettings, "DefaultDataFile", false, DataSourceUpdateMode.OnPropertyChanged);
            this.checkBoxShowDataCoordinates.DataBindings.Add("Checked", UserSettings, "ShowDataCoordinates", false, DataSourceUpdateMode.OnPropertyChanged);
            this.checkBoxShowInfoPanel.DataBindings.Add("Checked", UserSettings, "ShowInfoPanel", false, DataSourceUpdateMode.OnPropertyChanged);
            this.checkBoxInfoPanelSavePosition.DataBindings.Add("Checked", UserSettings, "SaveInfoPanelPosition", false, DataSourceUpdateMode.OnPropertyChanged);
            this.toggleTopMost.DataBindings.Add("Checked", UserSettings, "MakeTopMostWindow", false, DataSourceUpdateMode.OnPropertyChanged);
            this.comboBoxUITheme.DataBindings.Add("SelectedIndex", UserSettings, "ActiveTheme", false, DataSourceUpdateMode.OnPropertyChanged);
            this.comboBoxInfoPanelDockingLocation.DataBindings.Add("SelectedIndex", UserSettings, "InfoPanelDockingLocation", false, DataSourceUpdateMode.OnPropertyChanged);


            UserSettings.PropertyChanged += UserSettings_PropertyChanged;
        }

        private void UserSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "InfoPanelDockingLocation")
            {
                //InfoPanel.DockToParent();
            }
            base.UserSettingsChanged(sender, e);
        }

        private void SetColorSwatch(Color currentColor, Panel swatchPanel, TextBox textBoxHexRGB)
        {
            Color c = SelectColor(currentColor);
            swatchPanel.BackColor = c;
            textBoxHexRGB.Text = KohdAndArt.Toolkit.ColorUtilities.ConvertColorToHexRGBString(c);
            ParentForm.OptionsUpdated();
        }

        private Color SelectColor(Color currentColor)
        {
            Color c = currentColor;
            var dlg = new ColorDialogEx();
            if (dlg.ShowDialog() == DialogResult.OK)
                {c = dlg.Color;}

            return c;
        }

        private void EnableColorPickerComponents(bool enable, Label l, Panel p, TextBox t)
        {
            l.Enabled = enable;
            p.Enabled = enable;
            t.Enabled = enable;
        }

        #region Event Handlers
        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                if (filename.Length > 0 && File.Exists(filename))
                {
                    textBoxDefaultDataFile.Text = filename;
                }
            }
        }

        private void checkBoxShowDataCoordinates_Click(object sender, EventArgs e)
        {
            ParentForm.OptionsUpdated();
        }

        private void checkBoxShowGrid_Click(object sender, EventArgs e)
        {
            panelGridGroup.Visible = checkBoxShowGrid.Checked;
            ParentForm.OptionsUpdated();
        }

        private void panelSkylineBorderColorSwatch_Click(object sender, EventArgs e)
        {
            SetColorSwatch(panelSkylineBorderColorSwatch.BackColor, 
                           panelSkylineBorderColorSwatch, 
                           textBoxSkylineBorderColor);
        }

        private void panelCanvasBackgroundColorSwatch_Click(object sender, EventArgs e)
        {
            SetColorSwatch(panelCanvasBackgroundColorSwatch.BackColor,
                           panelCanvasBackgroundColorSwatch, 
                           textBoxCanvasBackgroundColor);
        }

        private void panelCanvasGridColorSwatch_Click(object sender, EventArgs e)
        {
            SetColorSwatch(panelCanvasGridColorSwatch.BackColor,
                           panelCanvasGridColorSwatch,
                           textBoxCanvasGridColor);
        }

        private void textBoxSkylineBorderWidth_TextChanged(object sender, EventArgs e)
        {
            ParentForm.OptionsUpdated();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBoxXAxisWidth_TextChanged(object sender, EventArgs e)
        {
            LogHelper.Log($"X-Axis width changed.");
            ParentForm.OptionsUpdated();
        }

        private void textBoxYAxisWidth_TextChanged(object sender, EventArgs e)
        {
            LogHelper.Log($"Y-Axis width changed.");
            ParentForm.OptionsUpdated();
        }

        private void panelXAxisColorSwatch_Click(object sender, EventArgs e)
        {
            SetColorSwatch(panelXAxisColorSwatch.BackColor,
                           panelXAxisColorSwatch,
                           textBoxXAxisColor);
        }

        private void panelYAxisColorSwatch_Click(object sender, EventArgs e)
        {
            SetColorSwatch(panelYAxisColorSwatch.BackColor,
                           panelYAxisColorSwatch,
                           textBoxYAxisColor);
        }

        private void textBoxMarginLeft_TextChanged(object sender, EventArgs e)
        {
            LogHelper.Log($"Margin Left changed.");
            ParentForm.OptionsUpdated();
        }

        private void textBoxMarginRight_TextChanged(object sender, EventArgs e)
        {
            LogHelper.Log($"Margin Right changed.");
            ParentForm.OptionsUpdated();
        }

        private void textBoxMarginTop_TextChanged(object sender, EventArgs e)
        {
            LogHelper.Log($"Margin Top changed.");
            ParentForm.OptionsUpdated();
        }

        private void textBoxMarginBottom_TextChanged(object sender, EventArgs e)
        {
            LogHelper.Log($"Margin Bottom changed.");
            ParentForm.OptionsUpdated();
        }
        #endregion

        private void checkBoxShowInfoPanel_Click(object sender, EventArgs e)
        {
            var isChecked = checkBoxShowInfoPanel.Checked;
            panelInfoBoxDockingLocation.Visible = isChecked;
            var temp = isChecked ? $"Visible" : "Hidden";
            Log($"InfoPanel {temp}");
            ParentForm.OptionsUpdated();
        }

        private void panelSkylineFillForegroundColorSwatch_Click(object sender, EventArgs e)
        {
            SetColorSwatch(panelSkylineFillForegroundColorSwatch.BackColor,
                           panelSkylineFillForegroundColorSwatch,
                           textBoxSkylineFillForegroundColor);
        }

        private void panelSkylineFillBackgroundColorSwatch_Click(object sender, EventArgs e)
        {
            SetColorSwatch(panelSkylineFillBackgroundColorSwatch.BackColor,
                           panelSkylineFillBackgroundColorSwatch,
                           textBoxSkylineFillBackgroundColor);
        }

        private void textBoxDefaultDataFile_ButtonClick(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                if (filename.Length > 0 && File.Exists(filename))
                {
                    textBoxDefaultDataFile.Text = filename;
                    ParentForm.OptionsUpdated();
                }
            }
        }

        private void checkBoxHighlightSkyline_Click(object sender, EventArgs e)
        {
            panelSkylineSettingsGroup.Visible = checkBoxHighlightSkyline.Checked;
            ParentForm.OptionsUpdated();
        }

        private void checkBoxEnableSkylineFill_Click(object sender, EventArgs e)
        {
            panelSkylineFillGroup.Visible = checkBoxEnableSkylineFill.Checked;
            ParentForm.OptionsUpdated();
        }

        private void checkBoxShowXAxis_Click(object sender, EventArgs e)
        {
            panelXAxisGroup.Visible = checkBoxShowXAxis.Checked;
            ParentForm.OptionsUpdated();
        }

        private void checkBoxShowYAxis_Click(object sender, EventArgs e)
        {
            panelYAxisGroup.Visible = checkBoxShowYAxis.Checked;
            ParentForm.OptionsUpdated();
        }

        private void comboBoxInfoPanelDockingLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            var text = string.Empty;
            var selectedIndex = comboBoxInfoPanelDockingLocation.SelectedIndex;
            var selectedVal = comboBoxInfoPanelDockingLocation.SelectedValue;
            if (selectedVal.HasProperty("Description"))
            {
                text = (string)selectedVal.GetPropertyValue("Description");
                Debug.Assert(text.Length > 0);
            }
            LogHelper.LogInfo($"Changing InfoPanel docking location to '{text}' - [{selectedIndex}]");

            //int selectedIndex = comboBoxInfoPanelDockingLocation.SelectedIndex;
            //UserSettings.InfoPanelDockingLocation = selectedIndex;
            ParentForm.OptionsUpdated();
        }
    }
}
