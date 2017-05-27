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
