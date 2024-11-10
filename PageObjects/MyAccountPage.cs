using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CSharp_Selenium_Project.PageObjects
{
  public class MyAccountPage
  {
    private readonly IWebDriver _driver;
    private WebDriverWait _wait;
    private IWebElement loginTitle => _driver.FindElement(By.XPath("//h2[text()='Login']"));

    private IWebElement loginUsernameLabel => _driver.FindElement(By.CssSelector("label[for='username']"));
    private IWebElement loginUsernameInput => _driver.FindElement(By.Id("username"));
    private IWebElement loginPasswordLabel => _driver.FindElement(By.CssSelector("label[for='password']"));
    private IWebElement loginPasswordInput => _driver.FindElement(By.Id("password"));
    private IWebElement loginButton => _driver.FindElement(By.Name("login"));
    private IWebElement loginErrorMessageUsernameRequired => _driver.FindElement(By.XPath("//li[strong[text()='Error:'] and contains(text(), 'Username is required.')]"));
    private IWebElement loginErrorMessagePasswordRequired => _driver.FindElement(By.XPath("//li[strong[text()='Error:'] and contains(text(), ' Password is required.')]"));
    private IWebElement forgotPasswordLink => _driver.FindElement(By.XPath("//a[text()='Lost your password?']"));

    private IWebElement registerTitle => _driver.FindElement(By.XPath("//h2[text()='Register']"));
    private IWebElement registerEmailLabel => _driver.FindElement(By.CssSelector("label[for='reg_email']"));
    private IWebElement registerEmailInput => _driver.FindElement(By.Id("reg_email"));
    private IWebElement registerPasswordLabel => _driver.FindElement(By.CssSelector("label[for='reg_password']"));
    private IWebElement registerPasswordInput => _driver.FindElement(By.Id("reg_password"));
    private IWebElement registerButton => _driver.FindElement(By.Name("register"));
    private IWebElement registerErrorMessagePasswordRequired => _driver.FindElement(By.XPath("//li[strong[text()='Error:'] and contains(text(), 'Please enter an account password')]"));

    public MyAccountPage(IWebDriver driver)
    {
      _driver = driver;
      _wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(2)); // Wait up to 2 seconds to get an element
    }

    public bool IsLoginTitleVisible()
    {
      try
      {
        _wait.Until(_driver => loginTitle.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

    public string LoginUserNameLabelText()
    {
      try
      {
        _wait.Until(_driver => loginUsernameLabel.Displayed);
        return loginUsernameLabel.Text;
      }
      catch (WebDriverTimeoutException)
      {
        return "Login Username label is not visible";
      }
    }

    public string LoginPasswordLabelText()
    {
      try
      {
        _wait.Until(_driver => loginPasswordLabel.Displayed);
        return loginPasswordLabel.Text;
      }
      catch (WebDriverTimeoutException)
      {
        return "Login Password label is not visible";
      }
    }

    public void TypeLoginUsername(string username)
    {
      try
      {
        // type email
        _wait.Until(_driver => loginUsernameInput.Displayed);
        loginUsernameInput.Clear();
        loginUsernameInput.SendKeys(username);
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Failed to type login username");
      }
    }

    public void TypeLoginPassword(string password)
    {
      try
      {
        // type password
        _wait.Until(_driver => loginPasswordInput.Displayed);
        loginPasswordInput.Clear();
        loginPasswordInput.SendKeys(password);
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Failed to type login password");
      }
    }

    public void ClickOnLoginButton()
    {
      try
      {
        _wait.Until(_driver => loginButton.Displayed);
        loginButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Login Button is not visible");
      }
    }

    public bool IsLoginErrorMessageUsernameRequiredVisible()
    {
      try
      {
        _wait.Until(_driver => loginErrorMessageUsernameRequired.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

    public bool IsLoginErrorMessagePasswordRequiredVisible()
    {
      try
      {
        _wait.Until(_driver => loginErrorMessagePasswordRequired.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

    public void ClickOnForgotPassword()
    {
      try
      {
        _wait.Until(_driver => forgotPasswordLink.Displayed);
        forgotPasswordLink.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Failed to click on forgot password button");
      }
    }

    public bool IsRegisterTitleVisible()
    {
      try
      {
        _wait.Until(_driver => registerTitle.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }

    public string RegisterEmailLabelText()
    {
      try
      {
        _wait.Until(_driver => registerEmailLabel.Displayed);
        return registerEmailLabel.Text;
      }
      catch (WebDriverTimeoutException)
      {
        return "Register email label is not visible";
      }
    }

    public string RegisterPasswordLabelText()
    {
      try
      {
        _wait.Until(_driver => registerPasswordLabel.Displayed);
        return registerPasswordLabel.Text;
      }
      catch (WebDriverTimeoutException)
      {
        return "Register Password label is not visible";
      }
    }

    public void TypeRegisterEmail(string username)
    {
      try
      {
        // type email
        _wait.Until(_driver => registerEmailInput.Displayed);
        registerEmailInput.Clear();
        registerEmailInput.SendKeys(username);
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Failed to type Register email");
      }
    }

    public void TypeRegisterPassword(string password)
    {
      try
      {
        // type password
        _wait.Until(_driver => registerPasswordInput.Displayed);
        registerPasswordInput.Clear();
        registerPasswordInput.SendKeys(password);
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Failed to type Register password");
      }
    }

    public void ClickOnRegisterButton()
    {
      try
      {
        _wait.Until(_driver => registerButton.Displayed);
        registerButton.Click();
      }
      catch (WebDriverTimeoutException)
      {
        Console.WriteLine("Register Button is not visible");
      }
    }

    public bool IsRegisterErrorMessagePasswordRequiredVisible()
    {
      try
      {
        _wait.Until(_driver => registerErrorMessagePasswordRequired.Displayed);
        return true;
      }
      catch (WebDriverTimeoutException)
      {
        return false;
      }
    }
		
  }
}
