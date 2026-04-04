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
        public string LastSearchTerm { get; private set; }

        public void SearchItem(string searchTerm)
        {
            LastSearchTerm = searchTerm; 

            Driver.FindElement(SearchField)
                  .SendKeys(searchTerm + Keys.Enter);
        }
  
        public void commonpagecomponents()
        {
            assertIsDisplayed(AmazonLogo);
            assertIsDisplayed(SearchField);
            assertIsDisplayed(NavigationBar);
            assertIsDisplayed(Basket);
            assertIsDisplayed(footer);
        } 
/*        public void SearchItem(string text)
        {
            Type(SearchField, text);
            Click(searchBtn);
        } */
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



     
 



