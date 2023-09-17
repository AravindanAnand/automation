using System;
using automation.Drivers;
using automation.Repository;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow;

namespace automation.Steps
{
    [Binding]
    public sealed class SwagLabsStepDefinition : ExtentReport
    {
        private readonly ScenarioContext _scenarioContext;
       private readonly FeatureContext _featurecontext;
       HomePage homepage=new HomePage();

       public SwagLabsStepDefinition(ScenarioContext scenarioContext,FeatureContext featurecontext)
       {
           _scenarioContext = scenarioContext;
           _featurecontext=featurecontext;
       }

       [Given("Login to the application")]
       public void Logintotheapplication()
       {            
           LoginPage login=new LoginPage();
           login.Login();
       }

        
[Given("Add item to cart by price (.*)")]
       public void AddItemToCartByPrice(string price)
       {    
        homepage.ClickAddtocartByPrice(price);
       }

       [Given("Add item to cart by name (.*)")]
       public void AddItemToCartByName(string name)
       {    
         homepage.ClickAddtocartByPrice(name);
       }

       [Then("Open cart to view the purchased items")]
       public void OpenCartToViewThePurchasedItems()
       {    
         homepage.OpenCart();
       }

       [Then("Checkout the items")]
       public void CheckoutTheItems()
       {    
        homepage.clickCheckoutItems();
       }

       [Then("Add the billing user information (.*) and (.*) and (.*)")]
       public void AddTheBillingUserInformation(string fname,string lname,string postcode)
       {    
         homepage.enterBillingInformation(fname,lname,postcode);
       }

       [Then("Finish the purchase")]
       public void FinishThePurchase()
       {    
        homepage.finishPurchase();
       }

       [When("Purchase is successfull")]
       public void PurchaseIsSuccessfull()
       {    
        homepage.verifyPurchase();
       }

       [Then("Come back to homepage")]
       public void ComeBackToHomepage()
       {    
        homepage.goBackHome();
        
       }
       
    }
}
