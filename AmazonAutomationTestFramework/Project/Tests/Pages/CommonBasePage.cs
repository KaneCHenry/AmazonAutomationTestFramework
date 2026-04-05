using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace AmazonAutomationTestFramework.Project.Tests.Pages
{
     public class CommonBasePage
        {
            protected readonly IWebDriver Driver;
            protected WebDriverWait Wait { get; }

            public CommonBasePage(IWebDriver Driver)
            {
                this.Driver = Driver;
                Wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10));
            }
       public class Homepage(IWebDriver driver) : CommonBasePage(driver)
        {
        }

        private static string BaseUrl = PathConfig.BaseUrl;
        
        public void GoToBaseUrl()
        {
            Driver.Navigate().GoToUrl(BaseUrl);
        }
        public void VerifyBaseUrl()
        {
            if (!Driver.Url.Contains(BaseUrl))
            {
                throw new Exception("error with the targetted base url");
            }
        }
        public void Click(By locator)
        {
            Driver.FindElement(locator).Click();
        }
        public void WaitUntilClickable(By locator)
        {
            Wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }
        public void Typer(By locator, string text)
        {
            Driver.FindElement(locator).SendKeys(text);
        }
        protected void assertIsDisplayed(By locator)
        {
            var isElementDisplayed = Driver.FindElement(locator).Displayed;
            Assert.That(isElementDisplayed, Is.True);
        }
        protected void Type(By locator, string text)
        {
            Driver.FindElement(locator).SendKeys(text);
        }
        protected void WaitUntilVisible(By locator)
        {
            Wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }
        protected void WebPageLoad()
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(10);
        }
        protected string GetText(By locator)
        {
            var elementText = Driver.FindElement(locator).Text;
            return elementText;
        }
        protected void ScrollToElement(By locator)
        {
            var element = Driver.FindElement(locator);

            ((IJavaScriptExecutor)Driver)
                .ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        protected IWebElement Find(By locator)
        {
            return Wait.Until(d => d.FindElement(locator));
        }
        public void ScrollAndClickResult(By locator)
        {
            ScrollToElement(locator);
            WaitUntilClickable(locator);
        }


        protected void SearchForProduct(string productname)
        {
            
        }
    }
}
      
