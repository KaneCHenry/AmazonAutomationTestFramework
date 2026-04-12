using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using AmazonAutomationTestFramework.Project.Tests.Pages;
using Reqnroll;
using System.Xml.Linq;
using System.Security.Cryptography.X509Certificates;
using static AmazonAutomationTestFramework.Project.Tests.Pages.CommonBasePage;

namespace AmazonAutomationTestFramework.Project.Tests.Pages
{
    [Binding]
    public class Homepage(IWebDriver driver) : CommonBasePage(driver)
    {
        private By AmazonLogo => By.Id("nav-logo-sprites");
        private By SearchField => By.Id("twotabsearchtextbox");
        private By NavigationBar => By.Id("nav-xshop");
        private By Basket => By.CssSelector(".nav-cart-icon");
        private By footer => By.CssSelector(".navFooterLinkCol.navAccessibility");
        private By searchBtn => By.Id("nav-search-submit-button");

        private By cartBtn => By.Name("submit.add-to-cart");

        private By SearchSuggestionList = By.ClassName("left-pane-results-container");

        private By SearchList = By.Id(PathConfig.searchDiv);

        //constants 
        private static readonly Random random = new Random();

        private readonly List<string> searchNum = new()
        {
          "01", "02", "03", "04", "05"
        };

        private string randomNumber;

        public void SelectRandomSuggestion()
        {
          string value = searchNum[random.Next(searchNum.Count)];

          var locator = By.XPath($"//*[@id='{PathConfig.searchDiv}']//span[contains(text(), '{value}')]");

           Find(locator).Click();
        }

        




        public string LastSearchTerm { get; private set; }
        public void SearchItem(string searchTerm)
        {
            LastSearchTerm = searchTerm;

            var field = Driver.FindElement(SearchField);
            field.Clear();
            field.SendKeys(searchTerm + Keys.Enter);
        }


        public void commonpagecomponents()
        {
            AssertIsDisplayed(AmazonLogo);
            AssertIsDisplayed(SearchField);
            AssertIsDisplayed(NavigationBar);
            AssertIsDisplayed(Basket);
            AssertIsDisplayed(footer);
        }
        public void ClearAndType(IWebElement element, string text)
        {
            element.Click();
            element.SendKeys(Keys.Control + "a");
            element.SendKeys(Keys.Delete);
            element.SendKeys(text);
        }

        public void AddMultipleItemsToBasket()
        {
           var itemsToAdd = new List<string>
            {
                "Fountain pen",
                 "Stapler",
                 "Headphones"
            };

            foreach (var item in itemsToAdd)
            {
                SearchItem(item);
                ScrollAndClickResult(SearchResultPage.Advert);

                Clickbutton();

            }

        }

        public void Clickbutton()
        {
            Click(cartBtn);
        }

        public void ValidateSearchSuggestions()
        {
           WaitUntilVisible(SearchSuggestionList);
            AssertIsDisplayed(SearchSuggestionList);
        }

   
        

        public void EnterItemIntoSearchBar(string text)
        {
          Type(SearchField, text);
        } 
        public void SearchClear()
        {
            Find(SearchField).Clear();
        }
      
        /*
        private By GetProductByName(string productName)
        {
            return By.XPath($"//span[contains(text(),'{productName}')]");
        }

        public void ClickProductByName(string productName)
        {
            var productLocator = GetProductByName(productName);
            WaitUntilVisible(productLocator);
            Driver.FindElement(productLocator).Click();
        }*/
    }
}

 
     
 


