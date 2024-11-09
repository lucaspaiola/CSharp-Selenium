using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CSharp_Selenium_Project.PageObjects;

namespace CSharp_Selenium_Project.Tests
{
  [TestFixture]
  public class IndexPageTests
  {
    private IWebDriver _driver;
    private IndexPage _indexPage;

    [SetUp]
    public void Setup()
    {
      _driver = new ChromeDriver();
      _indexPage = new IndexPage(_driver);
      _driver.Navigate().GoToUrl("https://demo.automationtesting.in/Index.html");
    }

    [Test]
    public void VerifyEmailInputIsVisible()
    {
      Assert.That(_indexPage.IsEmailInputVisible(), Is.True, "Email input is not visible");
    }

    [Test]
    public void VerifyImgEnteringIsVisible()
    {
      Assert.That(_indexPage.IsImgEnterginVisible(), Is.True, "Enter image is not visible");
    }

    [Test]
    public void VerifySignInButtonVisible()
    {
      Assert.That(_indexPage.IsSignInButtonVisible(), Is.True, "Sign In button is not visible");
    }

    [Test]
    public void VerifySkipSignInButtonVisible()
    {
      Assert.That(_indexPage.IsSkipSignInButtonVisible(), Is.True, "Skip Sign In button is not visible");
    }

    [Test]
    public void VerifyClickOnSignInButton()
    {
      _indexPage.ClickOnSignInButton();
      Assert.That(_driver.Url, Is.EqualTo("https://demo.automationtesting.in/SignIn.html"), "Failed to click on Sign In button");
    }

    [Test]
    public void VerifyClickOnSkipSignInButton()
    {
      _indexPage.ClickOnSkipSignInButton();
      Assert.That(_driver.Url, Is.EqualTo("https://demo.automationtesting.in/Register.html"), "Failed to click on Skip Sign In button");
    }

    [Test]
    public void VerifyClickOnEnteringImage()
    {
      _indexPage.ClickOnEnteringImage();
      Assert.That(_driver.Url, Is.EqualTo("https://demo.automationtesting.in/Register.html"), "Failed to click on entering image");
    }

    [TearDown]
    public void TearDown()
    {
      _driver.Quit();
    }
  }
}
