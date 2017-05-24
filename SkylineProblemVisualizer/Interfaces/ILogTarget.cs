using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylineProblemVisualizer.Interfaces
{
    public interface ILogTarget
    {
        void LogToControl(string text);
    }
}
