
using OpenQA.Selenium;
using static AmazonAutomationTestFramework.Project.Tests.Pages.CommonBasePage;

namespace AmazonAutomationTestFramework.Project.Tests.Pages
{
    public class AddToBasketPage(IWebDriver driver) : CommonBasePage(driver)
    {
        private By addToBasketMessage => By.CssSelector("h1.sw-atc-text");
        public By shoppingBasket => By.Id("nav-cart-count");

        private const string addedToCartMessage = "Added to basket";

      //  public static string BasketAmount => driver.FindElement(By.Id("nav-cart-count")).Text;
        public void IsDisplayedAddedToBasketMessage()
        {
            AssertIsDisplayed(addToBasketMessage);
            var messageText = GetText(addToBasketMessage);
            Assert.That(messageText, Is.EqualTo(addedToCartMessage));
        }
        public void isDisplayedBasket(string expectedAmount)
        {
           AssertIsDisplayed(shoppingBasket);
           var cartAmount = GetText(shoppingBasket);
            Assert.That(cartAmount, Is.EqualTo(expectedAmount));
        }
        public void countItems(string amount)
        {
          var currentamount =  GetText(shoppingBasket);
        Assert.That(currentamount, Is.EqualTo(amount));  
        }

      
        /*
public void AssertMultipleItemsPresent(List<string> expectedItems)
{
   foreach (var item in expectedItems)
   {
       assertIsDisplayed(By.XPath($"//span[contains(text(), '{item}')]"));
   }
} */






    }



}

