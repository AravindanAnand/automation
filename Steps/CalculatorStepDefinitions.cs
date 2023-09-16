using System;
using automation.Drivers;
using AventStack.ExtentReports.Gherkin.Model;
using TechTalk.SpecFlow;

namespace automation.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions : ExtentReport
    {
        private readonly ScenarioContext _scenarioContext;
       private readonly FeatureContext _featurecontext;

       public CalculatorStepDefinitions(ScenarioContext scenarioContext,FeatureContext featurecontext)
       {
           _scenarioContext = scenarioContext;
           _featurecontext=featurecontext;
       }

       [Given("the first number is (.*)")]
       public void GivenTheFirstNumberIs(int number)
       {            
           Driver.Launch();
       }

       [Given("the second number is (.*)")]
       public void GivenTheSecondNumberIs(int number)
       {
           

          
        }
        
       [When("the two numbers are added")]
       public void WhenTheTwoNumbersAreAdded()
       {

          
       }

       [Then("the result shouldd be (.*)")]
       public void ThenTheResultShouldBe(int result)
       {
           Console.WriteLine("test print line");
       }
    }
}
