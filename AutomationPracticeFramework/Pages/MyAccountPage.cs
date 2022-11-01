﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class MyAccountPage
    {
        readonly IWebDriver driver;
        public By myAccountPage = By.Id("my-account");
        public By successfulLogin = By.ClassName("info-account");
        public By wishlistlink = By.ClassName("lnk_wishlist");
        public By mypersonalinformation = By.CssSelector(".col-xs-12 [title = 'Information']");
        

        public MyAccountPage(IWebDriver driver)
        {
         
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(myAccountPage));

        }
    }
}
