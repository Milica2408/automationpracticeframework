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
        private readonly PersonData personData;
        private readonly WishlistData wishlistData;
             
        
        public MyAccountSteps(PersonData personData, WishlistData wishlistData)
        {
            this.wishlistData = wishlistData;
            this.personData = personData;
        }

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
            personData.FullName = TestConstants.FirstName + " " + TestConstants.LastName;
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
            SignInPage sp = new SignInPage(Driver);
            ut.ElementDisplayed(sp.signoutbtn);
             
        }

        [Then(@"user's full name is displayed")]
        public void ThenUserSFullNameIsDisplayed()
        {

            Assert.True(ut.TextPresentInElement(personData.FullName).Displayed, "");
             
     
        }

        [When(@"Click on the Mywishlist section")]
        public void WhenClickOnTheMywishlistSection()
        {
            MyAccountPage map = new MyAccountPage(Driver);
            ut.ClickOnElement(map.wishlistlink);
        }


        [When(@"In the Name field enter random string")]
        public void WhenInTheNameFieldEnterRandomString()
        {
            WishlistPage wlp = new WishlistPage(Driver);
            wishlistData.WishlistName = ut.GenerateRandomPassword();
            ut.EntertextElement(wlp.inputname, wishlistData.WishlistName);

        }


        [When(@"Click the save button")]
        public void WhenClickTheSaveButton()
        {
            WishlistPage wlp = new WishlistPage(Driver);
            ut.ClickOnElement(wlp.savebtn);
            
        }

        [Then(@"The name of the new list is displayed in the table")]
        public void ThenTheNameOfTheNewListIsDisplayedInTheTable()
        {
            WishlistPage wlp = new WishlistPage(Driver);
            Assert.That(ut.ReturnTextFromElement(wlp.textname),
            Does.Contain(wishlistData.WishlistName), "Random string does not exist in the table");
        }


    }

}

