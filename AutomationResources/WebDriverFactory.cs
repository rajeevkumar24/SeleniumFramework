using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Serilog;
using Serilog.Core;
using System;
using System.IO;
using System.Reflection;

namespace AutomationResources
{
    public class WebDriverFactory
    {
       

        public IWebDriver Create(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Chrome:
                    return GetChromeDriver();
                  
                  

                default:
                    throw new ArgumentOutOfRangeException(" no such browser exist");
            }
        }

        private IWebDriver GetChromeDriver()
        {
            
            var outPutDirectory = GetAssemblysOutputDirectory();
            var directoryWithChromeDriver = CreateFilePathForNetCoreApps(outPutDirectory);
            if (string.IsNullOrEmpty(directoryWithChromeDriver))
            {
                directoryWithChromeDriver = CreateFilePathForNetCoreApps(outPutDirectory);
            }
            return new ChromeDriver(directoryWithChromeDriver);
        }

        private static string CreateFilePathForNetCoreApps(string outPutDirectory)
        {
            var resourcesDirectory = "";
            if (outPutDirectory != null && outPutDirectory.Contains("netcoreapp"))
                resourcesDirectory = Path.GetFullPath(Path.Combine(outPutDirectory, @"..\..\..\..\AutomationResources\bin\Debug\netcoreapp3.1"));
            return resourcesDirectory;
        }

        private static string GetAssemblysOutputDirectory()
        {
            return Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        }
    }
}