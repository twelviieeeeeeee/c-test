using System.Diagnostics;
using NUnit.Framework;
using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Text.Json.Serialization;

[SetUpFixture]
public class AllureSetup
{
    [OneTimeSetUp]
    public void GlobalSetup()
    {
        AllureLifecycle.Instance.CleanupResultDirectory(); // Clear Results
    }
}


[AllureNUnit]
[TestFixture]
public class SwagTests : JoskiyTest
{
    [Test]
    [AllureTag("smoke")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureOwner("Anton")]   
    [AllureStory("Open main page")]
    public void TestOpenSwag()

    {
        var labsPage = new LabsPage(driver);
        labsPage.Open();
        Assert.That(driver.Title, Does.Contain("Swag"), "Title doesnt include 'Swag'");
    }
}

[AllureNUnit]
[TestFixture]
public class LoginTests : JoskiyTest
{
    [Test]
    [TestCase("standard_user", "secret_sauce")]
    [AllureTag("smoke")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureOwner("Anton")]
    [AllureStory("UserLogin")]
    public void TestLoginUser(string username, string password)
    {
        var loginPage = new LoginPage(driver);
        loginPage.LoginAs(username, password);
        
        Assert.That(driver.Url, Does.Contain("inventory"), "User is not logged in");
    }
}

public class AddToCartPageTest : JoskiyTest
{
    [Test]
    [TestCase("standard_user", "secret_sauce")]
    [AllureTag("smoke")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureOwner("Diana")]
    [AllureStory("AddToCart")]
    public void TestAddToCartPage(string username, string password)
    {
        var loginPage = new LoginPage(driver);
        loginPage.LoginAs(username, password);

        var addToCart = new AddToCartPage(driver);
        addToCart.ClickAdd();
        Assert.IsTrue(addToCart.IsProductAddedToCart(),"Item is not added to cart");
    }
}

public class RemovePageTest : JoskiyTest
{
    [Test]
    [TestCase("standard_user", "secret_sauce")]
    [AllureTag("smoke")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureOwner("Diana")]
    [AllureStory("Remove from cart")]
    public void TestRemovePage(string username, string password)
    {
        var loginPage = new LoginPage(driver);
        loginPage.LoginAs(username, password);

        var addToCart = new AddToCartPage(driver);
        addToCart.ClickAdd();
        Assert.IsTrue(addToCart.IsProductAddedToCart(), "Item is not added to cart");

        var remove = new RemovePage(driver);
        remove.ClickRemove();
        Assert.IsTrue(remove.IsProductRemovedFromCart(), "Product is not removed from cart");
    }
}

public class CartOpenTest : JoskiyTest
{
    [Test]
    [TestCase("standard_user", "secret_sauce")]
    [AllureTag("smoke")]
    [AllureSeverity(SeverityLevel.normal)]
    [AllureOwner("Diana")]
    [AllureStory("Open Cart")]
    public void TestCartOpen(string username, string password)
    {
        var loginPage = new LoginPage(driver);
        loginPage.LoginAs(username, password);

        var addToCart = new AddToCartPage(driver);
        addToCart.ClickAdd();
        Assert.IsTrue(addToCart.IsProductAddedToCart(), "Product is added to cart");

        var ShoppingCart = new ShoppingCart(driver);
        ShoppingCart.ClickCart();
        Assert.IsTrue(ShoppingCart.IsCartOpen(), "Cart is open");
    }
}