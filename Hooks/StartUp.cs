using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using automation.Drivers;
using TechTalk.SpecFlow;
using System;
using NUnit.Framework;
using System.IO;
using System.Text.Json;
using OpenQA.Selenium.DevTools.V114.Emulation;
using automation.Repository;

namespace automation.Hooks
{
    [Binding]
    public sealed class StartUp : ExtentReport
    {
        private readonly IObjectContainer _container;
        
             //Read Properties
            public static String configPath = dir.Replace("bin\\Debug\\netcoreapp3.1", "Configuration");
            public static string envSettingsFile = File.ReadAllText(configPath+"/EnvSettings.json");
             public static Driver driver;

        public StartUp(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {            
            Setup();
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {            
            TearDown();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            _feature = _extentReports.CreateTest<Feature>(featureContext.FeatureInfo.Title);
        }

        [AfterFeature]
        public static void AfterFeature()
        {
        }

        [BeforeScenario("@Testers")]
        public void BeforeScenarioWithTag()
        {
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            _container.RegisterInstanceAs<IWebDriver>(driver.getDriver());

            _scenario = _feature.CreateNode<Scenario>(scenarioContext.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario()
        {
           
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            string stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            string stepName = scenarioContext.StepContext.StepInfo.Text;

            var driver = _container.Resolve<IWebDriver>();

            //When scenario passed
            if (scenarioContext.TestError == null)
            {
                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName);
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName);
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName);
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName);
                }
            }

            //When scenario fails
            if (scenarioContext.TestError != null)
            {

                if (stepType == "Given")
                {
                    _scenario.CreateNode<Given>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "When")
                {
                    _scenario.CreateNode<When>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "Then")
                {
                    _scenario.CreateNode<Then>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
                else if (stepType == "And")
                {
                    _scenario.CreateNode<And>(stepName).Fail(scenarioContext.TestError.Message,
                        MediaEntityBuilder.CreateScreenCaptureFromPath(addScreenshot(driver, scenarioContext)).Build());
                }
            }
        }

        public static void Setup(){
            
            if(BaseClass.getProperty()!=null){
               driver=new Driver(BaseClass.getProperty().Url,BaseClass.getProperty().Browser); 
               driver.setDriver();   
               driver.getDriver().Url=driver.getUrl();           
               driver.getDriver().Manage().Window.Maximize();
               driver.getDriver().Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
               ExtentReportInit();
            }else{
                throw new Exception("Error in intiating the test");
            }
        }

        public static void TearDown(){       
            ExtentReportTearDown();     
            driver.Flush();
        }

    }
}