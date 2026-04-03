using OpenQA.Selenium;

namespace AmazonAutomationTestFramework.Project.Tests.Pages
{
    public class cookieBanner(IWebDriver driver) : CommonBasePage(driver)
    {
        private By cookieBannerSection => By.Id("cos-banner");
        private By AcceptCookies => By.Id("sp-cc-accept");
        public void AcceptCookiesIfPresent()
        {
            try
            {
                var acceptButton = Wait.Until(d => d.FindElement(AcceptCookies));

                try
                {
                    acceptButton.Click();
                }
                catch
                {
                    ((IJavaScriptExecutor)driver)
                        .ExecuteScript("arguments[0].click();", acceptButton);
                }
            }
            catch
            {
                // banner not present → continue
            }
        }

    }
}
        
    

        
