
using OpenQA.Selenium;
using static AmazonAutomationTestFramework.Project.Tests.Pages.CommonBasePage;

namespace AmazonAutomationTestFramework.Project.Tests.Pages
{
    public class AddToBasketPage(IWebDriver driver) : CommonBasePage(driver)
    {
        private By addToBasketMessage => By.CssSelector("h1.sw-atc-text");
        public By shoppingBasket => By.Id("nav-cart-count");

        private const string addedToCartMessage = "Added to basket";

      //  public static string BasketAmount => driver.FindElement(By.Id("nav-cart-count")).Text;
        public void IsDisplayedAddedToBasketMessage()
        {
            AssertIsDisplayed(addToBasketMessage);
            var messageText = GetText(addToBasketMessage);
            Assert.That(messageText, Is.EqualTo(addedToCartMessage));
        }
        public void isDisplayedBasket(string expectedAmount)
        {
           AssertIsDisplayed(shoppingBasket);
           var cartAmount = GetText(shoppingBasket);
            Assert.That(cartAmount, Is.EqualTo(expectedAmount));
        }
        public void countItems(string amount)
        {
          var currentamount =  GetText(shoppingBasket);
        Assert.That(currentamount, Is.EqualTo(amount));  
        }

      
        /*
public void AssertMultipleItemsPresent(List<string> expectedItems)
{
   foreach (var item in expectedItems)
   {
       assertIsDisplayed(By.XPath($"//span[contains(text(), '{item}')]"));
   }
} */






    }



}

/*
 * 
 * For an Amazon-style e-commerce automation framework, it's good to cover the main customer journeys and edge cases rather than just basket functionality.

Here are 10 additional test cases that would look good in a portfolio project:

### 1. Search for a Product

**Test:** User searches for "wireless mouse"

**Verify:**

* Search results page loads
* Results contain relevant products
* Search term is displayed in the search box

---

### 2. Filter Search Results

**Test:** Search for "headphones" and apply a price filter

**Verify:**

* Filter is applied
* All displayed products fall within the selected range

---

### 3. Sort Search Results

**Test:** Sort products by "Price: Low to High"

**Verify:**

* Products are displayed in ascending price order

---

### 4. Open Product Details Page

**Test:** Click a product from search results

**Verify:**

* Product page loads
* Product title is displayed
* Price is displayed
* Add to Basket button exists

---

### 5. Add Product to Wishlist

**Test:** Logged-in user adds product to wishlist

**Verify:**

* Success message appears
* Product exists in wishlist

---

### 6. Update Basket Quantity

**Test:** Add item to basket and change quantity from 1 to 3

**Verify:**

* Quantity updates correctly
* Basket total recalculates

---

### 7. Verify Basket Persistence

**Test:** Add item to basket and refresh page

**Verify:**

* Item remains in basket
* Quantity remains unchanged

---

### 8. Empty Basket Validation

**Test:** Remove all items from basket

**Verify:**

* Basket shows empty state message
* Checkout button is unavailable

---

### 9. Proceed to Checkout

**Test:** Add item to basket and click Checkout

**Verify:**

* User reaches checkout/login page
* Correct basket contents are carried forward

---

### 10. Verify Product Price Consistency

**Test:** Open product page and add item to basket

**Verify:**

* Product price on product page matches basket price

---

### Bonus Advanced Tests (Great for Interviews)



Phase 1

Become an excellent Automation QA.

That means:

Finish Amazon framework.
Add API testing.
Add CI/CD.
Add reporting.
Add data-driven testing.
Add screenshots.
Add parallel execution.
Document it on GitHub.

Finish the core user journeys
Search product
Add to basket
Remove from basket
Validate basket
Product details page
Price check
Make the framework cleaner
Common waits in CommonBasePage
Reusable click/type/get text methods
Avoid duplicate locators
Keep assertions mostly in step/test layer, not page objects
Add reporting
Screenshots on failure
Test result output
Maybe ExtentReports or LivingDoc later
Add API tests
Even a small fake API or public API with RestSharp
Shows you’re not only UI automation
Add CI/CD
GitHub Actions or Azure DevOps pipeline
Run tests automatically
Document it properly
README.md
Tech stack
How to run
Test scenarios covered
Framework structure
Future improvements

Now you've got something tangible to show.

#### 11. Pagination Validation

Search for a product and navigate to page 2.

**Verify:**

* URL updates correctly
* New results are displayed

---

#### 12. Out-of-Stock Product

Attempt to add unavailable item.

**Verify:**

* Appropriate message shown
* Basket not updated

---

#### 13. Guest User Checkout Restriction

Attempt checkout without logging in.

**Verify:**

* Login page displayed

---

#### 14. Product Rating Verification

Open product page.

**Verify:**

* Rating exists
* Rating value is between 0 and 5

---

#### 15. Broken Image Validation

Verify product images load successfully.

**Verify:**

* No broken image URLs
* Images are displayed

---

If you're using **C# + Selenium + NUnit + Page Object Model**, a portfolio framework containing:

* Search Tests
* Product Tests
* Basket Tests
* Checkout Tests
* Wishlist Tests
* API Tests (using RestSharp)
* Data-Driven Tests (JSON)
* Screenshots on Failure
* Parallel Execution

will look significantly more impressive than a framework that only covers basket operations. This would closely resemble the structure of a real-world e-commerce automation suite.
*/