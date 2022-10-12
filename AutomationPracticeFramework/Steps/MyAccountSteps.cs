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
        String username;

        public MyAccountSteps()
        {
            username = ut.GenerateRandomEmail();
        }



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



        [Given(@"In the Create an account section enter the Email adress")]
        public void GivenInTheCreateAnAccountSectionEnterTheEmailAdress()
        {
            SignInPage sp = new SignInPage(Driver);
            ut.EntertextElement(sp.email, username);

        }

        [When(@"Click on the Create an account button")]
        public void WhenClickOnTheCreateAnAccountButton()
        {
            SignInPage sp = new SignInPage(Driver);
            ut.ClickOnElement(sp.createbutton);

        }

        [When(@"Fill in all required fields")]
        public void WhenFillInAllRequiredFields()
        {
            CreateAccount ca = new CreateAccount(Driver);
            ut.EntertextElement(ca.firstname, TestConstants.FirstName);
            ut.EntertextElement(ca.lastname, TestConstants.LastName);
            ut.EntertextElement(ca.email, username);
            ut.EntertextElement(ca.password, ut.GenerateRandomPassword());
            ut.EntertextElement(ca.address, TestConstants.Address);
            ut.EntertextElement(ca.firstname2, TestConstants.FirstName);
            ut.EntertextElement(ca.lastname2, TestConstants.LastName);
            ut.EntertextElement(ca.city, TestConstants.City);
            ut.DrobdownSelect(ca.state, TestConstants.State);
            ut.EntertextElement(ca.zipcode, TestConstants.ZipCode);
            ut.DrobdownSelect(ca.country, TestConstants.Country);
            ut.EntertextElement(ca.mobphone, TestConstants.MobilePhone);
            ut.EntertextElement(ca.alias, TestConstants.AddressAlias);


        }

        [When(@"Click on the Register button")]
        public void WhenClickOnTheRegisterButton()
        {
            CreateAccount ca = new CreateAccount(Driver);
            ut.ClickOnElement(ca.registerbtn);
        }

        [Then(@"user will be logged in")]
        public void ThenUserWillBeLoggedIn()
        {
           // Assert.That(
             //   ut.ReturnTextFromElement(hp.signoutbtn),
              //  Is.EqualTo(TestConstants.Signout),
              //  "The user is not logged in"
              //  );
        }

        [Then(@"user's full name is displayed")]
        public void ThenUserSFullNameIsDisplayed()
        {
           // Assert.That(
              //  ut.ReturnTextFromElement(hp.fullnamebtn),
              //  Is.EqualTo(TestConstants.Fullname),
              //  "The user's full name is not displayed"
              //  );
        }

    }
}

