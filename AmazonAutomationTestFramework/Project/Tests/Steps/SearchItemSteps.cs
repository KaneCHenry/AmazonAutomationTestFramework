using AmazonAutomationTestFramework.Project.Tests.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace AmazonAutomationTestFramework.Project.Tests.Steps
{
    [Binding]
    public class AmazonSteps
    {
        private readonly IWebDriver _driver;

        public AmazonSteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>("WebDriver");
        }

        [Given("User is on the amazon homepage")]
        public void GivenUserIsOnTheAmazonHomepage()
        {
            //Go to site url
           var commonBasePage = new CommonBasePage(_driver);
            commonBasePage.GoToBaseUrl();
           //Accept cookies
           var cookie = new cookieBanner(_driver);
            cookie.AcceptCookiesIfPresent();
            //validate components
           var homePage = new Homepage(_driver);
           homePage.commonpagecomponents();
        }
        [When("the user types an item into the search field")]
        public void WhenTheUserTypesAnItemIntoTheSearchField()
        {
           var homePage = new Homepage(_driver);
            homePage.SearchItem(Items.phone);
        }
        [Then("item is displayed in the search result")]
        public void ThenItemIsDisplayedInTheSearchResult()
        {
            var result = new SearchResultPage(_driver);
            //result.validateSearchResult();
        }
    }
}
