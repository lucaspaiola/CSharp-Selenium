using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CSharp_Selenium_Project.PageObjects;

namespace CSharp_Selenium_Project.Tests
{
  [TestFixture]
  public class SignInTests
  {
    private IWebDriver _driver = null!;
    private SignInPage _signInPage = null!;

    [SetUp]
    public void Setup()
    {
      _driver = new ChromeDriver();
       _signInPage = new SignInPage(_driver);
      _driver.Navigate().GoToUrl("https://demo.automationtesting.in/SignIn.html");
    }

    [Test]
    [Description("Verify if the email input is visible")]
    public void VerifyEmailInputIsVisible()
    {
      Assert.That(_signInPage.IsEmailInputVisible(), Is.True, "Email input is not visible");
    }

    [Test]
    [Description("Verify if the password input is visible")]
    public void VerifyPasswordInputIsVisible()
    {
      Assert.That(_signInPage.IsPasswordInputVisible(), Is.True, "Password input is not visible");
    }

    [Test]
    [Description("Verify if the enter button is visible")]
    public void VerifyEnterButtonIsVisible()
    {
      Assert.That(_signInPage.IsEnterButtonVisible(), Is.True, "Enter button is not visible");
    }

    [Test]
    [Description("Click on enter button with no password")]
    public void ClickOnEnterButtonWithNoPassword()
    {
      _signInPage.TypeEmail("example.gmail.com");
      _signInPage.ClickOnEnterButton();
      Assert.That(_signInPage.IsErrorMessageVisible(), Is.True, "Error message is not visible");
    }

    [Test]
    [Description("Click on enter button with no email")]
    public void ClickOnEnterButtonWithNoEmail()
    {
      _signInPage.TypePassword("StrongPassword123");
      _signInPage.ClickOnEnterButton();
      Assert.That(_signInPage.IsErrorMessageVisible(), Is.True, "Error message is not visible");
    }

    [Test]
    [Description("Type an invalid email and checks if shows an error message")]
    public void TypeInvalidEmail()
    {
      _signInPage.TypeEmail("invalidemail.com");
      _signInPage.ClickOnEnterButton();
      Assert.That(_signInPage.IsErrorMessageVisible(), Is.True, "Error message is not visible");
    }

    [TearDown]
    public void TearDown()
    {
      _driver.Quit();
    }
  }
}
