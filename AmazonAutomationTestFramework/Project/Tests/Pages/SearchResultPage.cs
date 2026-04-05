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
        public static By Advert => By.CssSelector("img.s-image");


        /*  public void validateSearchResult()
         {
              assertIsDisplayed(searchResult);
              var resultText = Driver.FindElement(searchResult).Text.Trim('"');

             // Assert.That(resultText, Is.EqualTo(resultText));
          } */
        public void ValidateSearchResult(string expectedSearchTerm)
        {
            assertIsDisplayed(searchResult);

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
