using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V114.Page;


namespace automation.Drivers
{
    public class Driver
    {
        public static void Launch(){
            IWebDriver driver=new ChromeDriver();
            driver.Url="https:\\www.google.com";
            driver.Close();
        }
    }
}
