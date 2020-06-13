using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;


namespace AutomationResources
{
    class Config
    {
        public static string Platform => GetValue("Platform");
        public static string BaseUrl => GetValue("BaseUrl");
        public static string Username => GetValue("Username");
        public static string Password => GetValue("Password");

        private static string GetValue(string value)
        {
            var dirName = AppContext.BaseDirectory.Substring(0, AppContext.BaseDirectory.IndexOf("bin"));
            var fileInfo = new FileInfo(dirName);
            var parentDirName = fileInfo?.FullName;

            var builder = new ConfigurationBuilder()
                .SetBasePath(parentDirName)
                .AddJsonFile("appsettings.json");
            return builder.Build()[value];
        }
    }
}
