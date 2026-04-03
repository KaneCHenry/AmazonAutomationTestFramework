using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AmazonAutomationTestFramework.Project;

namespace AmazonAutomationTestFramework.Project.Tests.Pages
{
    public class SearchResultPage(IWebDriver driver) : CommonBasePage(driver)
    {
        
        private By searchResult => By.CssSelector(".a-text-bold");
        private By kettleAdvert => By.CssSelector("img.s-image");
        public void validateSearchResult()
        {
            assertIsDisplayed(searchResult);
            var resultText = Driver.FindElement(searchResult).Text.Trim('"');
            Assert.That(resultText, Is.EqualTo(Items.phone));
        }
        public void ScrollAndClickResult()
        {
            ScrollToElement(kettleAdvert);
            Click(kettleAdvert);
        }

    }
}
