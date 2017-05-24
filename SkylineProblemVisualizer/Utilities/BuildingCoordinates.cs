using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylineProblemVisualizer
{
    public class BuildingCoordinates
    {
        public int Left { get; set; }
        public int Right { get; set; }
        public int Height { get; set; }

        public int X1 { get { return Left; } }
        public int Y1 { get { return Height; } }
        public int X2 { get { return Right; } }
        public int Y2 { get { return 0; } }

        public int Width
        {
            get
            {
                return Right - Left;
            }
        }

        public BuildingCoordinates(int l, int h, int r)
        {
            this.Left = l;
            this.Height = h;
            this.Right = r;
        }

        public Rectangle GetRectangle()
        {
            return new Rectangle(this.Left, 0, this.Width, this.Height);
        }

        public Rectangle GetScaledRectangle(int canvasWidth, int canvasHeight, int XMax, int YMax)
        {
            BuildingCoordinates b = GetScaledCoordinates(canvasWidth, canvasHeight, XMax, YMax);
            return b.GetRectangle();
        }

        public BuildingCoordinates GetScaledCoordinates(int canvasWidth, int canvasHeight, int XMax, int YMax)
        {
            int left, height, right;
            left = ScaleX(this.Left, canvasWidth, XMax);
            right = ScaleX(this.Right, canvasWidth, XMax);
            height = ScaleY(this.Height, canvasHeight, YMax);
            BuildingCoordinates b = new BuildingCoordinates(left, height, right);
            return b;
        }

        public bool AreOverlapping(BuildingCoordinates b1, BuildingCoordinates b2, out int[] combined)
        {
            List<int> coordinateList = new List<int>();

            Rectangle r1 = b1.GetRectangle();
            Rectangle r2 = b2.GetRectangle();

            bool intersects = r1.IntersectsWith(r2);
            if (intersects)
            {
                // Left side of first building
                coordinateList.Add(b1.X1);
                coordinateList.Add(b1.Y1);

                combined = null;
            }
            else
            {
                // Now calculate the X, Y, X, Y, ... coordinate list
                coordinateList.Add(b1.X1);
                coordinateList.Add(b1.Y1);
                coordinateList.Add(b1.X2);
                coordinateList.Add(b1.Y2);

                coordinateList.Add(b2.X1);
                coordinateList.Add(b2.Y1);
                coordinateList.Add(b2.X2);
                coordinateList.Add(b2.Y2);

                combined = coordinateList.ToArray();
            }

            return intersects;
        }


        private int ScaleX(int x, int canvasWidth, int maxX)
        {
            return (canvasWidth / maxX) * x;
        }

        private int ScaleY(int y, int canvasHeight, int maxY)
        {
            return (canvasHeight / maxY) * y;
        }
    }
}
