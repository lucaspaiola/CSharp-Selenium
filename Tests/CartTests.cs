using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CSharp_Selenium_Project.PageObjects;
using System.Threading;

namespace CSharp_Selenium_Project.Tests
{
  [TestFixture]
  public class CartTests
  {
    private IWebDriver _driver = null!;
    private CartPage _cartPage = null!;

    [SetUp]
    public void Setup()
    {
      _driver = new ChromeDriver();
      _cartPage = new CartPage(_driver);
      _driver.Navigate().GoToUrl("https://practice.automationtesting.in/shop/");

      // Pre requirement: have at least one item on cart
      _cartPage.ClickOnAddAndroidQuickStartToCart();
    }

    [Test]
    [Description("Click on View Basket after add a product to cart and verify if redirects to cart page")]
    public void TestViewBasketButton()
    {
      _cartPage.ClickOnViewBasket();
      Assert.That(_driver.Url, Is.EqualTo("https://practice.automationtesting.in/basket/"));
    }

    [Test]
    [Description("Update the quantity of an item, then update the cart and verify if total price is updated")]
    public void TestUpdateQuantityOfAnItem()
{
    _driver.Navigate().GoToUrl("https://practice.automationtesting.in/basket/");
    _driver.Navigate().Refresh();

    var initialPriceText = _cartPage.ReturnTotalPriceElementText();
    
    // Remove ₹ from price
    var initialPrice = decimal.Parse(initialPriceText.Replace("₹", "").Trim());

    // Update quantity of the item on cart
    _cartPage.UpdateQuantityOfAnItemOnCart("2");
    _cartPage.ClickOnUpdateCart();

    Thread.Sleep(1000);

    // Get the updated price
    var updatedPriceText = _cartPage.ReturnTotalPriceElementText();
    var updatedPrice = decimal.Parse(updatedPriceText.Replace("₹", "").Trim());

    // Verify if the update price is equal to initial price times 2, because now there are 2 items on cart
    Assert.That(_cartPage.IsRemoveItemButtonVisible, Is.True, "Failed to load cart page");
    Assert.That(updatedPrice, Is.EqualTo(initialPrice * 2));
}

    [Test]
    [Description("Delete an item from cart and verify if undo button is visible")]
    public void TestRemoveOneItemFromCart()
    {
      _driver.Navigate().GoToUrl("https://practice.automationtesting.in/basket/");
      _driver.Navigate().Refresh();

      _cartPage.ClickOnRemoveItem();
      Assert.That(_cartPage.IsUndoRemovedItemButtonVisible, Is.True, "Undo removed item is not visible");
    }

    [Test]
    [Description("Delete an item from cart and then click on undo and verify if item is still on cart")]
    public void TestDeleteAnItemAndUndo()
    {
      _driver.Navigate().GoToUrl("https://practice.automationtesting.in/basket/");
      _driver.Navigate().Refresh();

      var initialPrice = _cartPage.ReturnTotalPriceElementText();

      _cartPage.ClickOnRemoveItem();
      _cartPage.ClickOnUndoRemovedItem();

      var finalPrice = _cartPage.ReturnTotalPriceElementText();

      Assert.That(_cartPage.IsRemoveItemButtonVisible, Is.True, "Undo removed item is not visible");
      Assert.That(initialPrice, Is.EqualTo(finalPrice), "Initial price and actual price are diferent");
    }

    [Test]
    [Description("Type and invalid coupon code and veirfy if error message is visible")]
    public void TestTypeAnInvalidCouponCode()
    {
      _driver.Navigate().GoToUrl("https://practice.automationtesting.in/basket/");
      _driver.Navigate().Refresh();

      _cartPage.TypeCouponCode("invalid");
      _cartPage.ClickOnApplyCoupon();

      Assert.That(_cartPage.IsCouponCodeErrorMessagVisible, Is.True, "Coupon code error message is not visible");
    }

    [Test]
    [Description("Click on proceed to checkout button and verify if redirects to checkout page")]
    public void TestProceedToCheckout()
    {
      _driver.Navigate().GoToUrl("https://practice.automationtesting.in/basket/");
      _driver.Navigate().Refresh();

      _cartPage.ClickOnProceedToCheckout();
      Assert.That(_driver.Url, Is.EqualTo("https://practice.automationtesting.in/checkout/"), "Failed to load checkout page");
    }

    [TearDown]
    public void TearDown()
    {
      _driver.Quit();
    }
  }
}
