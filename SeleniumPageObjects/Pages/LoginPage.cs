using AventStack.ExtentReports;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq.Expressions;
using AutomationResources;
using NUnit.Framework;
using Serilog;
using SeleniumPageObjects.Pages;

namespace SeleniumFramework
{
    internal class LoginPage : BasePage
    {
        public LoginPage(IWebDriver driver) : base(driver) { }

        private IWebElement TxtUsername => Driver.FindElement(By.XPath("//*[@id='user-name']"));

        private IWebElement TxtPassword => Driver.FindElement(By.Id("password"));

        private IWebElement BtnSubmit => Driver.FindElement(By.XPath("//*[@type='submit']"));

        private string PageTitle => "Swag Labs";




        public bool IsVisible
        {
            get
            {
                try
                {
                    Reporter.LogTestStepForBugLogger(Status.Info,
                          "Validate that LoginHomePage page loaded successfully.");
                    var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
                    return wait.Until(dr => dr.Title.Contains(PageTitle));

                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }
        }
        internal void GoTo()
        {
            Driver.Navigate().GoToUrl(BaseURL);
            Assert.IsTrue(IsVisible,
                $"Sample application page is not visible. Expected =>{PageTitle}." +
                $"Actual =>{Driver.Title}");

        }
        public ProductPage LoginToApplication(TestUser user)
        {
            TxtUsername.SendKeys(user.UserName);
            TxtPassword.SendKeys(user.PassWord);
            BtnSubmit.Submit();
            Log.Information("Submit is successfull");
            return new ProductPage(Driver);
        }
    }
    

}
    

    
