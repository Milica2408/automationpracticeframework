using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class ShoppingCartPage
    {
        readonly IWebDriver driver;
        public By shoppcart = By.Id("order");
        public By textprdress = By.CssSelector(".cart_description .product-name");
        public ShoppingCartPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(shoppcart));

        }
    }
}
