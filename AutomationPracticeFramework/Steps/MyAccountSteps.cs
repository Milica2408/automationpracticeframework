using AutomationPracticeFramework.Helpers;
using AutomationPracticeFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationPracticeFramework.Steps
{
    [Binding]
    public class MyAccountSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HomePage hp = new HomePage(Driver);

        [Given(@"Click on the Sign in link")]
        public void GivenClickOnTheSignInLink()
        {
            ut.ClickOnElement(hp.signInlink);
        }
        
        [Given(@"Fill in the Email address  with '(.*)' and Password '(.*)'")]
        public void GivenFillInTheEmailAddressWithAndPassword(string email, string password)
        {
            SignInPage sinp = new SignInPage(Driver);
            ut.EntertextElement(sinp.emailField, email);
            ut.EntertextElement(sinp.passwordField, password);
        }
        
        [When(@"Click on the Sign in button")]
        public void WhenClickOnTheSignInButton()
        {
            SignInPage sinp = new SignInPage(Driver);
            ut.ClickOnElement(sinp.signInBtn);

        }
        
        [Then(@"message '(.*)' is displayed to the user")]
        public void ThenMessageIsDisplayedToTheUser(string successMessage)
        {
            MyAccountPage map = new MyAccountPage(Driver);
            Assert.That(ut.ReturnTextFromElement(map.successfulLogin), Is.EqualTo(successMessage), "The user could not log in");

        }
    }
}

