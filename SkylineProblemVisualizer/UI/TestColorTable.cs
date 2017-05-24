using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SkylineProblemVisualizer.UI
{
    public class TestColorTable : ProfessionalColorTable
    {
        public override Color MenuItemSelected
        {
            get { return Color.FromArgb(20, 0, 0, 0); }
        }

        public override Color MenuBorder  //added for changing the menu border
        {
            get { return Color.Black; }
        }
    }
}
