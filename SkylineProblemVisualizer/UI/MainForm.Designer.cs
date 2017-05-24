using SkylineProblemVisualizer.Utilities;
namespace SkylineProblemVisualizer
{
    partial class MainForm
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panelCanvas = new System.Windows.Forms.Panel();
            this.labelDefaultDataFile = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quickFlagsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemSkylineBorder = new SkylineProblemVisualizer.UI.BindableToolStripMenuItem();
            this.menuItemSkylineFill = new SkylineProblemVisualizer.UI.BindableToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemGrid = new SkylineProblemVisualizer.UI.BindableToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemXAxis = new SkylineProblemVisualizer.UI.BindableToolStripMenuItem();
            this.menuItemYAxis = new SkylineProblemVisualizer.UI.BindableToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuItemShowDataPoints = new SkylineProblemVisualizer.UI.BindableToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkBoxToggleInfoPanel = new MetroFramework.Controls.MetroToggle();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.logViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panelCanvas.SuspendLayout();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // panelCanvas
            // 
            this.panelCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelCanvas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(40)))));
            this.panelCanvas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelCanvas.Controls.Add(this.labelDefaultDataFile);
            this.panelCanvas.Cursor = System.Windows.Forms.Cursors.Cross;
            this.panelCanvas.ForeColor = System.Drawing.Color.Transparent;
            this.panelCanvas.Location = new System.Drawing.Point(0, 0);
            this.panelCanvas.Margin = new System.Windows.Forms.Padding(4);
            this.panelCanvas.Name = "panelCanvas";
            this.panelCanvas.Size = new System.Drawing.Size(842, 557);
            this.panelCanvas.TabIndex = 5;
            this.panelCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCanvas_Paint);
            this.panelCanvas.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseMove);
            this.panelCanvas.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.panelCanvas_MouseWheel);
            this.panelCanvas.Resize += new System.EventHandler(this.panelCanvas_Resize);
            // 
            // labelDefaultDataFile
            // 
            this.labelDefaultDataFile.AutoSize = true;
            this.labelDefaultDataFile.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.labelDefaultDataFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDefaultDataFile.ForeColor = System.Drawing.SystemColors.Control;
            this.labelDefaultDataFile.Location = new System.Drawing.Point(4, 6);
            this.labelDefaultDataFile.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelDefaultDataFile.Name = "labelDefaultDataFile";
            this.labelDefaultDataFile.Size = new System.Drawing.Size(97, 20);
            this.labelDefaultDataFile.TabIndex = 13;
            this.labelDefaultDataFile.Text = "<Filename>";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.panel1.Controls.Add(this.panelCanvas);
            this.panel1.Location = new System.Drawing.Point(15, 114);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(842, 557);
            this.panel1.TabIndex = 6;
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.quickFlagsToolStripMenuItem,
            this.logViewerToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(15, 75);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(487, 31);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.BackColor = System.Drawing.Color.Transparent;
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Menu;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(47, 27);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.ForeColor = System.Drawing.SystemColors.MenuText;
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(238, 28);
            this.openToolStripMenuItem.Text = "&Open New Data File";
            this.openToolStripMenuItem.ToolTipText = "Open a new data file";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.ForeColor = System.Drawing.SystemColors.MenuText;
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(238, 28);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.ToolTipText = "Exit the application";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Menu;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(82, 27);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // quickFlagsToolStripMenuItem
            // 
            this.quickFlagsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemSkylineBorder,
            this.menuItemSkylineFill,
            this.toolStripSeparator1,
            this.menuItemGrid,
            this.toolStripSeparator2,
            this.menuItemXAxis,
            this.menuItemYAxis,
            this.toolStripSeparator3,
            this.menuItemShowDataPoints});
            this.quickFlagsToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Menu;
            this.quickFlagsToolStripMenuItem.Name = "quickFlagsToolStripMenuItem";
            this.quickFlagsToolStripMenuItem.Size = new System.Drawing.Size(60, 27);
            this.quickFlagsToolStripMenuItem.Text = "F&lags";
            // 
            // menuItemSkylineBorder
            // 
            this.menuItemSkylineBorder.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.menuItemSkylineBorder.Name = "menuItemSkylineBorder";
            this.menuItemSkylineBorder.Size = new System.Drawing.Size(219, 28);
            this.menuItemSkylineBorder.Text = "Skyline &Border";
            this.menuItemSkylineBorder.Click += new System.EventHandler(this.menuItemSkylineBorder_Click);
            // 
            // menuItemSkylineFill
            // 
            this.menuItemSkylineFill.Name = "menuItemSkylineFill";
            this.menuItemSkylineFill.Size = new System.Drawing.Size(219, 28);
            this.menuItemSkylineFill.Text = "Skyline &Fill";
            this.menuItemSkylineFill.Click += new System.EventHandler(this.menuItemSkylineFill_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(216, 6);
            // 
            // menuItemGrid
            // 
            this.menuItemGrid.Name = "menuItemGrid";
            this.menuItemGrid.Size = new System.Drawing.Size(219, 28);
            this.menuItemGrid.Text = "&Grid";
            this.menuItemGrid.Click += new System.EventHandler(this.menuItemGrid_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(216, 6);
            // 
            // menuItemXAxis
            // 
            this.menuItemXAxis.Name = "menuItemXAxis";
            this.menuItemXAxis.Size = new System.Drawing.Size(219, 28);
            this.menuItemXAxis.Text = "&X-Axis";
            this.menuItemXAxis.Click += new System.EventHandler(this.menuItemXAxis_Click);
            // 
            // menuItemYAxis
            // 
            this.menuItemYAxis.Name = "menuItemYAxis";
            this.menuItemYAxis.Size = new System.Drawing.Size(219, 28);
            this.menuItemYAxis.Text = "&Y-Axis";
            this.menuItemYAxis.Click += new System.EventHandler(this.menuItemYAxis_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(216, 6);
            // 
            // menuItemShowDataPoints
            // 
            this.menuItemShowDataPoints.Name = "menuItemShowDataPoints";
            this.menuItemShowDataPoints.Size = new System.Drawing.Size(219, 28);
            this.menuItemShowDataPoints.Text = "&Show Data Points";
            this.menuItemShowDataPoints.Click += new System.EventHandler(this.menuItemShowDataPoints_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.ForeColor = System.Drawing.SystemColors.Menu;
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(69, 27);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.ToolTipText = "Display the About Dialog";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // checkBoxToggleInfoPanel
            // 
            this.checkBoxToggleInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxToggleInfoPanel.AutoSize = true;
            this.checkBoxToggleInfoPanel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.checkBoxToggleInfoPanel.DisplayStatus = false;
            this.checkBoxToggleInfoPanel.FontSize = MetroFramework.MetroLinkSize.Medium;
            this.checkBoxToggleInfoPanel.Location = new System.Drawing.Point(807, 82);
            this.checkBoxToggleInfoPanel.Name = "checkBoxToggleInfoPanel";
            this.checkBoxToggleInfoPanel.Size = new System.Drawing.Size(50, 24);
            this.checkBoxToggleInfoPanel.TabIndex = 15;
            this.checkBoxToggleInfoPanel.Text = "Off";
            this.checkBoxToggleInfoPanel.UseSelectable = true;
            this.checkBoxToggleInfoPanel.Click += new System.EventHandler(this.checkBoxToggleInfoPanel_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.metroLabel1.Location = new System.Drawing.Point(712, 81);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(89, 25);
            this.metroLabel1.TabIndex = 16;
            this.metroLabel1.Text = "Info Panel";
            // 
            // logViewerToolStripMenuItem
            // 
            this.logViewerToolStripMenuItem.Name = "logViewerToolStripMenuItem";
            this.logViewerToolStripMenuItem.Size = new System.Drawing.Size(106, 27);
            this.logViewerToolStripMenuItem.Text = "&Log Viewer";
            this.logViewerToolStripMenuItem.Click += new System.EventHandler(this.logViewerToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = MetroFramework.Forms.MetroFormBorderStyle.FixedSingle;
            this.ClientSize = new System.Drawing.Size(874, 685);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.checkBoxToggleInfoPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(625, 500);
            this.Name = "MainForm";
            this.Padding = new System.Windows.Forms.Padding(25, 75, 25, 25);
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.AeroShadow;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Style = MetroFramework.MetroColorStyle.Teal;
            this.Text = "Skyline Problem Visualizer";
            this.Theme = MetroFramework.MetroThemeStyle.Default;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.LocationChanged += new System.EventHandler(this.MainForm_LocationChanged);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.panelCanvas.ResumeLayout(false);
            this.panelCanvas.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel panelCanvas;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label labelDefaultDataFile;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quickFlagsToolStripMenuItem;
        private SkylineProblemVisualizer.UI.BindableToolStripMenuItem menuItemSkylineBorder;
        private SkylineProblemVisualizer.UI.BindableToolStripMenuItem menuItemSkylineFill;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private SkylineProblemVisualizer.UI.BindableToolStripMenuItem menuItemGrid;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private SkylineProblemVisualizer.UI.BindableToolStripMenuItem menuItemXAxis;
        private SkylineProblemVisualizer.UI.BindableToolStripMenuItem menuItemYAxis;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private SkylineProblemVisualizer.UI.BindableToolStripMenuItem menuItemShowDataPoints;
        private MetroFramework.Controls.MetroToggle checkBoxToggleInfoPanel;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem logViewerToolStripMenuItem;
    }
}

