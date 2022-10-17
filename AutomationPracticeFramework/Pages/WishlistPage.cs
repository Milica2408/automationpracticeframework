using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class WishlistPage
    {
        readonly IWebDriver driver;
        public By wishlistpage = By.Id("module-blockwishlist-mywishlist");
        public By inputname = By.Id("name");
        public By savebtn = By.Id("submitWishlist");
        public By textname = By.CssSelector(".table tr td a");
        public WishlistPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(wishlistpage));
        }

    }
}
