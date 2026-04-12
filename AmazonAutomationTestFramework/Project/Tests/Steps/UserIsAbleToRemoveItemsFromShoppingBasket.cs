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
    public class UserIsAbleToRemoveItemsFromShoppingBasket
    {
        private readonly IWebDriver _driver;

        public UserIsAbleToRemoveItemsFromShoppingBasket(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>("WebDriver");
        }

        [Given("the user is on the amazon hompe and there are items displayed in the search basket")]
        public void GivenThereAreItemsDisplayedInTheSearchBasket()
        {
                var commonBasePage = new CommonBasePage(_driver);
                commonBasePage.GoToBaseUrl();
                var cookie = new cookieBanner(_driver);
                cookie.AcceptCookiesIfPresent();
                var homePage = new Homepage(_driver);
                homePage.commonpagecomponents();
                homePage.AddMultipleItemsToBasket();
        }

    }
}
