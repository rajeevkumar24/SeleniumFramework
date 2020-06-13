using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using System;
using System.IO;
using Log = Serilog.Log;

namespace AutomationResources
{
    public static class Reporter
    {
        private static AventStack.ExtentReports.ExtentReports ReportManager = new AventStack.ExtentReports.ExtentReports();

        // private static ExtentReports ReportManager { get; set; }

        private static string ApplicationDebuggingFolder => "C:\\AutomationTools\\CreateReports";

        private static string HtmlReportFullPath{ get; set; }

        public static string LatestResultsReportFolder { get; set; }

        private static TestContext MyTestContext { get; set; }

        private static ExtentTest CurrentTestCase { get; set; }

        public static void StartReporter()
        {
            Log.Information("Starting a one time setup for the entire" +
                             " .CreatingReports namespace." +
                             "Going to initialize the reporter next...");
            CreateReportDirectory();
            var htmlReporter = new ExtentHtmlReporter(HtmlReportFullPath);
            ReportManager = new AventStack.ExtentReports.ExtentReports();
            ReportManager.AttachReporter(htmlReporter);


        }


        private static void CreateReportDirectory()
        {
            var filePath = Path.GetFullPath(ApplicationDebuggingFolder);
            LatestResultsReportFolder = Path.Combine(filePath, DateTime.Now.ToString("MMdd_HHmm"));
            Directory.CreateDirectory(LatestResultsReportFolder);

            HtmlReportFullPath = $"{LatestResultsReportFolder}\\TestResults.html";
            Log.Information("Full path of HTML report=>" + HtmlReportFullPath);
        }
        public static void AddTestCaseMetadataToHtmlReport(TestContext testContext)
        {
            MyTestContext = testContext;
       
            CurrentTestCase = ReportManager.CreateTest(MyTestContext.Test.Name);
        }
        public static void LogPassingTestStepToBugLogger(string message)
        {
            Log.Information(message);
            CurrentTestCase.Log(Status.Pass, message);
        }

        public static void ReportTestOutcome(string screenshotPath)
        {
            var status = MyTestContext.Result.Outcome.Status;

           
            switch (status)
            {
                
                case TestStatus.Failed:
                    Log.Error($"Test Failed=>{MyTestContext.Test.Name}");
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Fail("Fail");
                    break;
                case TestStatus.Inconclusive:
                    CurrentTestCase.AddScreenCaptureFromPath(screenshotPath);
                    CurrentTestCase.Warning("Inconclusive");
                    break;
                case TestStatus.Skipped:
                    CurrentTestCase.Skip("Test skipped");
                    break;
                default:
                    CurrentTestCase.Pass("Pass");
                    break;
            }

            ReportManager.Flush();
        }

        public static void LogTestStepForBugLogger(Status status, string message)
        {
            Log.Information(message);
            CurrentTestCase.Log(status, message);
        }
    }
}
