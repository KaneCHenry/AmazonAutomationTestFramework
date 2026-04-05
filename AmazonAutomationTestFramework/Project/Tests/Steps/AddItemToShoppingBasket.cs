using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonAutomationTestFramework.Project.Tests.Pages;
using OpenQA.Selenium;
using Reqnroll;
using AmazonAutomationTestFramework.Project.Tests.Pages;
using OpenQA.Selenium;
using Reqnroll;

namespace AmazonAutomationTestFramework.Project.Tests.Steps
{
    [Binding]
    public class AddItemToShoppingBasket
    {
        private readonly IWebDriver _driver;

        public AddItemToShoppingBasket(ScenarioContext scenarioContext)
        {
            _driver = scenarioContext.Get<IWebDriver>("WebDriver");
        }


        [Given("the user is on the amazon homepage")]
        public void GivenTheUserIsOnTheAmazonHomepage()
        {
            
            var commonBasePage = new CommonBasePage(_driver);
            commonBasePage.GoToBaseUrl();
           
            var cookie = new cookieBanner(_driver);
            cookie.AcceptCookiesIfPresent();
          
            var homePage = new Homepage(_driver);
            homePage.commonpagecomponents();
        }
        [When("the user searches and selects an item to purchase")]
        public void WhenTheUserSearchesAndSelectsAnItemToPurchase()
        {
            var homePage = new Homepage(_driver);
            homePage.SearchItem("wallet");

            var product = new ProductPage(_driver);
            product.ValidatePageComponents();
            product.ClickAddToBasket();
        }


        [Then("that item is reflected in the shopping basket as expected")]
        public void ThenThatItemIsReflectedInTheShoppingBasketAsExpected()
        {
            var addbasketpage = new AddToBasketPage(_driver);
            addbasketpage.IsDisplayedAddedToBasketMessage();
            addbasketpage.isDisplayedBasket("1");
        }



    }
}
