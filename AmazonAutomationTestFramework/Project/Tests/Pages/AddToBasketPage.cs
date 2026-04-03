
using OpenQA.Selenium;

namespace AmazonAutomationTestFramework.Project.Tests.Pages
{
    public class AddToBasketPage(IWebDriver driver) : CommonBasePage(driver)
    {
        private By addToBasketMessage => By.CssSelector("h1.sw-atc-text");
        private By shoppingBasket => By.Id("nav-cart-count-container");

        private const string addedToCartMessage = "Added to basket";


        public void IsDisplayedAddedToBasketMessage()
        {
            assertIsDisplayed(addToBasketMessage);
            var messageText = GetText(addToBasketMessage);
            Assert.That(messageText, Is.EqualTo(addedToCartMessage));
        }
        public void isDisplayedBasket(string expectedAmount)
        {
           assertIsDisplayed(shoppingBasket);
           var cartAmount = GetText(shoppingBasket);
            Assert.That(cartAmount, Is.EqualTo(expectedAmount));
        }

        
    }
}
