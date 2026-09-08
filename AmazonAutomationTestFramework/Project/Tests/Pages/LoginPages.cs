using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AmazonAutomationTestFramework.Project.Tests.Pages
{
    public class LoginPages(IWebDriver driver) : CommonBasePage(driver)
    {

        public class SignInEmailNumber(IWebDriver driver) : CommonBasePage(driver)
        {
            private By emailLocator => By.Id("ap_email");
            private By continueBtn => By.Id("continue");


            public void EnterUsername(string username) => driver.FindElement(emailLocator).SendKeys(username);
            public void ClickContinue() => Driver.FindElement(continueBtn).Click(); 

            public void NavigateSignUser(string username)
            {
                EnterUsername(username);
                ClickContinue();
            }
        }
        public class SignInPassword(IWebDriver driver) : CommonBasePage(driver)
        {
            private By passwordFieldLocator => By.Id("ap_password");
            private By signInBtn => By.Id("signInSubmit");  

            public void EnterPassword(string password) => driver.FindElement(passwordFieldLocator).SendKeys(password);
            public void ClickSignIn() => Driver.FindElement(signInBtn).Click();
        }
    }
    
    
}
