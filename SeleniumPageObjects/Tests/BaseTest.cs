using AutomationResources;
using NUnit.Framework;
using OpenQA.Selenium;
using Serilog;
using System;
using TestContext = NUnit.Framework.TestContext;

namespace SeleniumFramework
{
    
    [TestFixture]
    [Category("CreatingReports")]
    public class BaseTest
    {
        protected IWebDriver Driver { get; set; }
        public TestContext TestContext { get; set; }
        private ScreenshotCapture ScreenshotCapture { get; set; }
       
        [SetUp]
        public void Setup()
        {
            Log.Debug("*************************************** TEST STARTED");
            Log.Debug("*************************************** TEST STARTED");
            Reporter.StartReporter();
            
            Reporter.AddTestCaseMetadataToHtmlReport(TestContext.CurrentContext);
            var factory = new WebDriverFactory();
            Driver = factory.Create(BrowserType.Chrome);
            Driver.Manage().Window.Maximize();
            ScreenshotCapture = new ScreenshotCapture(Driver, TestContext.CurrentContext);

            var logging = new LogGenerator();
            logging.LogInit();

        }


        [TearDown]
        public void TearDownForEverySingleTestMethod()
        {
            Log.Debug(GetType().FullName + " started a method tear down");
            try
            {
                TakeScreenshotForTestFailure();
            }
            catch (Exception e)
            {
                Log.Error(e.Source);
                Log.Error(e.StackTrace);
             
                Log.Error(e.Message);
            }
            finally
            {
                StopBrowser();
                Log.Debug(TestContext.CurrentContext.Test.Name);
                Log.Debug("*************************************** TEST STOPPED");
              
            }
        }

        private void TakeScreenshotForTestFailure()
        {
            if (ScreenshotCapture != null)
            {
                ScreenshotCapture.CreateScreenshotIfTestFailed();
                Reporter.ReportTestOutcome(ScreenshotCapture.ScreenshotFilePath);
            }
            else
            {
                Reporter.ReportTestOutcome("");
            }
        }

        private void StopBrowser()
        {
            if (Driver == null)
                return;
            Driver.Quit();
            Driver = null;
            Log.Information("Browser stopped successfully.");
        }

    }
}