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
    public class LoginPage : BaseClass
    {
       public void Login(){
             try{
                driver.Url=getProperty().Url;             
             }catch(Exception ex){
                Assert.Fail("Failure:"+ex.Message);
             }
       }
    }
}