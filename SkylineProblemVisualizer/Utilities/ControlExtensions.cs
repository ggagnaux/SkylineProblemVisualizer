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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkylineProblemVisualizer.Utilities
{
    public static class ControlExtensions
    {
        public static IEnumerable<Control> GetAllByType(this object control, Type type)
        {
            var controls = ((Control)control).Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAllByType(ctrl, type))
                                      .Concat(controls)
                                      .Where(c => c.GetType() == type);
        }

        public static IEnumerable<Control> GetAll(this object control)
        {
            var controls = ((Control)control).Controls.Cast<Control>();
            return controls.SelectMany(ctrl => GetAll(ctrl))
                                      .Concat(controls);
        }

        public static bool HasMethod(this object objectToCheck, string methodName)
        {
            var type = objectToCheck.GetType();
            return type.GetMethod(methodName) != null;
        }

        public static bool HasProperty(this object objectToCheck, string propName)
        {
            var type = objectToCheck.GetType();
            return type.GetProperty(propName) != null;
        }
    }
}
