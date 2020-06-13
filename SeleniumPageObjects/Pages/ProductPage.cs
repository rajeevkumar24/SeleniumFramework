using OpenQA.Selenium;
using SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPageObjects.Pages
{
    class ProductPage :BasePage
    {
        public ProductPage(IWebDriver driver) : base(driver) { }

        public IWebElement LblProducts => Driver.FindElement(By.XPath("//*[@id='item_4_title_link']/div"));

        public bool IsVisible => LblProducts.Displayed;

    }
}
