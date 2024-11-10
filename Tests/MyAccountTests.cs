using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CSharp_Selenium_Project.PageObjects;

namespace CSharp_Selenium_Project.Tests
{
  public class MyAccountPageTests
  {
    private IWebDriver _driver = null!;
    private MyAccountPage _myAccountPage = null!;

    [SetUp]
    public void Setup()
    {
      _driver = new ChromeDriver();
      _driver.Navigate().GoToUrl("https://practice.automationtesting.in/my-account/");
      _myAccountPage = new MyAccountPage(_driver);
    }

    [Test]
    [Description("Verify if the Login title is visible on the page")]
    public void TestLoginTitleVisible()
    {
      Assert.That(_myAccountPage.IsLoginTitleVisible(), Is.True, "Login title is not visible");
    }

    [Test]
    [Description("Verify if the Register title is visible on the page")]
    public void TestRegisterTitleVisible()
    {
      Assert.That(_myAccountPage.IsRegisterTitleVisible(), Is.True, "Register title is not visible");
    }

    [Test]
    [Description("Verify the text of the Login Username label")]
    public void TestLoginUsernameLabelText()
    {
      Assert.That(_myAccountPage.LoginUserNameLabelText(), Is.EqualTo("Username or email address *"));
    }

    [Test]
    [Description("Verify the text of the Login Password label")]
    public void TestLoginPasswordLabelText()
    {
      Assert.That(_myAccountPage.LoginPasswordLabelText(), Is.EqualTo("Password *"));
    }

    [Test]
    [Description("Verify the text of the Register Email label")]
    public void TestRegisterEmailLabelText()
    {
      Assert.That(_myAccountPage.RegisterEmailLabelText(), Is.EqualTo("Email address *"));
    }

    [Test]
    [Description("Verify the text of the Register Password label")]
    public void TestRegisterPasswordLabelText()
    {
      Assert.That(_myAccountPage.RegisterPasswordLabelText(), Is.EqualTo("Password *"));
    }

    [Test]
    [Description("Type only username and verify if 'password required' error message is visible")]
    public void TestLoginUsernameOnly()
    {
      _myAccountPage.TypeLoginUsername("testuser");
      _myAccountPage.ClickOnLoginButton();
      Assert.That(_myAccountPage.IsLoginErrorMessagePasswordRequiredVisible(), Is.True);
    }

    [Test]
    [Description("Verify if the error message for missing login password is displayed")]
    public void TestLoginPasswordOnly()
    {
      _myAccountPage.TypeLoginPassword("testpassword");
      _myAccountPage.ClickOnLoginButton();
      Assert.That(_myAccountPage.IsLoginErrorMessageUsernameRequiredVisible(), Is.True);
    }

    [Test]
    [Description("Verify forgot password link")]
    public void TestForgotPasswordLink()
    {
      _myAccountPage.ClickOnForgotPassword();
      Assert.That(_driver.Url, Is.EqualTo("https://practice.automationtesting.in/my-account/lost-password/"));
    }

    [Test]
    [Description("Verify if the error message for missing register email is displayed")]
    public void TestRegisterEmailOnly()
    {
      _myAccountPage.TypeRegisterEmail("alberteinsteinexample@example.com");
      _myAccountPage.ClickOnRegisterButton();
      Assert.That(_myAccountPage.IsRegisterErrorMessagePasswordRequiredVisible(), Is.True);
    }

    [TearDown]
    public void TearDown()
    {
      _driver.Quit();
    }
  }
}
