using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using SkylineProblemVisualizer.Interfaces;
using SkylineProblemVisualizer.UI;

namespace SkylineProblemVisualizer.Utilities
{
    public static class Logger
    {
        private static bool _initialized = false;

        public static List<ILogTarget> _extraLoggingTargets = new List<ILogTarget>();

        private static readonly ILog _Logger = LogManager.GetLogger(typeof(Logger));

        // TODO - Need to get rid of this.
        private static InfoPanel _InfoPanel = null;

        public static void Setup()
        {
            if (!_initialized)
            {
                Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

                PatternLayout patternLayout = new PatternLayout();
                patternLayout.ConversionPattern = "%date | %username | %level | %logger | %message | %exception%newline";
                patternLayout.ActivateOptions();

                RollingFileAppender roller = new RollingFileAppender();
                roller.AppendToFile = true;
                roller.File = @"SkylineVisualizer.log";
                roller.Layout = patternLayout;
                roller.MaxSizeRollBackups = 5;
                roller.MaximumFileSize = "1MB";
                roller.RollingStyle = RollingFileAppender.RollingMode.Size;
                roller.StaticLogFileName = true;
                roller.ActivateOptions();
                hierarchy.Root.AddAppender(roller);

                //MemoryAppender memory = new MemoryAppender();
                //memory.ActivateOptions();
                //hierarchy.Root.AddAppender(memory);

                hierarchy.Root.Level = Level.Info;
                hierarchy.Configured = true;

                _initialized = true;
            }
        }

        private static ILog GetLogger(string logName)
        {
            ILog log = LogManager.GetLogger(logName);
            return log;
        }

        private static ILog GetLogger(string logName, InfoPanel _infoPanel)
        {
            _InfoPanel = _infoPanel;
            ILog log = LogManager.GetLogger(logName);
            return log;
        }

        static Logger()
        {
            Setup();
            //_Logger = GetLogger("FileLogger");
        }

        public static void Log(string msg)
        {
            _Logger.DebugFormat(msg);
            LogToExtraTargets(msg);
        }

        public static void LogMessage(string msg)
        {
            _Logger.InfoFormat(msg);
            LogToExtraTargets(msg);
        }

        private static void LogToExtraTargets(string msg)
        {
            foreach (var logTarget in _extraLoggingTargets)
            {
                ((ILogTarget)logTarget).LogToControl(msg);
            }
        }

        public static void AddLogTarget(ILogTarget _target)
        {
            _extraLoggingTargets.Add(_target);
        }
    }
}
