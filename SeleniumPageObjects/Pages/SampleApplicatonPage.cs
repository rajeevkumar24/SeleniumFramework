//using NUnit.Framework;
//using OpenQA.Selenium;
//using Serilog;
//using System;
//using AutomationResources;

//namespace SeleniumFramework
//{
//    internal class SampleApplicatonPage :BasePage
//    {
       
        

//        public SampleApplicatonPage(IWebDriver driver):base(driver){       
//        }
//        public IWebElement FirstNameField => Driver.FindElement(By.Name("firstname"));
//        public IWebElement LastNameField => Driver.FindElement(By.Name("lastname"));
//        public IWebElement SubmitButton => Driver.FindElement(By.XPath("//*[@type ='submit']"));

//        public string PageTitle => "Sample Application Lifecycle";

//        public IWebElement FemaleGenderButton => Driver.FindElement(By.XPath("//*[@value ='female']"));

//        public IWebElement FemaleGenderButtonEmeregency => Driver.FindElement(By.Id("radio2-f"));

//        public IWebElement FirstNameFieldEmeregencyContact => Driver.FindElement(By.Id("f2"));
//        public IWebElement LastNameFieldEmeregencyContact => Driver.FindElement(By.Id("l2"));

//        public bool? IsVisible
//        {
//            get
//            {
//                return Driver.Title.Contains(PageTitle);
              
               
//            }
           
           
//        }
        
     

//        internal void GoTo()
//        {
//            Driver.Navigate().GoToUrl("https://ultimateqa.com/sample-application-lifecycle-sprint-4/");
//            Assert.IsTrue(IsVisible, 
//                $"Sample application page is not visible. Expected =>{PageTitle}." +
//                $"Actual =>{Driver.Title}");
            
//        }

//        internal void FillOutEmergecyContact(TestUser emergencyContactUser)
//        {
//            SetEmeregencyContactGeneder(emergencyContactUser);
//            FirstNameFieldEmeregencyContact.SendKeys(emergencyContactUser.FirstName);
//            LastNameFieldEmeregencyContact.SendKeys(emergencyContactUser.LastName);
//            SubmitButton.Submit();
//            Log.Information("Submit is successfull");
//        }

//        private void SetEmeregencyContactGeneder(TestUser emergencyContactUser)
//        {
//            switch (emergencyContactUser.GenderType)
//            {
//                case Gender.Male:
//                    break;
//                case Gender.Female:
//                    FemaleGenderButtonEmeregency.Click();
//                    break;
//                case Gender.Other:
//                    break;
//                default:
//                    break;
//            }
//        }

//        internal ultimateHomepage FilloutAndSubmitPrimary(TestUser user)
//        {
//            SetGeneder(user);
//            FirstNameField.SendKeys(user.FirstName);
//            LastNameField.SendKeys(user.LastName);
//            SubmitButton.Submit();
//            Log.Information("Submit is successfull");
//            return new ultimateHomepage(Driver);
          
//        }

//        private void SetGeneder(TestUser user)
//        {
//            switch (user.GenderType)
//            {
//                case Gender.Male:
//                    break;
//                case Gender.Female:
//                    FemaleGenderButton.Click();
//                    break;
//                case Gender.Other:
//                    break;
//                default:
//                    break;
//            }
//        }

       
//    }
//}