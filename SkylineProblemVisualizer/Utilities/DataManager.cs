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
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;

namespace SkylineProblemVisualizer.Utilities
{
    public class DataManager
    {
        public IList<BuildingCoordinates> InputData { get; set; }
        public PathData                   OutputPathData { get; set; }

        private string _filename;
        public string Filename
        {
            get
            {
                return _filename;
            }
            set
            {
                _filename = value;
                if (_filename.Length > 0)
                {
                    Load();
                }
            }
        }

        public int MaximumX { get; set; }
        public int MaximumY { get; set; }


        private static DataManager _instance = null;
        public static DataManager GetInstance(string filename)
        {
            if (_instance == null)
            {
                _instance = new DataManager(filename);
            }
            return _instance;
        }

        private DataManager(string filename)
        {
            this.Filename = filename;
            Load();
        }

        private void Load()
        {
            const char itemSeparator = ' ';

            if (Filename.Length == 0 || File.Exists(Filename) == false)
                throw new ArgumentException($"Filename not specified or file '{Filename}' not found.");

            var line = string.Empty;
            var list = new List<BuildingCoordinates>();

            try
            {
                using (var file = new StreamReader(Filename))
                {
                    while ((line = file.ReadLine()) != null && (line.Length > 0))
                    {
                        string[] temp = line.Split(itemSeparator);
                        var l = Convert.ToInt32(temp[0]);
                        var h = Convert.ToInt32(temp[1]);
                        var r = Convert.ToInt32(temp[2]);
                        list.Add(new BuildingCoordinates(l, h, r));
                    }
                }

                // Determine the maximum X and Y for all of the data
                MaximumX = list.Max(a => a.Right);
                MaximumY = list.Max(a => a.Height);
            }
            catch (IndexOutOfRangeException e1)
            {
                throw new ApplicationException("Invalid file format.");
            }


            InputData = list;
        }

        public void WriteOutputPathDataToFile(PathData _outputPathData)
        {
            OutputPathData = _outputPathData;

            // Build an output filename based on the source filename
            FileInfo fi = new FileInfo(Filename);
            string targetFilename = $"outputdata_{fi.Name}";

            // Sort the data array 
            List<PointF> pointList = new List<PointF>();
            pointList.AddRange(this.OutputPathData.Points);
            pointList = pointList.OrderBy(p => p.X).ToList();
            PointF[] dataPoints = pointList.ToArray<PointF>();

            // Save the path data points to a file
            using (var sw = File.CreateText(targetFilename))
            {
                for (int j = 0; j < dataPoints.Length; ++j)
                {
                    sw.WriteLine(BuildLine(dataPoints[j]));
                }
                sw.Close();
            }

            // Only added this to demonstrate use of inner methods
            // In this particular instance it isn't really necessary :)
            string BuildLine(PointF point)
            {
                return $"{point.X} {point.Y}";
            }
        }
    }
}
