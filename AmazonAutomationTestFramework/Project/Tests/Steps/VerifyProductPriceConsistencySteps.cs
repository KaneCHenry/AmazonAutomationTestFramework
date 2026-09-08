using AmazonAutomationTestFramework.Project.Tests.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace AmazonAutomationTestFramework.Project.Tests.Steps
{
    [Binding]
    public class VerifyProductPriceConsistencySteps
    {
        private readonly IWebDriver _driver;

        public VerifyProductPriceConsistencySteps(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>("WebDriver");
        }

        [When("the user searches for an item")]
        public void WhenTheUserSearchesForAnItem()
        {
            var homepage = new Homepage(_driver);
            homepage.SearchItem("whiteboard");
        }

        [When("the user clicks an item from the search results")]
        public void WhenTheUserClicksAnItemFromTheSearchResults()
        {
            var searchresultspage = new SearchResultPage(_driver);
            searchresultspage.ScrollAndClickResult();
            
            
        }

        [Then("the product price should match the price displayed in the search results")]
        public void ThenTheProductPriceShouldMatchThePriceDisplayedInTheSearchResults()
        {
            var product = new ProductPage(_driver);
            product.ValidatePageComponents();
        }
        [When("the user adds the item to the basket")]
        public void WhenTheUserAddsTheItemToTheBasket()
        {
            var product = new ProductPage(_driver);
            product.ValidatePageComponents();
            product.ClickAddToBasket();
        }







    }
}
