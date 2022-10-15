using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class LayerCartPage
    {
        readonly IWebDriver driver;
        public By lcpage = By.CssSelector("#category #layer_cart");
        public By checkoutbtn = By.CssSelector(".button-container .button-medium");
        public LayerCartPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(lcpage));

        }
    }
}
