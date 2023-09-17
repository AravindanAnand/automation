using System;
using System.Diagnostics;
using automation.Repository;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V114.Page;
using OpenQA.Selenium.Edge;


namespace automation.Drivers
{
    public class Driver: BaseClass
    {

        public static string _url="";
        public static string _browser="";
        public static IWebDriver CurrentDriver;
        public Driver(String url, string browser){
            _url=url;
            _browser=browser;
        }
        public void setDriver(){
            switch(_browser){
                case "Chrome":
                    CurrentDriver=new ChromeDriver();
                    break; 
                
                case "Edge":
                    CurrentDriver=new EdgeDriver();
                    break; 
                
                default:
                    CurrentDriver=new ChromeDriver();
                    break; 
            }
            BaseClass.driver=CurrentDriver;
        }

         public IWebDriver getDriver(){
            return CurrentDriver;
        }

        public string getUrl(){
            return _url;
        }

        public void Flush(){
            CurrentDriver.Close();
            CurrentDriver.Quit();
            string pname="chromedriver";
            if(_browser=="Edge")
                pname="Edge";
            
            Process[] driverProcesses =  Process.GetProcessesByName(pname);
            foreach(var driverProcess in driverProcesses)
                    driverProcess.Kill();
        }
    }
}
