using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkylineProblemVisualizer.Utilities
{
    public class FlickerFreePanel : Panel
    {
        public FlickerFreePanel()
        {
            this.DoubleBuffered = true;
            //typeof(Panel).InvokeMember("DoubleBuffered",
            //    BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
            //    null, panelCanvas, new object[] { true });
        }
    }
}
