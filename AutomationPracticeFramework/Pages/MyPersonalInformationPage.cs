using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class MyPersonalInformationPage
    {
        readonly IWebDriver driver;

        public By personalinformation = By.Id("identity");
        public By lastnameedit = By.CssSelector(".is_required#lastname");
        public By savebutton = By.CssSelector(".form-group .button-medium");
        public By currentpasswd = By.CssSelector(".is_required#old_passwd");
        public By newlastname = By.CssSelector(".header_user_info .account");
        public MyPersonalInformationPage(IWebDriver driver)
        {
            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
          wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(personalinformation));

        }

    }


    
}
