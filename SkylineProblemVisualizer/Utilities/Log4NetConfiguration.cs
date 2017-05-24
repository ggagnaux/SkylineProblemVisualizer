using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkylineProblemVisualizer.Utilities
{
    public class Log4NetConfiguration : ConfigurationSection
    {
        private static readonly Log4NetConfiguration Config = ConfigurationManager.GetSection("log4net") as Log4NetConfiguration;

        public static Log4NetConfiguration Instance
        {
            get
            {
                return Config;
            }
        }

        [ConfigurationProperty("autoDetect", IsRequired = true, DefaultValue = true)]
        public bool AutoDetect
        {
            get { return (bool)this["autoDetect"]; }
        }
        // all other properties
    }
}
