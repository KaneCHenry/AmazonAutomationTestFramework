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
        
        private By searchResult => By.CssSelector(".a-text-bold");
        public static By Advert => By.CssSelector("img[class='s-image']");

        public void ValidateSearchResult(string expectedSearchTerm)
        {
            AssertIsDisplayed(searchResult);

            string actual = Driver.FindElement(searchResult)
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
