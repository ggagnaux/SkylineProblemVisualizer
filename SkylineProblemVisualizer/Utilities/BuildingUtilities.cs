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
