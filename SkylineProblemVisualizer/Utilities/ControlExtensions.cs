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
