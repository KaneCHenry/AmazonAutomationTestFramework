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
    public class AddMultipleShoppingItemsToBasket
    { 
 
        private readonly IWebDriver _driver;
        public AddMultipleShoppingItemsToBasket(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>("WebDriver");
        }


        [Given("the user is on registered and on the amazon homepage")]
        public void GivenTheUserIsOnRegisteredAndOnTheAmazonHomepage()
        {
            var commonBasePage = new CommonBasePage(_driver);
            commonBasePage.GoToBaseUrl();

            var cookie = new cookieBanner(_driver);
            cookie.AcceptCookiesIfPresent();

            var homePage = new Homepage(_driver);
            homePage.commonpagecomponents();
        }
        [When("the user adds multiple items to the basket")]
        public void WhenTheUserAddsMultipleItemsToTheBasket()
        {
            var homePage = new Homepage(_driver);
            homePage.AddMultipleItemsToBasket();

          
        }
        [Then("user is able to see the correct amount of items in the shopping basket")]
        public void ThenUserIsAbleToSeeTheCorrectAmountOfItemsInTheShoppingBasket()
        {
            var addToBasket = new AddToBasketPage(_driver);
            addToBasket.countItems("3");
        }






    }

}
