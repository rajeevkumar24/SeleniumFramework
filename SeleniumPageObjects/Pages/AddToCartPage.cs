using AutomationResources;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumFramework;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumPageObjects.Pages
{
     class AddToCartPage :BasePage
    {
        public AddToCartPage(IWebDriver driver) : base(driver) { }
        private IWebElement FirstElementAddToCart => 
            Driver.FindElement(By.CssSelector("#inventory_container > div > div:nth-child(1) > div.pricebar > button"));

        private IWebElement ShoppingCartContainer => Driver.FindElement(By.Id("shopping_cart_container"));

        private IWebElement FirstElementTitle => Driver.FindElement(By.LinkText(" Sauce Labs Backpack"));


        internal void AddToCart()
        {
            FirstElementAddToCart.Click();
            ShoppingCartContainer.Click();
           
        }

        public bool VerifyText
        {
            get
            {
                var LblText = Driver.FindElement(By.LinkText("Sauce Labs Backpack")).Displayed;
                //.Contains("complicated-page");
                Reporter.LogTestStepForBugLogger(Status.Info, "Check whether the Lable text is displayed successfully");
                return LblText;
            }

        }
    }
   
}
