using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSharp_Selenium_Project.PageObjects
{
  public class IndexPage
  {
    private readonly IWebDriver _driver;
    private WebDriverWait _wait;
    private IWebElement emailInput => _driver.FindElement(By.Id("email"));
		private IWebElement imgEntering => _driver.FindElement(By.Id("enterimg"));
		private IWebElement signInButton => _driver.FindElement(By.Id("btn1"));
		private IWebElement skipSignInButton => _driver.FindElement(By.Id("btn2"));

    public IndexPage(IWebDriver driver)
    {
      _driver = driver;
      _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2)); // Wait up to 2 seconds to get an element
    }

    public bool IsEmailInputVisible()
    {
      try
      {
        _wait.Until(_driver => emailInput.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

		public bool IsImgEnterginVisible()
    {
      try
      {
        _wait.Until(_driver => imgEntering.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

		public bool IsSignInButtonVisible()
    {
      try
      {
        _wait.Until(_driver => signInButton.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

		public bool IsSkipSignInButtonVisible()
    {
      try
      {
        _wait.Until(_driver => skipSignInButton.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

    public void ClickOnSignInButton() 
    {
      try
      {
        _wait.Until(_driver => signInButton.Displayed);
        signInButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Failed to click on Sign In button");
      }
    }

    public void ClickOnSkipSignInButton() 
    {
      try
      {
        _wait.Until(_driver => skipSignInButton.Displayed);
        skipSignInButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Failed to click on Skip Sign In button");
      }
    }

    public void ClickOnEnteringImage() 
    {
      try
      {
        _wait.Until(_driver => imgEntering.Displayed);
        imgEntering.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Failed to click on Entering Image");
      }
    }
  }
}
