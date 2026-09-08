using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AmazonAutomationTestFramework.Project.Tests.Pages;
using OpenQA.Selenium;
using Reqnroll;
using static AmazonAutomationTestFramework.Project.Tests.Pages.LoginPages;

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

        [Given("the user is on the amazon hompage and there are items displayed in the search basket")]
        public void GivenThereAreItemsDisplayedInTheSearchBasket()
        {
                var commonBasePage = new CommonBasePage(_driver);
                commonBasePage.GoToBaseUrl();
                var cookie = new cookieBanner(_driver);
                cookie.AcceptCookiesIfPresent();
                var homePage = new Homepage(_driver);
                homePage.commonpagecomponents();

          /*      homePage.ClickAccountSignIn();
                var signInEmail = new SignInEmailNumber(_driver);
            signInEmail.EnterUsername("kanehenry2014@gmail.com");
            signInEmail.ClickContinue();
            var signInPassword = new SignInPassword(_driver);
            signInPassword.EnterPassword("Premier123");
            signInPassword.ClickSignIn();
            Thread.Sleep(4000);  */

            homePage.AddMultipleItemsToBasket();
            homePage.ClickBasket();
            
        }
        [When("the user clicks on the shopping basket and is on the shopping basket page")]
        public void WhenTheUserClicksOnTheShoppingBasketAndIsOnTheShoppingBasketPage()
        {
           var basketContentPage = new BasketContentPage(_driver);
           basketContentPage.VerifyBasketPageUrl();
            
       
            Thread.Sleep(2000);
        }
        [Then("the user is able to remove items from the cart and the cart amount reflects remaining number correctly")]
        public void ThenTheUserIsAbleToRemoveItemsFromTheCartAndTheCartAmountReflectsRemainingNumberCorrectly()
        {
            var basketContentPage = new BasketContentPage(_driver);
            basketContentPage.ClickDecrement();
            //basketContentPage.VerifyPageURL();
            //basketContentPage.VerifyHeaderText();


            var currentBasketAmount = basketContentPage.GetBasketAmount();
            Assert.That(currentBasketAmount, Is.EqualTo("2"));
            basketContentPage.ClickDecrement();

            var newCurrentBasketAmount = basketContentPage.GetBasketAmount();
            Assert.That(newCurrentBasketAmount, Is.EqualTo("1"));
            basketContentPage.ClickDecrement();

            var lastCurrentBasketAmount = basketContentPage.GetBasketAmount();
            Assert.That(newCurrentBasketAmount, Is.EqualTo("0"));
        }

    }
}
