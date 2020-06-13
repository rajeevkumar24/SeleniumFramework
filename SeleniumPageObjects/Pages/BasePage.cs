using OpenQA.Selenium;
using Serilog;

namespace SeleniumFramework
{
    internal abstract class BasePage
    {
        protected IWebDriver Driver { get; set; }

        protected BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        protected string BaseURL = "https://www.saucedemo.com/index.html";


    }
}