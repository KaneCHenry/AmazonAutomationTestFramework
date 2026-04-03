using AmazonAutomationTestFramework.Project.Tests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Reqnroll;

namespace AmazonAutomationTestFramework.Project.Hooks
{
    [Binding]
    public class Hooks
    {
        private readonly ScenarioContext _scenarioContext;   

        public Hooks(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = new ChromeDriver();
            driver.Manage().Window.Maximize();

            _scenarioContext.Set(driver, "WebDriver");
        }

        [AfterScenario]
        public void AfterScenario()
        {
            var driver = _scenarioContext.Get<IWebDriver>("WebDriver");
            driver.Quit();  
        }
    }
}
