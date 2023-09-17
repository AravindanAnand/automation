using System;
using System.Diagnostics;
using System.Threading;
using automation.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V114.Page;
using OpenQA.Selenium.Edge;


namespace automation.Repository
{
    public class HomePage : BaseClass
    {
       public void ClickAddtocartByPrice(string price){
             try{
                HomepageOR.price=price;
                driver.FindElement(HomepageOR.buttonAddtoCartByPrice).Click();
             }catch(Exception ex){
                Assert.Fail("Failure:"+ex.Message);
             }
       }

       public void ClickAddtocartByName(string name){
             try{
                HomepageOR.name=name;
                driver.FindElement(HomepageOR.buttonAddtoCartByName).Click();
             }catch(Exception ex){
                Assert.Fail("Failure:"+ex.Message);
             }
       }


       public void OpenCart(){
             try{
                driver.FindElement(HomepageOR.linkMovetoCart).Click();
             }catch(Exception ex){
                Assert.Fail("Failure:"+ex.Message);
             }
       }

       public void clickCheckoutItems(){
             try{
                driver.FindElement(HomepageOR.buttonCheckout).Click();
             }catch(Exception ex){
                Assert.Fail("Failure:"+ex.Message);
             }
       }

        public void enterBillingInformation(string fname,string lname,string postalcode){
             try{
                 driver.FindElement(HomepageOR.txtBoxFirstName).SendKeys(fname);
                 driver.FindElement(HomepageOR.txtBoxLastName).SendKeys(lname); 
                 driver.FindElement(HomepageOR.txtBoxPostalCode).SendKeys(postalcode);
                 driver.FindElement(HomepageOR.buttonContinue).Click();
             }catch(Exception ex){
                Assert.Fail("Failure:"+ex.Message);
             }
       }

        public void finishPurchase(){
             try{
                driver.FindElement(HomepageOR.buttonFinish).Click();
             }catch(Exception ex){
                Assert.Fail("Failure:"+ex.Message);
             }
       }

       public void verifyPurchase(){
             try{
                string purchasemsg=driver.FindElement(HomepageOR.labelPurchaseSuccessMsg).Text.Trim();
                Assert.AreEqual(purchasemsg,"Thank you for your order!");
             }catch(Exception ex){
                Assert.Fail("Failure:"+ex.Message);
             }
       }

       public void goBackHome(){
             try{
                driver.FindElement(HomepageOR.buttonBackToHome).Click();
                Thread.Sleep(2000);                
             }catch(Exception ex){
                Assert.Fail("Failure:"+ex.Message);
             }
       }
    }
}