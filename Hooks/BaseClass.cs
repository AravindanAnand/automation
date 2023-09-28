using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Text.Json;
using automation.Drivers;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.IdentityModel.Tokens;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V114.Page;
using OpenQA.Selenium.Edge;


namespace automation.Repository
{
    public class BaseClass
    {
        public static IWebDriver driver;
        public static String dir = AppDomain.CurrentDomain.BaseDirectory;
        public static String configPath = dir.Replace("bin\\Debug\\netcoreapp3.1", "Configuration");
        public static string envSettingsFile = File.ReadAllText(configPath+"/EnvSettings.json");

        static string reportDesc="";

        public static string getDesc(){
            return reportDesc;
        }

         public static void setDesc(string desc){
            reportDesc=desc;
        }
      
       public static EnvSettings getProperty(){
            var Properties = JsonSerializer.Deserialize<EnvSettings>(envSettingsFile);
            return Properties;
       }

    }
}