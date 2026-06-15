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
using OpenQA.Selenium.DevTools.V143.DOM;

namespace AmazonAutomationTestFramework.Project.Tests.Pages
{
   
    public class Homepage(IWebDriver driver) : CommonBasePage(driver)
    {
        private By amazonLogoLocator => By.Id("nav-logo-sprites");
        private By searchFieldLocator => By.Id("twotabsearchtextbox");
        private By navigationBarLocator => By.Id("nav-xshop");
        public static By basketLocator=> By.CssSelector(".nav-cart-icon");

        public static By basketSpriteLocator => By.Id("nav-cart");
        private By footerLocator => By.CssSelector(".navFooterLinkCol.navAccessibility");
        private By searchBtnLocator => By.Id("nav-search-submit-button");
       // private By cartBtnLocator => By.Name("submit.add-to-cart");

        private By cartBtnLocator => By.Id("add-to-cart-button");

        private By searchSuggestionListLocator = By.ClassName("left-pane-results-container");

        private By searchListLocator = By.Id(PathConfig.searchDiv);
        private By signInAccountLocator => By.LinkText("Sign in securely");


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

        
        public void ClickAccountSignIn()
        {
            Click(signInAccountLocator);
        }
        public void ClickBasket()
        {
            Click(basketSpriteLocator);
        }

        public string LastSearchTerm { get; private set; }
        public void SearchItem(string searchTerm)
        {
            LastSearchTerm = searchTerm;

            var field = Driver.FindElement(searchFieldLocator);
            field.Clear();
            field.SendKeys(searchTerm + Keys.Enter);
        }

        public void ClickSignInAndAccountList()
        {
            WaitUntilClickable(signInAccountLocator);
        }

        public void commonpagecomponents()
        {
            AssertIsDisplayed(amazonLogoLocator);
            AssertIsDisplayed(searchFieldLocator);
            AssertIsDisplayed(navigationBarLocator);
            AssertIsDisplayed(basketLocator);
            AssertIsDisplayed(footerLocator);
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
                 "hoodie"
            };

            foreach (var item in itemsToAdd)
            {
                SearchItem(item);
                ScrollAndClickResult(SearchResultPage.Advert);

                Clickbutton();
                Thread.Sleep(2000);

            }

        }

        public void Clickbutton()
        {
            Click(cartBtnLocator);
        }

        public void ValidateSearchSuggestions()
        {
           WaitUntilVisible(searchSuggestionListLocator);
            AssertIsDisplayed(searchSuggestionListLocator);
        }

   
        

        public void EnterItemIntoSearchBar(string text)
        {
          Type(searchFieldLocator, text);
        } 
        public void SearchClear()
        {
            Find(searchFieldLocator).Clear();
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

 
     
 


