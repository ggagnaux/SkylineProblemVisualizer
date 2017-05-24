using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KohdAndArt.Toolkit.Graphics;

namespace SkylineProblemVisualizer
{
    public class ChartCanvasManager
    {
        #region Enumerations
        public enum Axis { Y, X }
        public enum GridLineOrientation
        {
            Horizontal = 0,
            Vertical
        }
        #endregion

        #region Public Properties
        public Graphics Graphics { get; set; }
        public bool ShowXAxis { get; set; }
        public bool ShowYAxis { get; set; }
        public bool ShowGrid { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int GridSpacingX { get; set; } = 25;
        public int GridSpacingY { get; set; } = 25;
        public float GridPenWidth { get; set; } = 1.0f;
        public float ZoomFactor { get; set; } = 1.0f;
        public float MarginLeft { get; set; } = 0f;
        public float MarginRight { get; set; } = 0f;
        public float MarginTop { get; set; } = 0f;
        public float MarginBottom { get; set; } = 0f;
        public int GridOpacity { get; set; } = 20;
        public int GridSpacingHorizontal { get; set; } = 25;
        public int GridSpacingVertical { get; set; } = 25;

        private Color _gridColor;
        public Color GridColor
        {
            get
            {
                return _gridColor;
            }
            set
            {
                _gridColor = value;
                if (_penGrid != null)
                    _penGrid.Dispose();
                _penGrid = new Pen(_gridColor, GridPenWidth);
            }
        }


        private Color _XAxisColor;
        public Color XAxisColor
        {
            get
            {
                return _XAxisColor;
            }
            set
            {
                _XAxisColor = value;
                if (_penXAxis != null)
                    _penXAxis.Dispose();
                _penXAxis = new Pen(XAxisColor, XAxisWidth);
            }
        }

        private Color _YAxisColor;
        public Color YAxisColor
        {
            get
            {
                return _YAxisColor;
            }
            set
            {
                _YAxisColor = value;
                if (_penYAxis != null)
                    _penYAxis.Dispose();
                _penYAxis = new Pen(YAxisColor, YAxisWidth);
            }
        }

        private int _XAxisWidth;
        public int XAxisWidth
        {
            get
            {
                return _XAxisWidth;
            }
            set
            {
                _XAxisWidth = value;
                if (_penXAxis != null)
                    _penXAxis.Dispose();
                _penXAxis = new Pen(XAxisColor, _XAxisWidth);
            }
        }

        private int _YAxisWidth;
        public int YAxisWidth
        {
            get
            {
                return _YAxisWidth;
            }
            set
            {
                _YAxisWidth = value;
                if (_penYAxis != null)
                    _penYAxis.Dispose();
                _penYAxis = new Pen(YAxisColor, _YAxisWidth);
            }
        }
        #endregion

        #region Private Variables (Disposable Objects)
        private Pen _penXAxis;
        private Pen _penYAxis;
        private Pen _penGrid;
        #endregion

        #region Constructor(s)
        public ChartCanvasManager(int w, int h)
        {
            this.Width = w;
            this.Height = h;
            this._penXAxis = new Pen(XAxisColor, XAxisWidth);
            this._penYAxis = new Pen(YAxisColor, YAxisWidth);
        }
        #endregion


        public void SetMargins(float l, float r, float t, float b)
        {
            this.MarginLeft = l;
            this.MarginRight = r;
            this.MarginTop = t;
            this.MarginBottom = b;
        }

        public void SetCanvasDimensions(int w, int h)
        {
            this.Width = w;
            this.Height = h;
        }

        public void RenderXAndYAxis()
        {
            if (ShowXAxis) RenderXAxis();
            if (ShowYAxis) RenderYAxis();
        }

        /// <summary>
        /// 
        /// </summary>
        public void RenderYAxis()
        {
            Rectangle clientRect = new Rectangle(0, 0, Width, Height);
            Rectangle PlotArea = new Rectangle(clientRect.Location, clientRect.Size);
            PlotArea.Inflate(-(int)MarginLeft, -(int)MarginRight);
            Graphics?.DrawLine(_penYAxis, PlotArea.Left, PlotArea.Bottom, PlotArea.Left, PlotArea.Top);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RenderXAxis()
        {
            Rectangle clientRect = new Rectangle(0, 0, Width, Height);
            Rectangle PlotArea = new Rectangle(clientRect.Location, clientRect.Size);
            PlotArea.Inflate(-(int)MarginLeft, -(int)MarginRight);
            Graphics?.DrawLine(_penXAxis, PlotArea.Left, PlotArea.Bottom, PlotArea.Right, PlotArea.Bottom);
        }

        /// <summary>
        /// 
        /// </summary>
        public void RenderGrid()
        {
            if (ShowGrid)
            {
                DrawGrid();
            }
            //if (ShowGrid)
            //{
            //    var w = new WinformGraphics();
            //    var details = new DrawingDetails
            //    {
            //        Canvas = Graphics,
            //        GridSpacingHorizontal = this.GridSpacingX,
            //        GridSpacingVertical = this.GridSpacingY,
            //        PenColor = this.GridColor,
            //        PenWidth = (int)this.GridPenWidth
            //    };
            //    w.ViewportSpecs = GetViewportSpecs();
            //    w.DrawGrid(details);
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private ViewportSpecifications GetViewportSpecs()
        {
            var specs = new ViewportSpecifications();
            specs.Origin = new Point(0, 0);
            specs.Finish = new Point(Width, Height);
            return specs;
        }

        /// <summary>
        /// 
        /// </summary>
        public void TransformCanvas(Axis a)
        {
            // 
            // |-      -|
            // | 11  12 |
            // | 21  22 |
            // | 31  32 |
            // |-      -|
            var matrix = new Matrix(11, 12, 21, 22, 31, 32);

            if (a == Axis.X)
            {
                var m = new Matrix(1, 0, 0, -1, 0, 0);
                Graphics.Transform = m;
                Graphics?.TranslateTransform(Width, 0, MatrixOrder.Append);
            }
            else if (a == Axis.Y)
            {
                var m = new Matrix(1, 0, 0, -1, 0, 0);
                Graphics.Transform = m;
                Graphics?.TranslateTransform(0, Height, MatrixOrder.Append);
            }
        }

        [Obsolete]
        public void TransformCanvas()
        {
            // Flip Y Axis
            Matrix myMatrix = new Matrix(1, 0, 0, -1, 0, 0);
            Graphics.Transform = myMatrix;
            Graphics?.TranslateTransform(0, Height, MatrixOrder.Append);
        }

        [Obsolete]
        public void TransformCanvas(Graphics g)
        {
            // Flip Y Axis
            Matrix myMatrix = new Matrix(1, 0, 0, -1, 0, 0);
            g.Transform = myMatrix;
            g.TranslateTransform(0, Height, MatrixOrder.Append);
        }

        /// <summary>
        /// 
        /// </summary>
        public void FlipYAxis()
        {
            TransformCanvas(Axis.Y);
        }

        /// <summary>
        /// 
        /// </summary>
        public void FlipXAxis()
        {
            TransformCanvas(Axis.X);
        }


        public void Zoom(float zFactor)
        {
            ZoomFactor = zFactor;
            Graphics.ScaleTransform(ZoomFactor, ZoomFactor);
        }




        public void DrawGrid()
        {
            DrawLines(GridOrientation.Horizontal);
            DrawLines(GridOrientation.Vertical);
        }


        int DetermineMiddlePoint(int start, int end, int increment)
        {
            List<int> list = new List<int>();
            for (int i = start; i < end; i += increment)
            {
                list.Add(i);
            }

            int length = list.Count;
            var temp = list.ToArray()[length / 2];
            return temp;
        }

        void DrawLines(GridOrientation orientation)
        {
            int viewportHeight = this.Height - (int)this.MarginTop;
            int viewportHeightFactor = 200;
            int viewportWidth = this.Width - (int)this.MarginRight;
            int horizontalStart = (int)MarginLeft;
            int verticalStart = (int)MarginBottom;

            using (Pen p = new Pen(Color.FromArgb(this.GridOpacity, this.GridColor), this.GridPenWidth))
            {
                p.DashStyle = DashStyle.Dash;

                int incrementAmount = 0;
                if (orientation == GridOrientation.Horizontal)
                {
                    incrementAmount = GridSpacingHorizontal;
                    int verticalHalfWayPoint = DetermineMiddlePoint(0, viewportHeight, incrementAmount);

                    for (int i = verticalStart; i < viewportHeight; i += incrementAmount)
                    {
                        //if (i == verticalHalfWayPoint)
                        //{
                        //    // Draw the center line
                        //    using (var p2 = new Pen(Color.FromArgb(100, Color.Green), 2))
                        //    {
                        //        Graphics?.DrawLine(p2, 0, i, viewportWidth, i);
                        //    }
                        //}
                        //else
                        //{
                            Graphics?.DrawLine(p, horizontalStart, i, viewportWidth, i);
                        //}
                    }
                }
                else if (orientation == GridOrientation.Vertical)
                {
                    incrementAmount = this.GridSpacingHorizontal;
                    int horizontalHalfWayPoint = DetermineMiddlePoint(0, viewportWidth, incrementAmount);

                    for (int i = horizontalStart; i < viewportWidth; i += incrementAmount)
                    {
                        //if (i == horizontalHalfWayPoint)
                        //{
                        //    // Draw the center line
                        //    using (var p2 = new Pen(Color.FromArgb(100, Color.Green), 2))
                        //    {
                        //        Graphics?.DrawLine(p2, i, 0, i, viewportHeight);
                        //    }
                        //}
                        //else
                        //{
                            Graphics?.DrawLine(p, i, verticalStart, i, viewportHeight);
                        //}
                    }
                }

            }
        }
    }
}
