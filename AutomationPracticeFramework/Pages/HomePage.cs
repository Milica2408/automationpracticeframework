﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class HomePage
    {
        readonly IWebDriver driver;

        public By homepage = By.Id("index");
        public By contactUs = By.Id("contact-link");
        public By searchField = By.Id("search_query_top");
        public By searchButton = By.Name("submit_search");
        public By signInlink = By.ClassName("login");
       
        
        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(homepage));


        }

        public IList<IWebElement> ReturnCategory(string catName)
        {
            By catOption = By.CssSelector(".sf-menu [title='" + catName + "']");
            IList<IWebElement> category = driver.FindElements(catOption);
            return category;
        }

       

    }
}
