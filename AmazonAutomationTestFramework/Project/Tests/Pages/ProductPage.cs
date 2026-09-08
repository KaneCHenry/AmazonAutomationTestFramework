using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace AmazonAutomationTestFramework.Project.Tests.Pages
{
    public class ProductPage(IWebDriver driver) : CommonBasePage(driver)
    {

        //Element Locators
        public static By productName => By.Id("productTitle");
        private By priceWholeNumber => By.CssSelector(".a-price-whole");
        private By priceFractionNumber => By.CssSelector(".a-price-fraction");

        private By addToWishListLocator => By.Id("wishListMainButton");

        //button locator:
        public static By addToBasket => By.Id("add-to-cart-button");


        public void ValidatePageComponents()
        {
            AssertIsDisplayed(productName);
            AssertIsDisplayed(priceWholeNumber);
            AssertIsDisplayed(priceFractionNumber);
            AssertIsDisplayed(addToBasket);
        }
        public string getWholePriceNum()
        {
            var priceLocator = driver.FindElements(By.CssSelector(".a-price-whole"));
            var itemPrice = priceLocator[0].Text;

            return itemPrice;
        }
        public string getFractionPriceNum()
        {
            var priceFractionLocator = Driver.FindElements(By.CssSelector(".a-price-fraction"));
            var itemFractionPrice = priceFractionLocator[0].Text.Trim();

            return itemFractionPrice;
        }

        public string getPrice()
        {
            var wholePrice = getWholePriceNum();
            var fractionPrice = getFractionPriceNum();

            return $"{wholePrice}.{fractionPrice}";
        }
        public void ClickAddToBasket()
        {
            ScrollToElement(addToBasket);
            Click(addToBasket);
        }
        public void ClickAddList()
        {
            Click(addToWishListLocator);
        }
       

        public class ExpectedItemSearched
        {
        
        }


       }
}
