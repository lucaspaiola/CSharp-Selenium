using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharp_Selenium_Project.PageObjects
{
  public class CartPage
  {
    private readonly IWebDriver _driver;
    private WebDriverWait _wait;
    private IWebElement addAndroidQuickStartToCartButton => _driver.FindElement(By.CssSelector("a[href='/shop/?add-to-cart=169']"));
    private IWebElement viewBasketButton => _driver.FindElement(By.CssSelector("a[title='View Basket']"));
    private IWebElement priceElement => _driver.FindElement(By.CssSelector("td.product-price span.woocommerce-Price-amount.amount"));
    private IWebElement quantityProductInput => _driver.FindElement(By.CssSelector("input.input-text.qty.text"));
    private IWebElement totalPriceElementCart => _driver.FindElement(By.CssSelector("td.product-subtotal span.woocommerce-Price-amount"));
    private IWebElement couponCodeInput => _driver.FindElement(By.Id("coupon_code"));
    private IWebElement applyCouponButton => _driver.FindElement(By.CssSelector("input[name='apply_coupon']"));
    private IWebElement updateCartButton => _driver.FindElement(By.CssSelector("input[name='update_cart']"));
    private IWebElement removeItemButton => _driver.FindElement(By.CssSelector("a[title='Remove this item']"));
    private IWebElement undoRemovedItemButton => _driver.FindElement(By.XPath("//a[text()='Undo?']"));
    private IWebElement cartIsEmptyMessage => _driver.FindElement(By.ClassName("cart-empty"));
    private IWebElement couponErrorMessage => _driver.FindElement(By.XPath("//ul[@class='woocommerce-error']//li[contains(text(),'Coupon') and contains(text(),'does not exist')]"));
    private IWebElement proceedToCheckoutButton => _driver.FindElement(By.ClassName("checkout-button"));

    public CartPage(IWebDriver driver)
    {
      _driver = driver;
      _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2)); // Wait up to 2 seconds to get an element
    }

    public void ClickOnAddAndroidQuickStartToCart()
    {
      try
      {
        _wait.Until(_driver => addAndroidQuickStartToCartButton.Displayed);
        addAndroidQuickStartToCartButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Failed to add product to cart");
      }
    }

    public void ClickOnViewBasket()
    {
      try
      {
        _wait.Until(_driver => viewBasketButton.Displayed);
        viewBasketButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Failed to click on view basket button");
      }
    }

    public string ReturnTotalPriceElementText()
    {
      try
      {
        _wait.Until(_driver => totalPriceElementCart.Displayed);
        return totalPriceElementCart.Text;
      }
      catch (WebDriverTimeoutException)
      {
        return "Price element is not visible on cart";
      }
    }

    public void UpdateQuantityOfAnItemOnCart(string newQuantity)
    {
      try
      {
        _wait.Until(_driver => quantityProductInput.Displayed);
        quantityProductInput.Clear();
        quantityProductInput.SendKeys(newQuantity);
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Quantity input is not visible on cart");
      }
    }

    public void TypeCouponCode(string couponCode)
    {
      try
      {
        _wait.Until(_driver => couponCodeInput.Displayed);
        couponCodeInput.Clear();
        couponCodeInput.SendKeys(couponCode);
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Coupon code input is not visible on cart");
      }
    }

    public void ClickOnApplyCoupon()
    {
      try
      {
        _wait.Until(_driver => applyCouponButton.Displayed);
        applyCouponButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Apply coupon button is not visible on cart");
      }
    }

    public void ClickOnUpdateCart()
    {
      try
      {
        _wait.Until(_driver => updateCartButton.Displayed);
        updateCartButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Update cart button is not visible on cart");
      }
    }

    public void ClickOnRemoveItem()
    {
      try
      {
        _wait.Until(_driver => removeItemButton.Displayed);
        removeItemButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Remove item button is not visible on cart");
      }
    }

    public bool IsRemoveItemButtonVisible()
    {
      try
      {
        _wait.Until(_driver => removeItemButton.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

    public void ClickOnUndoRemovedItem()
    {
      try
      {
        _wait.Until(_driver => undoRemovedItemButton.Displayed);
        undoRemovedItemButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Undo removed item button is not visible on cart");
      }
    }

    public bool IsUndoRemovedItemButtonVisible()
    {
      try
      {
        _wait.Until(_driver => undoRemovedItemButton.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

    public string CartIsEmptyText()
    {
      try
      {
        _wait.Until(_driver => cartIsEmptyMessage.Displayed);
        return cartIsEmptyMessage.Text;
      }
      catch (WebDriverTimeoutException)
      {
        return "Cart is empty message is not visible";
      }
    }

    public bool IsCouponCodeErrorMessagVisible()
    {
      try
      {
        _wait.Until(_driver => couponErrorMessage.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

    public void ClickOnProceedToCheckout()
    {
      try
      {
        _wait.Until(_driver => proceedToCheckoutButton.Displayed);
        proceedToCheckoutButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Proceed to checkout button is not visible");
      }
    }
  }
}
