using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace AutomationPracticeFramework.Pages
{
    class CreateAccount
    {
        
        public IWebDriver driver;

        public By createaccount = By.Id("noSlide");
        public By firstname = By.Id("customer_firstname");
        public By lastname = By.Id("customer_lastname");
        public By email = By.Id("email");
        public By password = By.Id("passwd");
        public By address = By.Id("address1");
        public By firstname2 = By.XPath("//*[@id='firstname'][@name='firstname']");
        public By lastname2 = By.XPath("//*[@id='lastname'][@name='lastname']");
        public By city = By.Id("city");
        public By state = By.Id("id_state");
        public By zipcode = By.Id("postcode");
        public By country = By.Id("id_country");
        public By mobphone = By.Id("phone_mobile");
        public By alias = By.Id("alias");
        public By registerbtn = By.Id("submitAccount");
        
       public CreateAccount(IWebDriver driver)
        {

            this.driver = driver;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementExists(createaccount));

        }

    }
}
