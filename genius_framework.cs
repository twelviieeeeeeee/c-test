using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Runtime.CompilerServices;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers; 

public class LabsPage
{
    protected IWebDriver driver;

    public LabsPage(IWebDriver driver)
    {
        this.driver = driver;
    }

    public void Open()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        Console.WriteLine("shto-to");
    }
}

public abstract class BasePage
{
    protected IWebDriver driver;
    protected WebDriverWait wait;

    protected BasePage(IWebDriver driver)
    {
        this.driver = driver;
        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
    }
}

public class LoginPage : BasePage
{
    public LoginPage(IWebDriver driver) : base(driver) {}

    // Locators
    private By usernameField = By.Id("user-name");
    private By passwordField = By.Id("password");
    private By LoginButton = By.Id("login-button");

    public void Open()
    {
        driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    public void EnterUsername(string username)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(usernameField)).SendKeys(username);
    }

    public void EnterPassword(string password)
    {
        wait.Until(ExpectedConditions.ElementIsVisible(passwordField)).SendKeys(password);
    }

    public void ClickLogin()
    {
        wait.Until(ExpectedConditions.ElementToBeClickable(LoginButton)).Click();
    }

    public void LoginAs(string username, string password)
    {
        Open();
        EnterUsername(username);
        EnterPassword(password);
        ClickLogin();
    }
}


public class AddToCartPage : BasePage
{
    public AddToCartPage(IWebDriver driver) : base(driver) {}
    //Locators
    private IWebElement AddToCartButton =>
        wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("add-to-cart-sauce-labs-backpack")));


    public void ClickAdd()
    {
        AddToCartButton.Click();
    }

    public bool IsProductAddedToCart()
    {
        try
        {
            var shortWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            shortWait.Until(ExpectedConditions.ElementIsVisible(By.Id("remove-sauce-labs-backpack")));
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}

public class RemovePage : BasePage
{
    public RemovePage(IWebDriver driver) : base(driver) {}

    //Locators
    private IWebElement RemoveButton =>
        wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("remove-sauce-labs-backpack")));

    public void ClickRemove()
    {
        RemoveButton.Click();
    }

    public bool IsProductRemovedFromCart()
    {
        try
        {
            var shortWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            shortWait.Until(ExpectedConditions.ElementIsVisible(By.Id("add-to-cart-sauce-labs-backpack")));
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}

public class ShoppingCart : BasePage
{
    public ShoppingCart(IWebDriver driver) : base(driver) {}

    //Locators
    private IWebElement ShoppingCartButton =>
        wait.Until(ExpectedConditions.ElementToBeClickable(By.ClassName("shopping_cart_link")));

    public void ClickCart()
    {
        ShoppingCartButton.Click();
    }

    public bool IsCartOpen()
    {
        try
        {
            var shortWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10)); 
            shortWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName("title")));
            return true;
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
}
    