﻿using AutomationPracticeFramework.Helpers;
using AutomationPracticeFramework.Pages;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationPracticeFramework.Steps
{
    [Binding]
    public class FooterSteps : Base
    {

        FooterPage fp = new FooterPage(Driver);

        [When(@"user click on '(.*)' option")]
        public void WhenUserClickOnOption(string link)
        {
            fp.ClickOnInformationLink(link);
        }
        
        [Then(@"correct '(.*)' is displayed")]
        public void ThenCorrectIsDisplayed(string page)
        {
            Assert.True(fp.InformationPageIsDisplayed(page), "Expected page is not displayed");  
            
        }
    }
}
