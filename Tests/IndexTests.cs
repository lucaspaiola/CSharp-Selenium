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

    [TearDown]
    public void TearDown()
    {
      _driver.Quit();
    }
  }
}
