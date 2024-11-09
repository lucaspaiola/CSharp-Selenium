using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CSharp_Selenium_Project.PageObjects
{
  public class SignInPage
  {
    private readonly IWebDriver _driver;
    private WebDriverWait _wait;
    private IWebElement emailInput => _driver.FindElement(By.CssSelector("input[placeholder='E mail']"));
    private IWebElement passwordInput => _driver.FindElement(By.CssSelector("input[placeholder='Password']"));
    private IWebElement enterButton => _driver.FindElement(By.Id("enterbtn"));
    private IWebElement errorMessage => _driver.FindElement(By.Id("errormsg"));

    public SignInPage(IWebDriver driver)
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

    public bool IsPasswordInputVisible()
    {
      try
      {
        _wait.Until(_driver => passwordInput.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

    public bool IsEnterButtonVisible()
    {
      try
      {
        _wait.Until(_driver => enterButton.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

    public bool IsErrorMessageVisible()
    {
      try
      {
        _wait.Until(_driver => errorMessage.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

    public void TypeEmail(string email)
    {
      try
      {
        _wait.Until(_driver => emailInput.Displayed);
        emailInput.Clear();
        emailInput.SendKeys(email);
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Email input is not visible");
      }
    }

    public void TypePassword(string password)
    {
      try
      {
        _wait.Until(_driver => passwordInput.Displayed);
        passwordInput.Clear();
        passwordInput.SendKeys(password);
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Password input is not visible");
      }
    }

    public void ClickOnEnterButton()
    {
      try
      {
        _wait.Until(_driver => passwordInput.Displayed);
        enterButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Failed to click on enter button");
      }
    }

		
  }
}
