using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using automation.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V114.Page;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;


namespace automation.Repository
{
    public class HomePage : BaseClass
    {
       public void ClickAddtocartByPrice(string price){
             try{
               
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

       public void enterPincode(string pincode){
         try{
            try{
               if(Driver.waitForElementClickable(HomepageOR.buttonChangePincode))
                  driver.FindElement(HomepageOR.buttonChangePincode).Click(); 
               }catch(ElementClickInterceptedException ex){}

               if(Driver.waitForElement(HomepageOR.txtBoxPincode)){
                     driver.FindElement(HomepageOR.txtBoxPincode).SendKeys(pincode); 
                        string pincodeele= HomepageOR.listPincoderesult.Replace("#_pincode#",pincode);

                        if(Driver.waitForElementClickable(By.XPath(pincodeele))){
                            driver.FindElement(By.XPath(pincodeele)).Click();
                        }else{
                           throw new Exception("No service for the pincode:"+pincode+".");
                        }
                  }

             }catch(Exception ex){
                Assert.Fail("Failure:"+ex.Message);
             }
       }

       public void getLevel1Headers(){
         try{

              Thread.Sleep(5000);
              string description="";              
              IList<IWebElement> headers=driver.FindElements(HomepageOR.level1Headers);
              foreach(IWebElement element in headers){
                  if(element.GetAttribute("data-ng-if").Contains("!category.children.length"))
                     description=description+"<h3>"+element.Text+"</h3>";
                  else{
                     description=description+"<h3>"+element.Text+"</h3>";
                    description= description+"<p>"+getSubHeaders(element.Text,element)+"</p>";
                  }
              }
              BaseClass.setDesc(description);

             }catch(Exception ex){
                Assert.Fail("Failure:"+ex.Message);
          }
       }

       public string getSubHeaders(string title,IWebElement element){
            string header=HomepageOR.level2Headers.Replace("#_lvl2header#",title);
            string items="";
            IList<IWebElement> headers=driver.FindElements(By.XPath(header));
            if(headers.Count<=0){
               header=HomepageOR.level2Item.Replace("#_lvl2header#",title);
               IList<IWebElement> itemList=driver.FindElements(By.XPath(header));
               foreach(IWebElement item in itemList){
                 items=items+item.Text+",";
               }
            }else{
               foreach(IWebElement item in headers){
                 items=items+item.Text+",";
               }
            }
         
            return items.TrimEnd(',');
       }
    }
}