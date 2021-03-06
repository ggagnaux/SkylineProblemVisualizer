﻿#region Copyright (c) 2017 G. Gagnaux, https://github.com/ggagnaux/SkylineProblemVisualizer
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
using log4net;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using SkylineProblemVisualizer.Interfaces;
using SkylineProblemVisualizer.UI;

namespace SkylineProblemVisualizer.Utilities
{
    public static class LogHelper
    {
        public static string LogFileName        = @"SkylineVisualizer.log";
        public static string MaximumFileSize    = "1MB";
        public static string HeaderMarker       = "START:";
        public static string FooterMarker       = "END:";

        public struct LogColumns
        {
            public string Label;
            public string FieldSpecifier;

            public LogColumns(string _label, string _fieldSpec)
            {
                this.Label = _label;
                this.FieldSpecifier = _fieldSpec;
            }
        };

        public static IEnumerable<LogColumns> LoggerColumns = new List<LogColumns>()
        {
            new LogColumns("Date/Time", "%date"),
            new LogColumns("User",      "%username"),
            new LogColumns("Log Level", "%level"),
            new LogColumns("Logger",    "%logger"),
            new LogColumns("Details",   "%message"),
        };

        private class CustomPatternLayout : PatternLayout
        {
            private readonly string DateFormatter = "yyyy-MM-dd HH:mm:ss";
            public override string Header
            {
                get
                {
                    var dateString = DateTime.Now.ToString(DateFormatter);
                    return string.Format($"\r\n{HeaderMarker}  {dateString}\r\n");
                }
            }

            public override string Footer
            {
                get
                {
                    var dateString = DateTime.Now.ToString(DateFormatter);
                    return string.Format($"{FooterMarker}  {dateString}\r\n");
                }
            }
        }

        public static string LayoutPattern;
        private static bool _initialized = false;
        private static readonly ILog _Logger;
        public static List<ILogTarget> _extraLoggingTargets = new List<ILogTarget>();

        public static void Setup()
        {
            if (!_initialized)
            {
                LayoutPattern = BuildLayoutPattern();

                Hierarchy hierarchy = (Hierarchy)LogManager.GetRepository();

                CustomPatternLayout patternLayout = new CustomPatternLayout();
                patternLayout.ConversionPattern = LayoutPattern;
                patternLayout.ActivateOptions();

                RollingFileAppender logFileAppender = new RollingFileAppender();
                logFileAppender.AppendToFile = true;
                logFileAppender.File = LogFileName;
                logFileAppender.Layout = patternLayout;
                logFileAppender.MaxSizeRollBackups = 5;
                logFileAppender.MaximumFileSize = MaximumFileSize;
                logFileAppender.RollingStyle = RollingFileAppender.RollingMode.Size;

                logFileAppender.PreserveLogFileNameExtension = true;
                logFileAppender.StaticLogFileName = true;
                logFileAppender.ActivateOptions();

                

                //LevelMap lm = new LevelMap();
                //Level levelDEBUG = new Level(0, "DEBUG", "Debug");
                //Level levelINFO = new Level(1, "INFO",  "Information");
                //Level levelWARN = new Level(2, "WARN",  "Warning");
                //Level levelERROR = new Level(3, "ERROR", "Error");
                //Level levelFATAL = new Level(4, "FATAL", "Fatal");
                //lm.Add(levelDEBUG);
                //lm.Add(levelINFO);
                //lm.Add(levelWARN);
                //lm.Add(levelERROR);
                //lm.Add(levelFATAL);



                //< mapping >
                //< level value = "DEBUG" />
                //< backColor value = "Blue" />
                //</ mapping >
                //< mapping >
                //< level value = "INFO" />
                //< backColor value = "Green" />
                //</ mapping >
                //< mapping >
                //< level value = "WARN" />
                //< backColor value = "Yellow" />
                //</ mapping >
                //< mapping >
                //< level value = "ERROR" />
                //< backColor value = "Red" />
                //</ mapping >
                //< mapping >
                //< level value = "FATAL" />
                //< backColor value = "Red, HighIntensity" />
                //</ mapping >




                hierarchy.Root.AddAppender(logFileAppender);

                //hierarchy.Root.Level = Level.Info;
                hierarchy.Root.Level = Level.Debug;
                hierarchy.Configured = true;

                _initialized = true;
            }
        }

        private static string BuildLayoutPattern()
        {
            var sb = new StringBuilder();
            foreach (var item in LoggerColumns)
            {
                sb.Append(item.FieldSpecifier);
                sb.Append(" | ");
            }
            sb.Remove(sb.Length - 2, 2);
            sb.Append(@"%newline");
            return sb.ToString();
        }

        private static ILog GetLogger(string logName)
        {
            ILog log = LogManager.GetLogger(logName);
            return log;
        }

        private static ILog GetLogger(string logName, InfoPanel _infoPanel)
        {
            //_InfoPanel = _infoPanel;
            ILog log = LogManager.GetLogger(logName);
            return log;
        }

        static LogHelper()
        {
            Setup();

            //_Logger = GetLogger("FileLogger");
            _Logger = LogManager.GetLogger(typeof(Logger));
        }

        public static void Log(string msg)
        {
            _Logger.DebugFormat(msg);
            LogToExtraTargets(msg);
        }

        public static void LogDebug(string msg)
        {
            _Logger.DebugFormat(msg);
            LogToExtraTargets(msg);
        }

        public static void LogInfo(string msg)
        {
            _Logger.InfoFormat(msg);
            LogToExtraTargets(msg);
        }

        public static void LogWarning(string msg)
        {
            _Logger.WarnFormat(msg);
            LogToExtraTargets(msg);
        }

        public static void LogError(string msg)
        {
            _Logger.ErrorFormat(msg);
            LogToExtraTargets(msg);
        }

        public static void LogFatal(string msg)
        {
            _Logger.FatalFormat(msg);
            LogToExtraTargets(msg);
        }

        public static void LogException(string msg, Exception ex = null)
        {
            string message = string.Empty;
            if (msg.Length > 0)
            {
                message = msg + Environment.NewLine + ex.ToString();
            }
            else
            {
                message = ex.ToString();
            }
            _Logger.ErrorFormat(message);
            LogToExtraTargets(message);
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
