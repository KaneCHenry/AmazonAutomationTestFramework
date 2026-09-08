using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonAutomationTestFramework.Project.Tests.Pages;
using OpenQA.Selenium;
using Reqnroll;
using Reqnroll.EnvironmentAccess;


namespace AmazonAutomationTestFramework.Project.Tests.Steps
{
    [Binding]
    public class SearchResultFilter
    {

        private readonly IWebDriver _driver;

        public SearchResultFilter(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>("WebDriver");
        }
        [Given("I am on the amazon homepage")]
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
        [When("I type an item into the search bar and click search")]
        public void WhenITypeAnItemIntoTheSearchBarAndClickSearch()
        {
            var homepage = new Homepage(_driver);
            homepage.SearchItem("wallet");
        }
        [When("the search result appears")]
        public void WhenTheSearchResultAppears()
        {
            var searchresultpage = new SearchResultPage(_driver);   
            searchresultpage.ValidateSearchHeader();
        }
        [Then("I am able to manipulate the price filter")]
        public void ThenIAmAbleToManipulateThePriceFilter()
        {
            var searchresultpage = new SearchResultPage(_driver);
            searchresultpage.SetMaximumPriceValue(20);
            
        }





    }
}