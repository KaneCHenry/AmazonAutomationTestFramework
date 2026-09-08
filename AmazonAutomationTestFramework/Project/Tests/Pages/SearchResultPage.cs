using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AmazonAutomationTestFramework.Project;
using static System.Net.Mime.MediaTypeNames;
using Reqnroll.Formatters.PubSub;

namespace AmazonAutomationTestFramework.Project.Tests.Pages
{
    public class SearchResultPage(IWebDriver driver) : CommonBasePage(driver)
    {
        // private By priceSliderLocator= By.Id("p_36/range-slider_slider-item_upper-bound-slider");
        // private By priceSliderValueLocator = By.CssSelector("");
        private static By maxPriceSlider => By.Id("p_36/range-slider_slider-item_upper-bound-slider");
        private static By searchResultLocator => By.CssSelector(".a-text-bold");
        public static By Advert => By.CssSelector("img[class='s-image']");
        public static By searchResultsHeaderLocator => By.CssSelector("h2.a-size-base.a-spacing-small.a-spacing-top-small.a-text-normal");

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
        public static By resultPagePriceLocator => By.CssSelector(".a-price .a-offscreen");
        public void SetMaximumPriceValue(int price)
        {
            ScrollToElement(maxPriceSlider);

            IWebElement slider = driver.FindElement(maxPriceSlider);

            // Start at minimum
            slider.SendKeys(Keys.Home);

            // Move upwards until we reach the requested price
            for (int i = 0; i < price; i++)
            {
                slider.SendKeys(Keys.ArrowRight);
            }
           Thread.Sleep(5000);

            var prices = driver.FindElements(resultPagePriceLocator);

            foreach (IWebElement priceElement in prices)
            {
                string priceText = priceElement.Text.Trim();

                if (string.IsNullOrWhiteSpace(priceText))
                {
                    continue;
                }

                int actualPrice = int.Parse(priceText);

                Assert.That(actualPrice, Is.LessThanOrEqualTo(price));
            }

            /*var validatePriceText = GetText(resultPagePriceLocator);
            int actualPrice = int.Parse(validatePriceText);
            Assert.That(actualPrice, Is.LessThanOrEqualTo(price)); */
        }
        public void ValidateSearchHeader()
        {
            AssertIsDisplayed(searchResultsHeaderLocator);
        }
        public void ValidateSearchResult(string expectedSearchTerm)
        {
            AssertIsDisplayed(searchResultLocator);


            string actual = Driver.FindElement(searchResultLocator)
                                  .Text
                                  .Trim()
                                  .Trim('"')
                                  .ToLowerInvariant();

            string expected = expectedSearchTerm
                              .Trim()
                              .ToLowerInvariant();

            Assert.That(actual, Is.EqualTo(expected),
                $"Expected '{expected}' but found '{actual}'");
        }

        public void ScrollAndClickResult()
        {
            ScrollToElement(Advert);
            Click(Advert);
        }

    }
}
