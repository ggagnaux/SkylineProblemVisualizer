namespace SkylineProblemVisualizer.UI
{
    partial class InfoPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelMousePositionLabel = new MetroFramework.Controls.MetroLabel();
            this.labelMousePosition = new MetroFramework.Controls.MetroLabel();
            this.labelZoomLevel = new MetroFramework.Controls.MetroLabel();
            this.labelZoomLevelLabel = new MetroFramework.Controls.MetroLabel();
            this.tabControl = new MetroFramework.Controls.MetroTabControl();
            this.tabPageSourceData = new MetroFramework.Controls.MetroTabPage();
            this.listViewData = new MetroFramework.Controls.MetroListView();
            this.tabPageLog = new MetroFramework.Controls.MetroTabPage();
            this.textBoxProgramLog = new MetroFramework.Controls.MetroTextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.tabControl.SuspendLayout();
            this.tabPageSourceData.SuspendLayout();
            this.tabPageLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // labelMousePositionLabel
            // 
            this.labelMousePositionLabel.AutoSize = true;
            this.labelMousePositionLabel.Location = new System.Drawing.Point(12, 73);
            this.labelMousePositionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMousePositionLabel.Name = "labelMousePositionLabel";
            this.labelMousePositionLabel.Size = new System.Drawing.Size(105, 20);
            this.labelMousePositionLabel.TabIndex = 0;
            this.labelMousePositionLabel.Text = "Mouse Position:";
            // 
            // labelMousePosition
            // 
            this.labelMousePosition.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelMousePosition.AutoSize = true;
            this.labelMousePosition.Location = new System.Drawing.Point(233, 73);
            this.labelMousePosition.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelMousePosition.Name = "labelMousePosition";
            this.labelMousePosition.Size = new System.Drawing.Size(81, 20);
            this.labelMousePosition.TabIndex = 1;
            this.labelMousePosition.Text = "1000 x 1000";
            this.labelMousePosition.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelZoomLevel
            // 
            this.labelZoomLevel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelZoomLevel.AutoSize = true;
            this.labelZoomLevel.Location = new System.Drawing.Point(281, 97);
            this.labelZoomLevel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelZoomLevel.Name = "labelZoomLevel";
            this.labelZoomLevel.Size = new System.Drawing.Size(42, 20);
            this.labelZoomLevel.TabIndex = 3;
            this.labelZoomLevel.Text = "100%";
            this.labelZoomLevel.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelZoomLevelLabel
            // 
            this.labelZoomLevelLabel.AutoSize = true;
            this.labelZoomLevelLabel.Location = new System.Drawing.Point(12, 97);
            this.labelZoomLevelLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelZoomLevelLabel.Name = "labelZoomLevelLabel";
            this.labelZoomLevelLabel.Size = new System.Drawing.Size(86, 20);
            this.labelZoomLevelLabel.TabIndex = 2;
            this.labelZoomLevelLabel.Text = "Zoom Level:";
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabPageSourceData);
            this.tabControl.Controls.Add(this.tabPageLog);
            this.tabControl.Location = new System.Drawing.Point(8, 120);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(347, 507);
            this.tabControl.TabIndex = 6;
            this.tabControl.UseSelectable = true;
            // 
            // tabPageSourceData
            // 
            this.tabPageSourceData.Controls.Add(this.listViewData);
            this.tabPageSourceData.HorizontalScrollbarBarColor = true;
            this.tabPageSourceData.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPageSourceData.HorizontalScrollbarSize = 2;
            this.tabPageSourceData.Location = new System.Drawing.Point(4, 38);
            this.tabPageSourceData.Name = "tabPageSourceData";
            this.tabPageSourceData.Size = new System.Drawing.Size(339, 465);
            this.tabPageSourceData.TabIndex = 0;
            this.tabPageSourceData.Text = "Source Data";
            this.tabPageSourceData.VerticalScrollbarBarColor = true;
            this.tabPageSourceData.VerticalScrollbarHighlightOnWheel = false;
            this.tabPageSourceData.VerticalScrollbarSize = 2;
            // 
            // listViewData
            // 
            this.listViewData.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listViewData.FullRowSelect = true;
            this.listViewData.Location = new System.Drawing.Point(0, 3);
            this.listViewData.Name = "listViewData";
            this.listViewData.OwnerDraw = true;
            this.listViewData.Size = new System.Drawing.Size(339, 459);
            this.listViewData.TabIndex = 5;
            this.listViewData.UseCompatibleStateImageBehavior = false;
            this.listViewData.UseSelectable = true;
            this.listViewData.View = System.Windows.Forms.View.Details;
            // 
            // tabPageLog
            // 
            this.tabPageLog.Controls.Add(this.textBoxProgramLog);
            this.tabPageLog.HorizontalScrollbarBarColor = true;
            this.tabPageLog.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPageLog.HorizontalScrollbarSize = 2;
            this.tabPageLog.Location = new System.Drawing.Point(4, 38);
            this.tabPageLog.Name = "tabPageLog";
            this.tabPageLog.Size = new System.Drawing.Size(339, 465);
            this.tabPageLog.TabIndex = 1;
            this.tabPageLog.Text = "Live Log";
            this.tabPageLog.VerticalScrollbarBarColor = true;
            this.tabPageLog.VerticalScrollbarHighlightOnWheel = false;
            this.tabPageLog.VerticalScrollbarSize = 2;
            // 
            // textBoxProgramLog
            // 
            // 
            // 
            // 
            this.textBoxProgramLog.CustomButton.Image = null;
            this.textBoxProgramLog.CustomButton.Location = new System.Drawing.Point(-100, 1);
            this.textBoxProgramLog.CustomButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxProgramLog.CustomButton.Name = "";
            this.textBoxProgramLog.CustomButton.Size = new System.Drawing.Size(370, 370);
            this.textBoxProgramLog.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.textBoxProgramLog.CustomButton.TabIndex = 1;
            this.textBoxProgramLog.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.textBoxProgramLog.CustomButton.UseSelectable = true;
            this.textBoxProgramLog.CustomButton.Visible = false;
            this.textBoxProgramLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxProgramLog.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.textBoxProgramLog.Lines = new string[] {
        "metroTextBox1"};
            this.textBoxProgramLog.Location = new System.Drawing.Point(0, 0);
            this.textBoxProgramLog.MaxLength = 32767;
            this.textBoxProgramLog.Multiline = true;
            this.textBoxProgramLog.Name = "textBoxProgramLog";
            this.textBoxProgramLog.PasswordChar = '\0';
            this.textBoxProgramLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxProgramLog.SelectedText = "";
            this.textBoxProgramLog.SelectionLength = 0;
            this.textBoxProgramLog.SelectionStart = 0;
            this.textBoxProgramLog.ShortcutsEnabled = true;
            this.textBoxProgramLog.Size = new System.Drawing.Size(339, 465);
            this.textBoxProgramLog.TabIndex = 2;
            this.textBoxProgramLog.Text = "metroTextBox1";
            this.textBoxProgramLog.UseSelectable = true;
            this.textBoxProgramLog.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.textBoxProgramLog.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // InfoPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(361, 638);
            this.ControlBox = false;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.labelZoomLevel);
            this.Controls.Add(this.labelZoomLevelLabel);
            this.Controls.Add(this.labelMousePosition);
            this.Controls.Add(this.labelMousePositionLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InfoPanel";
            this.Opacity = 0.9D;
            this.Padding = new System.Windows.Forms.Padding(25, 75, 25, 25);
            this.Resizable = false;
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "Info";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.InfoPanel_FormClosing);
            this.tabControl.ResumeLayout(false);
            this.tabPageSourceData.ResumeLayout(false);
            this.tabPageLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel labelMousePositionLabel;
        private MetroFramework.Controls.MetroLabel labelMousePosition;
        private MetroFramework.Controls.MetroLabel labelZoomLevel;
        private MetroFramework.Controls.MetroLabel labelZoomLevelLabel;
        private MetroFramework.Controls.MetroTabControl tabControl;
        private MetroFramework.Controls.MetroTabPage tabPageSourceData;
        private MetroFramework.Controls.MetroTabPage tabPageLog;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private MetroFramework.Controls.MetroTextBox textBoxProgramLog;
        private MetroFramework.Controls.MetroListView listViewData;
    }
}