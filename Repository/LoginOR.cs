using System;
using System.Diagnostics;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V114.Page;
using OpenQA.Selenium.Edge;


namespace automation.Repository
{
    public class LoginOR
    {
        //Sample try to include all types
        public static By txtBoxUsername=By.Id("user-name");
        public static By txtBoxPassword=By.XPath("//input[contains(@class,'input_error') and @id='password']");

        public static By buttonLogin=By.XPath("//input[@type='submit']");
    }
}