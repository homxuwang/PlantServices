using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PlatformServices
{
    public static class IniConfig
    {
        public static void StartIniDatabaseConfig()
        {
            Platform.Core.DatabaseConfig.DefaultDatabaseName = System.Configuration.ConfigurationManager.AppSettings["defaultDatabase"];
        }
    }
}