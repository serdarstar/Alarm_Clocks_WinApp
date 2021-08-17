using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using WindowsAppDriver.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace WindowsAppDriver.Steps
{
    [Binding]
    public sealed class ScientificCalculatorSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly ScientificCalculatorPage _scientificCalculatorPage;


        public ScientificCalculatorSteps(ScenarioContext scenarioContext, ScientificCalculatorPage scientificCalculatorPage)
        {
            _scenarioContext = scenarioContext;
            _scientificCalculatorPage = scientificCalculatorPage;
        }

        //[When(@"I click (.*) button")]
        //public void WhenIClickTrigonometriButton(string type)
        //{
        //   _scientificCalculatorPage.EnterType(type);
         
        //}

        [When(@"I click ""(.*)"" button")]
        public void WhenIClickButton(string type)
        {
            _scientificCalculatorPage.EnterType(type);
        }


        [Then(@"the following options should be available")]
        public void ThenTheFollowingOptionsShouldBeAvailable(Table table)
        {

            var listTrig = table.Header.ToList();

            for (int i = 0; i < listTrig.Count; i++)
            {
                Assert.IsTrue(_scientificCalculatorPage.checkList(listTrig[i]));

            }

            Thread.Sleep(3000);


        }

    }
}
