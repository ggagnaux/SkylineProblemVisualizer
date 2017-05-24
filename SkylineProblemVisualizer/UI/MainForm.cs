using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using KohdAndArt.Toolkit;
using KohdAndArt.Toolkit.Sys;
using SkylineProblemVisualizer.Controllers;
using SkylineProblemVisualizer.Interfaces;
using SkylineProblemVisualizer.UI;
using SkylineProblemVisualizer.Utilities;

namespace SkylineProblemVisualizer
{
    public partial class MainForm : FormBase
    {
        #region External Imports
        [DllImport(@"gdiplus.dll")]
        public static extern int GdipWindingModeOutline(HandleRef path, IntPtr matrix, float flatness);
        #endregion

        #region Public Properties

        //public event Action UserSettingsChanged;


        // Just wrappers for external objects
        private new MainFormController      Controller { get { return (MainFormController)base.Controller; } }
        private DataManager                 DataManager { get { return Controller.DataManager; } }
        private UserSettings                UserSettings { get { return Controller.UserSettings; } }
        private ChartCanvasManager          CanvasManager { get; set; }
        private IList<BuildingCoordinates>  DataList { get; set; }

        // TODO - Need to get rid of this dependency
        public static InfoPanel             InfoPanel { get; set; }
        #endregion

        #region Private Variables

        // Setup our pens and brushes
        static float penWidth = 0;
        Pen[] _pens = new Pen[] {
                new Pen(Color.LightSeaGreen, penWidth),
                new Pen(Color.Blue, penWidth),
                new Pen(Color.Red, penWidth),
                new Pen(Color.Green, penWidth),
                new Pen(Color.CadetBlue, penWidth),
                new Pen(Color.LightCoral, penWidth),
                new Pen(Color.Gray, penWidth),
                new Pen(Color.Yellow, penWidth),
                new Pen(Color.Orange, penWidth), 
                new Pen(Color.Purple, penWidth),
            };
        Point _centerPoint = new Point();
        float _canvasZoomFactor = 1.0f;
        bool _ctrlPressed = false;
        #endregion

        #region Constructor(s)
        public MainForm(IFormController _controller) : base(_controller)
        {
            Log("Constructing MainForm()");
            InitializeComponent();
            Initialize();
            SetBindings();
            SetTitle();

            //TestBuildGridRectangle();
        }
        #endregion

        #region Private Methods
        public override void Initialize()
        {
            Log("Calling Initialize()");

            // Create the canvas manager
            CanvasManager = new ChartCanvasManager(panelCanvas.Width, panelCanvas.Height);

            // Ensure that the primary canvas doesn't flicker when refreshed
            panelCanvas.SetDoubleBuffered();

            // Setup keyboard handler
            InitializeKeyboardHandlers();

            // Initialize Menu Customizations
            InitializeMenuSettings();

            // Create and optionally display the info panel
            InfoPanel = InfoPanel.GetInstance(this, Controller);
            if (InfoPanel == null)
                InfoPanel.SetData(Controller.DataManager.InputData);
                if (UserSettings.ShowInfoPanel)
                { InfoPanel.Show(); }
            {
                InfoPanel.SetData(Controller.DataManager.InputData);
                InfoPanel.Show(UserSettings.ShowInfoPanel);
            }

            base.Initialize();
        }

        private void SetTitle()
        {
            var util = new AssemblyUtilities(Assembly.GetExecutingAssembly());
            string title = $"{util.AssemblyTitle} V{util.AssemblyVersion}";
            this.Text = title;
        }

        private void SetBindings()
        {
            Log("Calling SetBindings()");

            // Need to control how text is formatted
            var binding = new Binding("Text", UserSettings, "DefaultDataFile", true, DataSourceUpdateMode.OnPropertyChanged);
            binding.Format += labelDefaultDataFile_Format;
            this.labelDefaultDataFile.DataBindings.Add(binding);

            this.checkBoxToggleInfoPanel.DataBindings.Add("Checked", UserSettings, "ShowInfoPanel", false, DataSourceUpdateMode.OnPropertyChanged);
            this.menuItemSkylineBorder.DataBindings.Add("Checked", UserSettings, "HighlightSkyline", false, DataSourceUpdateMode.OnPropertyChanged);
            this.menuItemSkylineFill.DataBindings.Add("Checked", UserSettings, "SkylineFillFlag", false, DataSourceUpdateMode.OnPropertyChanged);
            this.menuItemXAxis.DataBindings.Add("Checked", UserSettings, "ShowXAxis", false, DataSourceUpdateMode.OnPropertyChanged);
            this.menuItemYAxis.DataBindings.Add("Checked", UserSettings, "ShowYAxis", false, DataSourceUpdateMode.OnPropertyChanged);
            this.menuItemGrid.DataBindings.Add("Checked", UserSettings, "ShowGrid", false, DataSourceUpdateMode.OnPropertyChanged);
            this.menuItemShowDataPoints.DataBindings.Add("Checked", UserSettings, "ShowDataCoordinates", false, DataSourceUpdateMode.OnPropertyChanged);

            UserSettings.PropertyChanged += UserSettings_PropertyChanged;
        }

        private void UserSettings_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            InfoPanel.TopMost = ((UserSettings)sender).MakeTopMostWindow;
            base.UserSettingsChanged(sender, e);
        }

        private void InitializeMenuSettings()
        {
            //menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            //menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());


            var renderer = new MenuStripRenderer();
            ToolStripManager.Renderer = renderer;
            menuStrip1.RenderMode = ToolStripRenderMode.Professional;
            menuStrip1.Renderer = renderer;
            menuStrip1.Cursor = Cursors.Hand;

            //menuStrip1.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());
            //var renderer = new MenuStripRenderer();
            //ToolStripManager.Renderer = renderer;
            //menuStrip1.Renderer = renderer;

            //menuStrip1.Renderer = new MenuStripRenderer();
            //menuStrip1.ForeColor = Color.White;
            //menuStrip1.Cursor = Cursors.Hand;
            //menuStrip1.BackColor = Color.Transparent;
            //menuStrip1.ForeColor = Color.White;
            //menuStrip1.Dock = DockStyle.Top;

            //menuStrip2.Renderer = new ToolStripProfessionalRenderer(new CustomColorTable());

        }

        private void UpdateMainFormUI()
        {
            labelDefaultDataFile.Text = new FileInfo(UserSettings.DefaultDataFile).Name;
        }

        private void InitializeKeyboardHandlers()
        {
            this.KeyPreview = true;
            this.KeyDown += new KeyEventHandler(MainForm_KeyDown);
        }

        private void ReloadData()
        {
            Log("Calling ReloadData()");

            DataManager.Filename = UserSettings.DefaultDataFile;
            InfoPanel.SetData(Controller.DataManager.InputData);
        }

        private void DrawRawData()
        {
            panelCanvas.Invalidate();
        }

        private void ReinitializeValues()
        {
            var w = panelCanvas.Width;
            var h = panelCanvas.Height;
            _centerPoint.X = w / 2;
            _centerPoint.Y = h / 2;
            CanvasManager?.SetCanvasDimensions(w, h);
        }

        private void ReinitializeWindow()
        {
            ReinitializeValues();
            panelCanvas.Invalidate();
        }
        #endregion

        #region Event Handlers
        private void panelCanvas_Paint(object sender, PaintEventArgs e)
        {
            var allPointsList = new List<PointF>();
            var graphicsPath = new GraphicsPath();
            var penIndex = 0;
            var g = e.Graphics;

            g.SmoothingMode = SmoothingMode.AntiAlias;
            CanvasManager.Graphics = g;

            //DrawCheckerboard(g);
            //return;

            // Set the canvas background color
            panelCanvas.BackColor = ColorUtilities.GetColorFromHexRGBString(UserSettings.CanvasBackgroundColor);

            // Set up the coordinate mapping
            MapRectangles(g,
                          0, Controller.DataManager.MaximumX, 0, DataManager.MaximumY, // World Coordinates
                          0 + UserSettings.CanvasMarginLeft,                    // Device Coordinates
                          CanvasManager.Width - UserSettings.CanvasMarginRight,
                          0 + UserSettings.CanvasMarginTop,
                          CanvasManager.Height - UserSettings.CanvasMarginBottom,
                          false);

            // Set the Zoom factor
            CanvasManager.Zoom(_canvasZoomFactor);

            foreach (BuildingCoordinates buildingData in DataManager.InputData)
            {
                var left = buildingData.Left;
                var height = buildingData.Height;
                var right = buildingData.Right;
                var width = buildingData.Width;
                var bottom = 0;

                graphicsPath.AddRectangle(new Rectangle(left, bottom, width, height));

                HandleRef handle = new HandleRef(graphicsPath,
                                                    (IntPtr)graphicsPath.
                                                    GetType().
                                                    GetField("nativePath", BindingFlags.NonPublic |
                                                                            BindingFlags.Instance).
                                                    GetValue(graphicsPath));

                GdipWindingModeOutline(handle, IntPtr.Zero, 0.25F);

                if (!UserSettings.HighlightSkyline)
                {
                    // Draw the building outline rectangle
                    DrawBuildingOutline(g, _pens[penIndex], left, bottom, right, height);
                }

                penIndex = GetNextPenArrayIndex(penIndex, _pens.Length);
            }

            if (UserSettings.HighlightSkyline)
            {
                DrawSkyline(g, graphicsPath,
                            UserSettings.SkylineBorderWidth,
                            UserSettings.SkylineBorderColor,
                            UserSettings.SkylineFillFlag,
                            UserSettings.SkylineFillForegroundColor,
                            UserSettings.SkylineFillBackgroundColor);
            }

            if (UserSettings.ShowDataCoordinates)
            {
                //g.ResetTransform();

                // Set up the coordinate mapping
                //MapRectangles(g,
                //              0, DataManager.MaximumX, 0, DataManager.MaximumY, // World Coordinates
                //              0 + Settings.CanvasMarginLeft,                    // Device Coordinates
                //              CanvasManager.Width - Settings.CanvasMarginRight,
                //              0 + Settings.CanvasMarginTop,
                //              CanvasManager.Height - Settings.CanvasMarginBottom,
                //              false);

                DrawDataCoordinates(g, graphicsPath.PathData);
            }

            // Save the path data points to a file
            DataManager.WriteOutputPathDataToFile(graphicsPath.PathData);

            // Clear out all of the transforms on the graphics object
            g.ResetTransform();

            // Ensure the canvas dimensions are correct and optionally
            // display the X and/ or Y Axis.
            DrawAxis();

            // Render the grid
            DrawGrid();
        }

        private void DrawCheckerboard(Graphics g)
        {
            Color backgroundColor = Color.FromArgb(200, 50, 50, 50);
            Color borderColor = Color.FromArgb(60, 255, 255, 255);
            Color textColor = Color.FromArgb(100, 255, 255, 255);
            float borderWidth = 1.0f;

            //g.Clear(backgroundColor);

            IEnumerable<Rectangle> list = BuildGridRectangles(_canvasWidth: panelCanvas.Width,
                                                       _canvasHeight: panelCanvas.Height,
                                                       _blockCountHorizontal: 8,
                                                       _blockCountVertical: 8,
                                                       _gapWidth: 20,
                                                       _gapHeight: 20);


            var stringFormat = new StringFormat()
            {
                Alignment = StringAlignment.Center,
                LineAlignment = StringAlignment.Center
            };

            int temp = 0;
            using (var p = new Pen(borderColor, borderWidth))
            {
                foreach (var rect in list)
                {
                    g.DrawRectangle(p, rect);
                    if (temp % 2 == 0)
                    {
                        g.FillRectangle(new SolidBrush(borderColor), rect);
                    }
                    temp++;

                    string coordinateText = $"{rect.X} x {rect.Y}";
                    g.DrawString(coordinateText, 
                                 new Font(FontFamily.GenericSansSerif, 8.0f, FontStyle.Regular), new SolidBrush(textColor), rect, stringFormat);
                }
            }
        }

        private int GetNextPenArrayIndex(int currentIndex, int arrayLength)
        {
            var newIndex = ++currentIndex;
            if (newIndex >= arrayLength)
            {
                newIndex = 0;
            }
            return newIndex;
        }

        private void DrawBuildingOutline(Graphics gr, Pen pen, int left, int bottom, int right, int height)
        {
            gr.DrawLine(pen, left, bottom, left, height);
            gr.DrawLine(pen, left, height, right, height);
            gr.DrawLine(pen, right, height, right, bottom);
        }

        private void DrawAxis()
        {
            CanvasManager.SetCanvasDimensions(panelCanvas.Width, panelCanvas.Height);
            CanvasManager.SetMargins(UserSettings.CanvasMarginLeft,
                                     UserSettings.CanvasMarginRight,
                                     UserSettings.CanvasMarginRight,
                                     UserSettings.CanvasMarginBottom);
            CanvasManager.ShowXAxis = UserSettings.ShowXAxis;
            CanvasManager.ShowYAxis = UserSettings.ShowYAxis;
            CanvasManager.XAxisColor = ColorUtilities.GetColorFromHexRGBString(UserSettings.XAxisColor);
            CanvasManager.YAxisColor = ColorUtilities.GetColorFromHexRGBString(UserSettings.YAxisColor);
            CanvasManager.XAxisWidth = UserSettings.XAxisWidth;
            CanvasManager.YAxisWidth = UserSettings.YAxisWidth;
            CanvasManager.RenderXAndYAxis();
        }

        private void DrawGrid()
        {
            CanvasManager.ShowGrid = UserSettings.ShowGrid;
            CanvasManager.GridColor = ColorUtilities.GetColorFromHexRGBString(UserSettings.GridColor);
            CanvasManager.GridOpacity = 15;
            CanvasManager.GridPenWidth = 0;
            CanvasManager.GridSpacingHorizontal = 30;
            CanvasManager.GridSpacingVertical = 30;
            CanvasManager.RenderGrid();
        }

        private void DrawSkyline(Graphics gr, 
                                 GraphicsPath graphicsPath, 
                                 float _penWidth = 1.0f, 
                                 string _borderColor = "FF0000", 
                                 bool _fillIn = true, 
                                 string _fillForegroundColor = "FFFFFF",
                                 string _fillBackgroundColor = "FFFFFF")
        {
            // Draw the border
            DrawSkylineBorder(gr, graphicsPath, _penWidth, _borderColor);

            // Fill it in
            if (_fillIn)
            {
                FillSkyline(gr, graphicsPath, _fillForegroundColor, _fillBackgroundColor);
            }
        }

        private void DrawSkylineBorder(Graphics gr,
                                       GraphicsPath graphicsPath,
                                       float _penWidth = 1.0f,
                                       string _borderColor = "FF0000")
        {
            var borderColor = ColorUtilities.GetColorFromHexRGBString(_borderColor);
            using (var p = new Pen(borderColor, _penWidth))
            {
                // Ensure that the pen doesn't scale upward in size
                p.ScaleTransform(.1f, .1f);
                gr.DrawPath(p, graphicsPath);
            }
        }

        private void FillSkyline(Graphics gr, 
                                 GraphicsPath graphicsPath, 
                                 string _fillForegroundColor, 
                                 string _fillBackgroundColor)
        {
            ColorUtilities.ConvertRGBHexStringToBase10(_fillForegroundColor, out byte rF, out byte gF, out byte bF);
            ColorUtilities.ConvertRGBHexStringToBase10(_fillBackgroundColor, out byte rB, out byte gB, out byte bB);
            var foreColor = Color.FromArgb(50, rF, gF, bF);
            var backColor = Color.FromArgb(40, rB, gB, bB);

            // TODO - Put HatchStyle somewhere else as a constant (or make it user configurable)
            HatchStyle style = HatchStyle.SmallCheckerBoard;
            using (var brush = new HatchBrush(style, foreColor, backColor))
            {
                gr.FillPath(brush, graphicsPath);
            }
        }

        private void DrawDataCoordinates(Graphics gr, PathData pathData)
        {
            Color textColor = Color.White;
            var fontSize = 1.0f;

            //GraphicsState state = gr.Save();

            //gr.ResetTransform();
            //gr.ScaleTransform(10.0f, 10.0f, MatrixOrder.Prepend);
            //gr.TranslateTransform(-1.0f, -10f, MatrixOrder.Prepend);


            using (var drawFont = new System.Drawing.Font("Arial", fontSize))
            using (var drawBrush = new System.Drawing.SolidBrush(textColor))
            {
                bool nextOneIsTerminator = false;

                int arrayLength = pathData.Points.Length;
                for (int i = arrayLength - 1; i >= 0; i--)
                {
                    var x = pathData.Points[i].X;
                    var y = pathData.Points[i].Y;

                    // Since were enumerating the array backwards,
                    // we want to see if the next Y value is zero.
                    // If the next Y value is zero, then we can stop
                    // rendering values (after we complete the current one)
                    if (y == 0)
                    {
                        nextOneIsTerminator = true;
                    }

                    //var nextIndex = i - 1;
                    //if (nextIndex >= 0)
                    //{
                    //    if (pathData.Points[nextIndex].Y == 0)
                    //    {
                    //        nextOneIsTerminator = true;
                    //    }
                    //}

                    var y2 = y;
                    var drawString = $"{x}x{y}";
                    var drawFormat = new System.Drawing.StringFormat();
                    //gr.DrawString(drawString, drawFont, drawBrush, x, y2, drawFormat);

                    var rect = new RectangleF(new PointF(x, y2), new Size(2, 4));
                    var temp = new RectangleWithText(rect, drawString);
                    temp.Draw(gr);

                    if (nextOneIsTerminator == true)
                    {
                        break;
                    }
                }
            }

            //gr.Restore(state);
        }

        // Transform the Graphics object to 
        // world coordinates wxmin <= X <= wxmax, wymin <= Y <= wymax are mapped to 
        // device coordinates dxmin	<= X <=	dxmax, dymin <= Y <= dymax. 
        private void MapRectangles(Graphics gr,
                                   float wxmin, float wxmax, float wymin, float wymax,
                                   float dxmin, float dxmax, float dymin, float dymax,
                                   bool yAxisStartsAtTopLeft = false)
        {
            RectangleF worldRectangle;
            PointF[] devicePoints;
            PointF upperLeft;
            PointF upperRight;
            PointF lowerRight;

            // Make a world coordinate rectangle.
            worldRectangle = new RectangleF(wxmin, wymin, wxmax - wxmin, wymax - wymin);

            // Make PointF objects represeting the upper left, upper right,
            // and lower right corners of the device coordinates.

            if (yAxisStartsAtTopLeft)
            {
                // Origin = Top-Left
                upperLeft = new PointF(dxmin, dymin); 
                upperRight = new PointF(dxmax, dymin);
                lowerRight = new PointF(dxmin, dymax);
            }
            else
            {
                // Origin = Bottom-Left
                upperLeft = new PointF(dxmin, dymax);
                upperRight = new PointF(dxmax, dymax);
                lowerRight = new PointF(dxmin, dymin);
            }

            devicePoints = new PointF[] {
                upperLeft,
                upperRight,
                lowerRight
            };

            // If these two points are equal, don't do the transform
            // An exception will be thrown otherwise.
            if (upperLeft != lowerRight)
            {
                // Map the rectangle to the points.
                gr.Transform = new Matrix(worldRectangle, devicePoints);
            }
        }

        private RectangleF[] ConvertPointsToRectangles(PointF[] points)
        {
            List<RectangleF> rects = new List<RectangleF>();

            for(int i = 0; i<points.Length; i+=4)
            {
                PointF upperLeft = points[i + 1];
                float width = points[i + 3].X - points[i].X;
                float height = upperLeft.Y - points[i].Y;
                RectangleF r = new RectangleF(upperLeft, new SizeF(width, Math.Abs(height)));
                rects.Add(r);
            }
            return rects.ToArray();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            ReinitializeWindow();

            if (UserSettings.ShowInfoPanel)
            {
                // TODO - Set up publisher/subscriber to do this.
                InfoPanel.DockLocation = (InfoPanel.DockLocationEnum)UserSettings.InfoPanelDockingLocation;
                InfoPanel.DockToParent();
            }
        }

        private void panelCanvas_Resize(object sender, EventArgs e)
        {
            ReinitializeWindow();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Log("Application Shutting Down...");
            UserSettings.Save();

            // Clean up resources
            foreach (var p in _pens)
            {
                p.Dispose();
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new SkylineSettingsManagerForm(this, Controller))
                {
                    dlg.ShowDialogTopMost();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new AboutBox(this, Controller))
                {
                    dlg.ShowDialogTopMost();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Open Skyline Dataset File...";
            openFileDialog1.FileName = string.Empty;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filename = openFileDialog1.FileName;
                if (filename.Length > 0 && File.Exists(filename))
                {
                    UserSettings.DefaultDataFile = filename;
                    labelDefaultDataFile.Text = new FileInfo(filename).Name;
                    OptionsUpdated();
                }
            }
        }

        private void panelCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (UserSettings.ShowInfoPanel == true)
            {
                InfoPanel.SetMouseCoordinates(e.Location);
            }
        }

        private void panelCanvas_MouseWheel(object sender, MouseEventArgs e)
        {
            float minZoom = 0.1f;
            float maxZoom = 10.0f;
            float zoomIncrement = 0.1f;
            if (_ctrlPressed == true)
            {
                bool increasing = (e.Delta > 0) ? true : false;
                if (increasing)
                    _canvasZoomFactor += zoomIncrement;
                else
                    _canvasZoomFactor -= zoomIncrement;

                if (_canvasZoomFactor <= 0f)
                    _canvasZoomFactor = minZoom;

                if (_canvasZoomFactor > maxZoom)
                    _canvasZoomFactor = maxZoom;

                ReinitializeWindow();
            }

            float z = _canvasZoomFactor * 100;
            InfoPanel.SetZoomLevel(z);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            _ctrlPressed = e.Control;
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            _ctrlPressed = e.Control;
        }

        private void menuItemSkylineBorder_Click(object sender, EventArgs e)
        {
            // Need to ensure that the Skyline Fill flag is disabled if border is turned off
            menuItemSkylineFill.Enabled = menuItemSkylineBorder.Checked = !menuItemSkylineBorder.Checked;
            OptionsUpdated();
        }

        private void menuItemSkylineFill_Click(object sender, EventArgs e)
        {
            menuItemSkylineFill.Checked = !menuItemSkylineFill.Checked;
            OptionsUpdated();
        }

        private void menuItemGrid_Click(object sender, EventArgs e)
        {
            menuItemGrid.Checked = !menuItemGrid.Checked;
            OptionsUpdated();
        }

        private void menuItemXAxis_Click(object sender, EventArgs e)
        {
            menuItemXAxis.Checked = !menuItemXAxis.Checked;
            OptionsUpdated();
        }

        private void menuItemYAxis_Click(object sender, EventArgs e)
        {
            menuItemYAxis.Checked = !menuItemYAxis.Checked;
            OptionsUpdated();
        }

        private void menuItemShowDataPoints_Click(object sender, EventArgs e)
        {
            menuItemShowDataPoints.Checked = !menuItemShowDataPoints.Checked;
            OptionsUpdated();
        }

        private void checkBoxToggleInfoPanel_Click(object sender, EventArgs e)
        {
            InfoPanel.Show(checkBoxToggleInfoPanel.Checked);
        }

        private void MainForm_LocationChanged(object sender, EventArgs e)
        {
            if (UserSettings.ShowInfoPanel)
                {InfoPanel.DockToParent();}
        }

        private void labelDefaultDataFile_Format(object sender, ConvertEventArgs e)
        {
            // Customized rendering of text for label control
            // Only want to display the name of the file.
            e.Value = new FileInfo(e.Value.ToString()).Name;
        }
        #endregion

        #region Public Methods
        public void OptionsUpdated()
        {
            LogHelper.Log("MainForm:OptionsUpdated() being called.");

            ReloadData();
            DrawRawData();
            ReinitializeWindow();

            // Show/Hide the Info Panel
            InfoPanel.DockLocation = (InfoPanel.DockLocationEnum)UserSettings.InfoPanelDockingLocation;
            if (UserSettings.ShowInfoPanel)
            {
                InfoPanel.Show();
            }
            else
            {
                InfoPanel.Hide();
            }
        }
        #endregion

        #region Sandbox Methods
        private void TestBuildGridRectangle()
        {
            List<Rectangle> list = BuildGridRectangles(_canvasWidth:             panelCanvas.Width,
                                                       _canvasHeight:            panelCanvas.Height,
                                                       _blockCountHorizontal:    6,
                                                       _blockCountVertical:      5,
                                                       _gapWidth:                20,
                                                       _gapHeight:               20);
        }

        private List<Rectangle> BuildGridRectangles(int _canvasWidth,
                                                    int _canvasHeight,
                                                    int _blockCountHorizontal,
                                                    int _blockCountVertical,
                                                    int _gapWidth = 0,
                                                    int _gapHeight = 0,
                                                    int _blockWidth = 0, 
                                                    int _blockHeight = 0)
        {
            List<Rectangle> rectList = new List<Rectangle>();

            int blockWidth = (_canvasWidth - (_blockCountHorizontal + 1) * _gapWidth) / _blockCountHorizontal;
            int blockHeight = (_canvasHeight - (_blockCountVertical + 1) * _gapHeight) / _blockCountVertical;

            for (int x = 0; x < _blockCountHorizontal; x++)
            {
                for (int y = 0; y < _blockCountVertical; y++)
                {
                    Rectangle r = new Rectangle();
                    r.Width = blockWidth;
                    r.Height = blockHeight;
                    r.X = ((x+1) * _gapWidth) + (x * blockWidth);
                    r.Y = ((y+1) * _gapHeight) + (y * blockHeight);
                    rectList.Add(r);
                }
            }

            return rectList;
        }
        #endregion

        private void logViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dlg = new LogViewer(this, Controller))
                {
                    dlg.ShowDialogTopMost();
                }
            }
            catch (ArgumentNullException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK);
            }
        }
    }


    public class MenuStripRenderer : ToolStripProfessionalRenderer
    {
        public MenuStripRenderer() : base(new CustomColorTable())
        {

        }

        //protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e)
        //{
        //    // check if the object being rendered is actually a ToolStripButton
        //    if (e.Item is ToolStripButton)
        //    {
        //        ToolStripButton button = e.Item as ToolStripButton;

        //        // only render checked items differently
        //        if (button.Checked)
        //        {
        //            // fill the entire button with a color (will be used as a border)
        //            int buttonHeight = button.Size.Height;
        //            int buttonWidth = button.Size.Width;
        //            Rectangle buttonFill = new Rectangle(Point.Empty, new Size(buttonWidth, buttonHeight));
        //            e.Graphics.FillRectangle(Brushes.SteelBlue, buttonFill);

        //            // fill the entire button offset by 1,1 and height/width subtracted by 2 used as the fill color
        //            int backgroundHeight = button.Size.Height - 2;
        //            int backgroundWidth = button.Size.Width - 2;
        //            Rectangle background = new Rectangle(1, 1, backgroundWidth, backgroundHeight);
        //            e.Graphics.FillRectangle(Brushes.LightSkyBlue, background);
        //        }
        //        // if this button is not checked, use the normal render event
        //        else
        //            base.OnRenderButtonBackground(e);
        //    }
        //    // if this object is not a ToolStripButton, use the normal render event
        //    else
        //        base.OnRenderButtonBackground(e);
        //}

        protected override void OnRenderMenuItemBackground(ToolStripItemRenderEventArgs e)
        {
            var rc = new Rectangle(Point.Empty, e.Item.Size);

            var c = e.Item.Selected ? Color.Green : Color.Transparent;
            using (var brush = new SolidBrush(c))
            {
                e.Graphics.FillRectangle(brush, rc);
            }

            base.OnRenderMenuItemBackground(e);
        }
        protected override void OnRenderItemText(ToolStripItemTextRenderEventArgs e)
        {
            var rc = new Rectangle(Point.Empty, e.Item.Size);

            e.Item.ForeColor = Color.FromArgb(255, 125, 125, 125);
            e.Item.BackColor = Color.Transparent;
            base.OnRenderItemText(e);
        }
    }


    class CustomColorTable : ProfessionalColorTable
    {
        private Color DarkBackgroundColor = Color.FromArgb(15, 15, 15);

        public CustomColorTable()
        {
            // see notes
            base.UseSystemColors = false;
        }
        public override System.Drawing.Color MenuBorder
        {
            get { return Color.Black; }
        }
        public override System.Drawing.Color MenuItemBorder
        {
            get { return Color.Blue; }
        }
        public override Color MenuItemSelected
        {
            get { return Color.DarkBlue; }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return DarkBackgroundColor; }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return DarkBackgroundColor; }
        }
        public override Color MenuStripGradientBegin
        {
            get { return Color.AliceBlue; }
        }
        public override Color MenuStripGradientEnd
        {
            get { return Color.DodgerBlue; }
        }
    }

    //public class CustomColorTable : ProfessionalColorTable
    //{
    //    private Color DarkBackgroundColor = Color.FromArgb(15, 15, 15);
    //    private Color ItemSelectedDarkBackgroundColor = Color.FromArgb(45, 45, 45);

    //    public override Color MenuItemSelected
    //    {
    //        get { return ItemSelectedDarkBackgroundColor; }
    //    }
    //    public override Color ToolStripBorder
    //    {
    //        get { return DarkBackgroundColor; }
    //    }
    //    public override Color ToolStripDropDownBackground
    //    {
    //        get { return DarkBackgroundColor; }
    //    }
    //    public override Color ToolStripGradientBegin
    //    {
    //        get { return DarkBackgroundColor; }
    //    }
    //    public override Color ToolStripGradientEnd
    //    {
    //        get { return DarkBackgroundColor; }
    //    }
    //    public override Color ToolStripGradientMiddle
    //    {
    //        get { return DarkBackgroundColor; }
    //    }

    //    public override Color ImageMarginGradientBegin
    //    {
    //        get { return DarkBackgroundColor; }
    //    }
    //    public override Color ImageMarginGradientEnd
    //    {
    //        get { return DarkBackgroundColor; }
    //    }
    //    public override Color ImageMarginGradientMiddle
    //    {
    //        get { return DarkBackgroundColor; }
    //    }
    //    public override Color ImageMarginRevealedGradientBegin
    //    {
    //        get { return DarkBackgroundColor; }
    //    }
    //    public override Color ImageMarginRevealedGradientEnd
    //    {
    //        get { return DarkBackgroundColor; }
    //    }
    //    public override Color ImageMarginRevealedGradientMiddle
    //    {
    //        get { return DarkBackgroundColor; }
    //    }
    //    public override Color CheckBackground
    //    {
    //        get { return Color.FromArgb(125, 0, 0, 0); }
    //    }
    //    public override Color CheckSelectedBackground
    //    {
    //        get { return DarkBackgroundColor; }
    //    }
    //}
}
