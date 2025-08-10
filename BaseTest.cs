using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


[TestFixture]
public class JoskiyTest
{
    protected IWebDriver driver;

    [SetUp]
    public void Setup()
    {
        var options = new ChromeOptions();
        options.AddArgument("--start-maximized");
        driver = new ChromeDriver(options);
    }

    [TearDown]
    public void Teardown()
    {
        driver?.Dispose();
    }

    protected void LoginAs(string username, string password)
    {
        var loginPage = new LoginPage(driver);
        loginPage.LoginAs(username, password);
    }
}