using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumFramework;
using SeleniumPageObjects.Pages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumPageObjects.Tests
{
    [TestFixture]
    public class AddToCartTest :BaseTest
    {
      //  private IWebDriver Driver { get; set; }


        [Test]
        [Category("Login to the application")]
        public void LoginToSauceLab()
        {
            TestUser Thetestuser = new TestUser();

            Thetestuser.UserName = "standard_user";
            Thetestuser.PassWord = "secret_sauce";
            LoginPage Login = new LoginPage(Driver);
            Login.GoTo();
            var ProductPage = Login.LoginToApplication(Thetestuser);
             Assert.IsTrue(ProductPage.IsVisible, "Products page Page is not visible");


        }
        [Test]
        [Category("Login to the application")]
        public void AddToCart()
        {
            TestUser Thetestuser = new TestUser();

            Thetestuser.UserName = "standard_user";
            Thetestuser.PassWord = "secret_sauce";
            LoginPage Login = new LoginPage(Driver);
            Login.GoTo();
            var ProductPage = Login.LoginToApplication(Thetestuser);
            Assert.IsTrue(ProductPage.IsVisible, "Products page Page is not visible");
            AddToCartPage add = new AddToCartPage(Driver);
            add.AddToCart();
            Assert.IsTrue(add.VerifyText, "Item text is not visible");




        }
    }
}
