using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonAutomationTestFramework.Project.Tests.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace AmazonAutomationTestFramework.Project.Tests.Steps
{
    [Binding]
    public class SearchSuggestionsDisplayOnSearchField
    {
        private readonly IWebDriver _driver;

        public SearchSuggestionsDisplayOnSearchField(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>("WebDriver");
        }

        [Given("User is on the Amazon homepage")]
        public void GivenUserIsOnTheAmazonHomepage()
        {
            var commonBasePage = new CommonBasePage(_driver);
            commonBasePage.GoToBaseUrl();
            //Accept cookies
            var cookie = new cookieBanner(_driver);
            cookie.AcceptCookiesIfPresent();
            //validate components
            var homePage = new Homepage(_driver);
        }
        [When("the user enters a search term into the search bar")]
        public void WhenTheUserEntersASearchTermIntoTheSearchBar()
        {
            var homePage = new Homepage(_driver);
            homePage.EnterItemIntoSearchBar(Items.whiteboard);
            homePage.ValidateSearchSuggestions();
            homePage.SearchClear();
            homePage.EnterItemIntoSearchBar(Items.cup);
            homePage.ValidateSearchSuggestions();
           // homePage.SearchClear();
        }
        [Then("item suggestions appear under the search bar")]
        public void ThenItemSuggestionsAppearUnderTheSearchBar()
        {
            var homePage = new Homepage(_driver);
           
        }



    }
}
