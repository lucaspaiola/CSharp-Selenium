using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSharp_Selenium_Project.PageObjects
{
  public class IndexPage
  {
    private readonly IWebDriver _driver;
    private WebDriverWait _wait;
    public IWebElement emailInput => _driver.FindElement(By.Id("email"));

    public IndexPage(IWebDriver driver)
    {
      _driver = driver;
      _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2)); // Wait up to 2 seconds to get an element
    }

    public bool IsEmailInputVisible()
    {
      try
      {
        _wait.Until(driver => driver.FindElement(By.Id("email")).Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }
  }
}
