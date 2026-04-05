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
        private IWebDriver driver;


        //Element Locators
        public static By productName => By.Id("productTitle");
        private By priceWholeNumber => By.CssSelector(".a-price-whole");
        private By priceFractionNumber => By.CssSelector(".a-price-fraction");
        

        //button locator:
        public static By addToBasket => By.Id("add-to-cart-button");


        public void ValidatePageComponents()
        {
            assertIsDisplayed(productName);
            assertIsDisplayed(priceWholeNumber);
            assertIsDisplayed(priceFractionNumber);
            assertIsDisplayed(addToBasket);
        
        }

        public void ClickAddToBasket()
        {
            ScrollToElement(addToBasket);
            Click(addToBasket);
           
        }

        public class ExpectedItemSearched
        {
        
        }


       }
}
