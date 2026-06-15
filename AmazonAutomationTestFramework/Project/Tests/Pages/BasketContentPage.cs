using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AmazonAutomationTestFramework.Project.Tests.Pages
{
    public class BasketContentPage(IWebDriver driver) : CommonBasePage(driver)
    {
        private By pageHeaderLocator => By.Id("sc-active-items-header");
        private By secondaryHeaderLocator => By.ClassName("a-size-large");
        private By quantityControllerLocator => By.CssSelector("span[data-action='quantity']");
        private By popularDealsSectionLocator => By.ClassName("a-carousel-heading");

        private By decrementIconLocator => By.CssSelector("span[data-a-selector='decrement-icon']");
            //"span[data-a-selector='decrement-icon']");

        // private By yourItemsHeaderLocator => By.XPath("//h3[contains(text(),'Your Items')]");


        //Constants
        private static string expectedUrlSuffix = "gp/cart/view.html?ref_=nav_cart";
        private static string expectedUrlPageContent = "cart";
        private static string expectedPageHeader = "Shopping Basket";
        private static string expectedSecondaryHeader = "Your Items";

       public void VerifyBasketPageUrl()
        {
            var pageURL = Driver.Url;
            Assert.That(pageURL, Does.Contain(expectedUrlSuffix));
   
        }

        public void VerifyHeaderText()
        {
            AssertIsDisplayed(pageHeaderLocator);
            Assert.That(GetText(pageHeaderLocator),Is.EqualTo(expectedPageHeader));

//Assert.That(GetText(yourItemsHeaderLocator), Is.EqualTo(expectedSecondaryHeader));
        }

        public void ClickDecrement()
        {
            WaitUntilClickable(decrementIconLocator);   
        }

        public string GetBasketAmount()
        {
            ScrollToElement(Homepage.basketSpriteLocator);
            AssertIsDisplayed(Homepage.basketSpriteLocator);
            var rawText = GetText(Homepage.basketSpriteLocator);

            return new string(rawText
                .Where(char.IsDigit)
                .ToArray());
           // return GetText(Homepage.basketSpriteLocator);
        }
      
    }
}
