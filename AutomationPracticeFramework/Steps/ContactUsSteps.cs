using AutomationPracticeFramework.Helpers;
using AutomationPracticeFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationPracticeFramework.Steps
{
    [Binding]
    public class ContactUsSteps : Base
    {
        Utilities ut = new Utilities(Driver);
        HomePage hp = new HomePage(Driver);

        [Given(@"user open contact us page")]
        public void GivenUserOpenContactUsPage()
        {
            ut.ClickOnElement(hp.contactUs);
        }
        
        [When(@"user fill in all required fields with '(.*)' heading and '(.*)' message")]
        public void WhenUserFillInAllRequiredFieldsWithHeadingAndMessage(string heading, string message)
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            ut.DrobdownSelect(cup.subjectHeading, heading);
            ut.EntertextElement(cup.contactEmail, ut.GenerateRandomEmail());
            ut.EntertextElement(cup.message, message);
        }
        
        [When(@"user submits the form")]
        public void WhenUserSubmitsTheForm()
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            ut.ClickOnElement(cup.sendBtn);
            
        }
        
        [Then(@"message '(.*)' is presented to the user")]
        public void ThenMessageIsPresentedToTheUser(string successMessage)
        {
            ContactUsPage cup = new ContactUsPage(Driver);
            Assert.That(ut.ReturnTextFromElement(cup.successMessage), Is.EqualTo(successMessage), "Message was not sent to customer service");
        }
    }
}
