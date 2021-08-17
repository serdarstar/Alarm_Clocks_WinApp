using System;
using System.Diagnostics;
using System.IO;
using WindowsAppDriver.Driver;
using WindowsAppDriver.Helper;
using FluentAssertions;
using TechTalk.SpecFlow;
using OpenQA.Selenium.Appium.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;

namespace WindowsAppDriver.Steps
{
    [Binding]
    public class CalculatorFeatureSteps
    {
        private readonly StandardCalculatorPage _calculator;
        private static Process _driver;
        private WindowsDriver<WindowsElement> _session;
        public CalculatorFeatureSteps(StandardCalculatorPage calculator)
        {
            _calculator = calculator;
            
        }

        [BeforeTestRun]
        public static void StartWinAppDriver()
        {
            try
            {
                var configurationDriver = new ConfigurationDriver();
                string winAppDriverPath = configurationDriver.Configuration["winAppPath"];
                _driver = Process.Start(winAppDriverPath);
            }
            catch (Exception e)
            {
                Console.WriteLine("Could not locate WinAppDriver.exe, get it from https://github.com/Microsoft/WinAppDriver/releases and change the winAppPath in app.settings accordingly");
                throw new FileNotFoundException("Could not locate File WinAppDriver.exe", e);
            }
        }

        [AfterTestRun]
        public static void KillWinAppDriver()
        {
           
            _driver.Kill();
        }


        [Given(@"I navigated to (.*)")]
        public void GivenINavigatedToStandard(string calculatorType)
        {
            _calculator.NavigateToStandard(calculatorType);

        }

        [Given(@"I have entered (.*) into calculator")]
        public void GivenIHaveEnteredIntoCalculator(string p0)
        {
            _calculator.EnterNumber(p0);
        }

        [Given(@"I press (.*)")]
        public void GivenIPress(string p0)
        {
            _calculator.EnterSign(p0);
        }

        [When(@"I press (.*)")]
        public void WhenIPressEquals(string p0)
        {
            _calculator.EnterSign(p0);
        }

        [Then(@"Calculator title is (.*)")]
        public void ThenBrowserTitleIs(string p0)
        {
            _calculator.GetTitle().Should().Be(p0);
        }

        [Then(@"the result should be (.*) on the screen")]
        public void ThenTheResultShouldBeOnTheScreen(string p0)
        {
            _calculator.GetResult().Should().Be(p0);
        }

        [AfterScenario(Order = 1000)]
        public void CleanUp()
        {


            GetScreenshot("",_session);


        }

        public static void GetScreenshot(string fileName, WindowsDriver<WindowsElement> session)
        {
            try
            {
                
                    var screenshot = session.GetScreenshot();

                    string folderPath = @"C:\Users\serdar.yildiz\source\repos\Alarms_Clock_WindowsAppDriver\WindowsAppDriver\bin";
                    Directory.CreateDirectory(folderPath);

                    var filePath = folderPath + @"\" + fileName;

                    screenshot.SaveAsFile(filePath, ScreenshotImageFormat.Png);
              
            }
            catch (Exception e)
            {
                Console.WriteLine("Line Failed: " + e.Message);
                Console.WriteLine("** COULD NOT GET SCREENSHOT ***");
            }

        }

    }
}
