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


        //Constants
        private static string expectedUrlSuffix = "/gp/cart/view.html?ref_=nav_cart";
        private static string expectedPageHeader = "Shopping Basket";
        private static string expectedSecondaryHeader = "Your Items";

        public void VerifyPageURL()
        {
            var pageURL = Driver.Url;
            Assert.That(pageURL, Is.EqualTo(PathConfig.BaseUrl + expectedUrlSuffix));
        }

        public void VerifyHeaderText()
        {
            AssertIsDisplayed(pageHeaderLocator);
            Assert.That(GetText(pageHeaderLocator),Is.EqualTo(expectedPageHeader));

            Assert.That(GetText(secondaryHeaderLocator), Is.EqualTo(expectedSecondaryHeader));
        }

    }
}
