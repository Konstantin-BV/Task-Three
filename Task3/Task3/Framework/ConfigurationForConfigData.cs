using Microsoft.Extensions.Configuration;

namespace Task3.Framework
{
    internal static class ConfigurationForConfigData
    {
        private static string StringUrl = "url";
        private static string StringBrowser = "Browser";
        private static string StringWait = "Wait";
        private static IConfiguration ConfigurationForFile
        {
            get
            {
                var data = new ConfigurationBuilder().AddJsonFile(AppDomain.CurrentDomain.BaseDirectory + PathToTestJson).Build();
                config = data;
                return config;
            }
        }
        public static string Url => ConfigurationForFile[StringUrl];
        public static string Browser => ConfigurationForFile[StringBrowser];
        public static double Wait => double.Parse(ConfigurationForFile[StringWait]);
        private const string PathToTestJson = "Config.json";
        private static IConfiguration config;
    }
}
