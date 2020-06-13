using NUnit.Framework;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace AutomationResources
{
    public class ScreenshotCapture
    {
        private readonly IWebDriver _driver;

        private readonly TestContext _testContext;
        public string ScreenshotFilePath { get; set; }
        private string ScreenshotFileName { get; set; }

        public ScreenshotCapture(IWebDriver driver, TestContext testContext)
        {
            if (driver == null)
                return;
            _driver = driver;
            _testContext = testContext;
            ScreenshotFileName = _testContext.Test.Name;
        }

        public void CreateScreenshotIfTestFailed()
        {
            if (_testContext.Result.Outcome.Status == TestStatus.Failed ||
                _testContext.Result.Outcome.Status == TestStatus.Inconclusive)
                TakeScreenshotForFailure();
        }

        public string TakeScreenshot(string screenshotFileName)
        {
            var ss = GetScreenshot();
            var successfullySaved = TryToSaveScreenshot(screenshotFileName, ss);

            return successfullySaved ? ScreenshotFilePath : "";
        }

        public bool TakeScreenshotForFailure()
        {
            ScreenshotFileName = $"FAIL_{ScreenshotFileName}";

            var ss = GetScreenshot();
            var successfullySaved = TryToSaveScreenshot(ScreenshotFileName, ss);
            if (successfullySaved)
                Log.Error($"Screenshot Of Error=>{ScreenshotFilePath}");
            return successfullySaved;
        }

        private Screenshot GetScreenshot()
        {
            return ((ITakesScreenshot)_driver)?.GetScreenshot();

            
        }

        private bool TryToSaveScreenshot(string screenshotFileName, Screenshot ss)
        {
            try
            {
                SaveScreenshot(screenshotFileName, ss);
                return true;
            }
            catch (Exception e)
            {
                Log.Error(e.InnerException.ToString());
                Log.Error(e.Message);
                Log.Error(e.StackTrace);
                return false;
            }
        }

        private void SaveScreenshot(string screenshotName, Screenshot ss)
        {
            if (ss == null)
                return;
            ScreenshotFilePath = $"{Reporter.LatestResultsReportFolder}\\{screenshotName}.jpg";
            ScreenshotFilePath = ScreenshotFilePath.Replace('/', ' ').Replace('"', ' ');
            ss.SaveAsFile(ScreenshotFilePath, ScreenshotImageFormat.Png);
        }
    }

}

