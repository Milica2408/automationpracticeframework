using AutomationPracticeFramework.Helpers;
using AutomationPracticeFramework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace AutomationPracticeFramework.Steps
{
    [Binding]
    public class PDPSteps : Base

       
    {
        HomePage hp = new HomePage(Driver);
        Utilities ut = new Utilities(Driver);

        private readonly ProductData productData;

        public PDPSteps(ProductData productData)
        {
            this.productData = productData;
        }

        

        [Given(@"user opens '(.*)' section")]
        public void GivenUserOpensSection(string cat)
        {
           hp.ReturnCategory(cat)[1].Click();
        }
        
        [Given(@"opens first product from the list")]
        public void GivenOpensFirstProductFromTheList()
        {
            PLPPage plp = new PLPPage(Driver);
            ut.ClickOnElement(plp.firstProduct);
            

      
        }
        
        [Given(@"increases quantity to '(.*)'")]
        public void GivenIncreasesQuantityTo(string qty)
        {
            
            By iframe = By.ClassName("fancybox-iframe");
            Driver.SwitchTo().Frame(Driver.FindElement(iframe));
            PDPPage pdp = new PDPPage(Driver);
            //Driver.FindElement(pdp.quantity).Clear();
            ut.ClearInputField(pdp.quantity);
            ut.EntertextElement(pdp.quantity, qty);
            productData.ProductName = ut.ReturnTextFromElement(pdp.productName);
        }
        
        [When(@"user clicks on add to cart button")]
        public void WhenUserClicksOnAddToCartButton()
        {
            PDPPage pd = new PDPPage(Driver);
            ut.ClickOnElement(pd.addButton);
        }
        
        [When(@"user proceeds to checkout")]
        public void WhenUserProceedsToCheckout()
        {
            LayerCartPage lcp = new LayerCartPage(Driver);
            ut.ClickOnElement(lcp.checkoutbtn);
        }
        
        [Then(@"cart is opened and product is added to cart")]
        public void ThenCartIsOpenedAndProductIsAddedToCart()
        {
            ShoppingCartPage scp = new ShoppingCartPage(Driver);
            Assert.That(ut.ReturnTextFromElement(scp.textprdress),
            Does.Contain(productData.ProductName), "Printed dress product is not in the shopping cart");
        }
    }
}
