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
    public static class BuildingUtilities
    {
        public static bool AreOverlapping(BuildingCoordinates b1, BuildingCoordinates b2, out int[] resultingBuildingProfile)
        {
            bool isOverlapping = false;
            Rectangle r1 = GetRectangleFromBuildingCoordinate(b1);
            Rectangle r2 = GetRectangleFromBuildingCoordinate(b2);

            // Are these intersecting (overlapping)?
            Rectangle r3 = Rectangle.Intersect(r1, r2);
            isOverlapping = !r3.IsEmpty;

            Rectangle r4 = Rectangle.Union(r1, r2);


            //Create a simple region.
            Region region1 = new Region(r1);

            // Extract the region data.
            System.Drawing.Drawing2D.RegionData region1Data = region1.GetRegionData();
            byte[] data1;
            data1 = region1Data.Data;



            //var region = new Region(r1);
            //region.Exclude(r2);

            resultingBuildingProfile = null;
            return isOverlapping;
        }


        private static Rectangle GetRectangleFromBuildingCoordinate(BuildingCoordinates b)
        {
            return new Rectangle(b.Left, 0, b.Right - b.Left, b.Height);
        }
    }
}
